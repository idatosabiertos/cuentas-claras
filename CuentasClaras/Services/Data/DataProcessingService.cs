using CuentasClaras.Api.Stats;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace CuentasClaras.Services.Data
{
    public class DataProcessingService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public DataProcessingService(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public List<T> ItemsFrom<T>(string dataSource, string sheetName) where T : new()
        {
            string fileName = $"Files\\{dataSource}.xlsx";

            FileInfo file = new FileInfo(Path.Combine(_hostingEnvironment.ContentRootPath, fileName));
            if (!file.Exists)
            {
                file = new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, fileName));
                if (!file.Exists)
                    throw new Exception($"FILE NOT FOUND");
            }

            using (ExcelPackage package = new ExcelPackage(file))
            {
                var watch = System.Diagnostics.Stopwatch.StartNew();
                List<T> releasesWorksheet = package.Workbook.Worksheets[sheetName].ConvertSheetToObjects<T>().ToList();
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;

                return releasesWorksheet;
            }
        }

        public void ExportFile(string fileName, IEnumerable<INetworkNode> nodes, IEnumerable<NetworkEdge> edges)
        {
            var weightMax = nodes.Max(x => x.Weight);
            var weightMin = nodes.Min(x => x.Weight);

            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheetNodes = excelPackage.Workbook.Worksheets.Add("Nodes");
                ExcelWorksheet worksheetEdges = excelPackage.Workbook.Worksheets.Add("Edges");

                worksheetNodes.Cells["A1"].Value = "Id";
                worksheetNodes.Cells["B1"].Value = "Label";
                worksheetNodes.Cells["C1"].Value = "Weight";
                worksheetNodes.Cells["D1"].Value = "Type";

                worksheetEdges.Cells["A1"].Value = "Source";
                worksheetEdges.Cells["B1"].Value = "Target";
                worksheetEdges.Cells["C1"].Value = "Type";
                worksheetEdges.Cells["D1"].Value = "Id";
                worksheetEdges.Cells["E1"].Value = "Label";
                worksheetEdges.Cells["F1"].Value = "Interval";
                worksheetEdges.Cells["G1"].Value = "Weight";

                int i = 1;
                foreach (var node in nodes)
                {
                    i++;
                    worksheetNodes.Cells[$"A{i}"].Value = node.Id;
                    worksheetNodes.Cells[$"B{i}"].Value = node.Name;
                    worksheetNodes.Cells[$"C{i}"].Value = CalculateWeight(node.Weight, weightMin, weightMax, 10D, 1000D);
                    worksheetNodes.Cells[$"D{i}"].Value = node.Type.ToString();
                }

                int j = 1;
                foreach (var edge in edges)
                {
                    j++;
                    worksheetEdges.Cells[$"A{j}"].Value = edge.FromId;
                    worksheetEdges.Cells[$"B{j}"].Value = edge.ToId;
                    //worksheetEdges.Cells[$"C{i}"].Value = edge.
                    //worksheetEdges.Cells[$"D{i}"].Value = edge.
                    //worksheetEdges.Cells[$"E{i}"].Value = edge.
                    //worksheetEdges.Cells[$"F{i}"].Value = edge.
                    //worksheetEdges.Cells[$"G{i}"].Value = CalculateWeight(edge.Weight, weightMin, weightMax, 1m, 10m);
                }

                FileInfo fileInfo = new FileInfo(Path.Combine(_hostingEnvironment.ContentRootPath, fileName));
                excelPackage.SaveAs(fileInfo);
            }
        }

        public double CalculateWeight(double weight, double weightMin, double weightMax, double a, double b)
        {
            return ((b - a) * (weight - weightMin)) / (weightMax - weightMin) + a;
        }
    }

    public static class EpPlusExtensionMethods
    {
        public static int GetColumnByName(this ExcelWorksheet ws, string columnName)
        {
            if (ws == null) throw new ArgumentNullException(nameof(ws));
            return ws.Cells["1:1"].First(c => c.Value.ToString() == columnName).Start.Column;
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class Column : System.Attribute
    {
        public int ColumnIndex { get; set; }


        public Column(int column)
        {
            ColumnIndex = column;
        }
    }

    public static class EPPLusExtensions
    {
        public static IEnumerable<T> ConvertSheetToObjects<T>(this ExcelWorksheet worksheet) where T : new()
        {
            var rows = worksheet.Cells
                .Select(cell => cell.Start.Row)
                .Distinct()
                .OrderBy(x => x);


            var columns = typeof(T)
            .GetProperties()
            .Select(p => new
            {
                Property = p,
                PropertyName = FormatColumn(p.Name)
            }).ToList();


            var headerColumns = Enumerable.Range(1, worksheet.Dimension.Columns)
                                .Select(i => new
                                {
                                    ColumnName = FormatColumn(worksheet.Cells[1, i].Value.ToString()),
                                    Index = i
                                })
                                .ToList();

            //ColumnName index
            Dictionary<string, int> columnsIndexes = new Dictionary<string, int>();
            foreach (var c in headerColumns)
            {
                columnsIndexes.Add(c.ColumnName, c.Index);
            }


            //Create the collection container
            var collection = rows.Skip(1)
                .Select(row =>
                {
                    var tnew = new T();
                    columns.ForEach(col =>
                    {

                        int columnNumber = 0;
                        bool columnExistOnExcel = columnsIndexes.TryGetValue(col.PropertyName, out columnNumber);

                        if (columnExistOnExcel)
                        {
                            var val = worksheet.Cells[row, columnNumber];

                            //If it is numeric it is a double since that is how excel stores all numbers

                            try
                            {
                                if (val.Value == null)
                                {
                                    col.Property.SetValue(tnew, null);
                                    return;
                                }
                                if (col.Property.PropertyType == typeof(Int32))
                                {
                                    col.Property.SetValue(tnew, val.GetValue<int>());
                                    return;
                                }
                                if (col.Property.PropertyType == typeof(Int32?))
                                {
                                    col.Property.SetValue(tnew, val.GetValue<int?>());
                                    return;
                                }
                                if (col.Property.PropertyType == typeof(double))
                                {
                                    col.Property.SetValue(tnew, val.GetValue<double>());
                                    return;
                                }
                                if (col.Property.PropertyType == typeof(DateTime))
                                {
                                    col.Property.SetValue(tnew, val.GetValue<DateTime>());
                                    return;
                                }
                                if (col.Property.PropertyType == typeof(DateTime?))
                                {
                                    try
                                    {
                                        col.Property.SetValue(tnew, val.GetValue<DateTime?>());
                                    }
                                    catch (Exception)
                                    {
                                        CultureInfo provider = CultureInfo.InvariantCulture;
                                        //"26/08/2015 15:00"
                                        try
                                        {
                                            DateTime date = DateTime.ParseExact(val.GetValue<string>(), "dd/MM/yyyy HH:mm", provider);
                                            col.Property.SetValue(tnew, date);

                                        }
                                        catch (Exception)
                                        {
                                            DateTime date = DateTime.ParseExact(val.GetValue<string>(), "dd/MM/yyyy", provider);
                                            col.Property.SetValue(tnew, date);
                                        }

                                    }

                                    return;
                                }
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }


                            //Its a string
                            col.Property.SetValue(tnew, val.GetValue<string>());
                        }
                        else
                        {
                            Console.WriteLine($"Column {col.PropertyName} not found on excel and was ignored");
                        }
                    });

                    return tnew;
                });


            //Send it back
            return collection;
        }

        public static string FormatColumn(string column)
        {
            return Regex.Replace(column, "(/|[0-9])", "").ToLower();
        }
    }
}
