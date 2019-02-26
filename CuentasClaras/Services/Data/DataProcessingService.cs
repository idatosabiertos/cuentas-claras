using CuentasClaras.InputDataModel;
using Microsoft.AspNetCore.Hosting;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CuentasClaras.Services.Data
{
    public class DataProcessingService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public DataProcessingService(IHostingEnvironment hostingEnvironment)
        {
            this._hostingEnvironment = hostingEnvironment;
        }

        public List<T> ItemsFrom<T>(string fileName, string sheetName) where T : new()
        {
            fileName = @"Files\data2018.xlsx";

            FileInfo file = new FileInfo(Path.Combine(_hostingEnvironment.ContentRootPath, fileName));
            if (!file.Exists) {
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
                                .Select(i => new {
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
                                    col.Property.SetValue(tnew, val.GetValue<DateTime?>());
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
                        else {
                            Console.WriteLine($"Column {col.PropertyName} not found on excel and was ignored");
                        }
                    });

                    return tnew;
                });


            //Send it back
            return collection;
        }

        public static string FormatColumn(string column) {
            return Regex.Replace(column, "(/|[0-9])", "").ToLower();
        }
    }
}
