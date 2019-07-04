using CuentasClaras.Api.Migration;
using CuentasClaras.Api.Stats;
using CuentasClaras.Model;
using CuentasClaras.Services.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CuentasClaras.Controllers.Stats
{
    [Route("api/stats")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly CuentasClarasContext db;
        private readonly DataProcessingService dataProccessingService;

        public StatsController(CuentasClarasContext db, DataProcessingService dataProcessingService)
        {
            this.db = db;
            this.dataProccessingService = dataProcessingService;
        }

        [HttpGet]
        [Route("top-suppliers")]
        [OutputCache(Duration = 600, VaryByParam = "year")]
        public List<TopSupplier> GetTopSupplier([FromQuery(Name = "year")] string dataSource)
        {
            using (db)
            {
                List<TopSupplier> topSuppliers = new List<TopSupplier>();
                var releaseItems = db.ReleaseItems
                        .Include(x => x.Supplier)
                        .Include(x => x.Release)
                        .Where(x => x.Release.DataSource == dataSource)
                        .Select(x => new { x.TotalAmountUYU, x.Supplier.Name, x.SupplierId, x.ReleaseId })
                        .ToList();

                return releaseItems
                .GroupBy(x => x.Name, x => x)
                .Select(x => new TopSupplier
                {
                    Name = x.Key,
                    TotalAmount = x.Sum(y => y.TotalAmountUYU),
                    Quantity = x.Select(y => y.ReleaseId).Distinct().Count(),
                    SupplierId = x.First().SupplierId
                })
                .OrderByDescending(x => x.TotalAmount)
                .ToList();
            }
        }

        [HttpGet]
        [Route("top-buyers")]
        [OutputCache(Duration = 600, VaryByParam = "year")]
        public List<TopBuyer> GetTopBuyers([FromQuery(Name = "year")] string dataSource)
        {
            List<TopBuyer> ret = new List<TopBuyer>();

            using (db)
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "TopBuyers";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@datasource", dataSource));

                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var item = new TopBuyer();
                        item.BuyerId = (int)result[0];
                        item.Name = (string)result[1];
                        item.TotalAmount = (decimal)result[2];
                        item.Quantity = (int)result[3];

                        if (item.TotalAmount > 0)
                            ret.Add(item);
                    }
                }
            }

            return ret;
        }

        [HttpGet]
        [Route("top-items")]
        [OutputCache(Duration = 600, VaryByParam = "year")]
        public List<TopItemClassification> GetTopItemClassification([FromQuery(Name = "year")] string dataSource)
        {
            List<TopItemClassification> ret = new List<TopItemClassification>();

            using (db)
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "TopItemClassification";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@datasource", dataSource));

                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var item = new TopItemClassification();
                        item.ReleaseItemClassificationId = (int)result[0];
                        item.Description = (string)result[1];
                        item.TotalAmount = (decimal)result[2];

                        if (item.TotalAmount > 0)
                            ret.Add(item);
                    }
                }
            }

            return ret;
        }

        [HttpGet]
        [Route("items-classification/{id}")]
        public ItemClassification GetItemClassificationStats([FromRoute(Name = "id")] int id)
        {
            using (db)
            {
                ReleaseItemClassification item = db.ReleaseItemClassifications.Where(i => i.ReleaseItemClassificationId == id)
                                                .Include(x => x.ReleaseItems)
                                                    .ThenInclude(r => r.Release)
                                                    .ThenInclude(b => b.Buyer)
                                                .Include(s => s.ReleaseItems)
                                                    .ThenInclude(s => s.Supplier)
                                                .FirstOrDefault();

                ItemClassification ret = new ItemClassification();
                ret.Description = item.Description;
                ret.ReleaseItemClassificationExternalId = item.ReleaseItemClassificationExternalId;
                ret.ReleaseItemClassificationId = item.ReleaseItemClassificationId;
                ret.ReleaseItems = new Dictionary<string, Dictionary<string, List<ItemClassificationDetail>>>();


                var yearGroups = item.ReleaseItems.GroupBy(y => y.Release.DataSource);
                foreach (var gYear in yearGroups)
                {
                    ret.ReleaseItems.Add(gYear.Key, new Dictionary<string, List<ItemClassificationDetail>>());



                    var unitGroups = gYear.GroupBy(x => x.UnitName);
                    foreach (var gUnit in unitGroups)
                    {
                        var items = gUnit.Select(x => new ItemClassificationDetail()
                        {
                            CurrencyCode = x.CurrencyCode,
                            Description = x.Description,
                            ExternalId = x.ExternalId,
                            Quantity = x.Quantity,
                            ReleaseId = x.ReleaseId,
                            ReleaseItemId = x.ReleaseItemId,
                            TotalAmountUYU = x.TotalAmountUYU,
                            UnitValueAmountUYU = x.UnitValueAmountUYU,
                            UnitId = x.UnitId,
                            UnitName = x.UnitName,
                            UnitValueAmount = x.UnitValueAmount,
                            //SupplierName = x.Release.Supplier.Name,
                            //SupplierId = x.Release.Supplier.SupplierId,
                            BuyerName = x.Release.Buyer.Name,
                            BuyerId = x.Release.Buyer.BuyerId
                        }).ToList();

                        ret.ReleaseItems[gYear.Key].Add(gUnit.Key, items);
                    }

                }





                return ret;
            }
        }

        [HttpGet]
        [Route("items-classification")]
        [OutputCache(Duration = 600)]
        public List<ReleaseItemClassification> GetItemClassification()
        {
            using (db)
            {
                return db.ReleaseItemClassifications.OrderBy(x => x.Description).ToList();
            }
        }

        private class ReleaseTypeDTO
        {
            public Dictionary<string, decimal> releasesTypesByTotalAmountUYU { get; set; }
            public Dictionary<string, int> releasesTypesByQuantity { get; set; }
        }

        [HttpGet]
        [Route("releases-types")]
        [OutputCache(Duration = 600)]
        public object GetReleasesTypes()
        {
            using (db)
            {
                Dictionary<string, ReleaseTypeDTO> res = db.Releases.Select(x => x.DataSource).Distinct().ToDictionary(x => x, y => new ReleaseTypeDTO());
                foreach (var item in res)
                {
                    string year = item.Key;

                    res[year].releasesTypesByTotalAmountUYU = db.Releases
                                                      .Where(x => x.DataSource == year)
                                                      .GroupBy(x => x.TenderProcurementMethodDetails)
                                                      .Select(x => new
                                                      {
                                                          key = x.Key,
                                                          sum = x.Sum(y => y.TotalAmountUYU)
                                                      })
                                                      .ToDictionary(x => x.key ?? "Otros", y => y.sum);
                    res[year].releasesTypesByQuantity = db.Releases
                                                .Where(x => x.DataSource == year)
                                                .GroupBy(x => x.TenderProcurementMethodDetails)
                                                .Select(x => new
                                                {
                                                    key = x.Key,
                                                    quantity = x.Count()
                                                })
                                                .ToDictionary(x => x.key ?? "Otros", y => y.quantity);

                }

                return res;
            }
        }


        [HttpPost]
        [Route("network")]
        public object GetNetwork([FromBody] MigrationConfig migrationConfig)
        {
            string dataSource = migrationConfig.DataSource;

            List<NetworkEdge> networkEdge = new List<NetworkEdge>();
            List<NetworkBuyer> networkBuyer = new List<NetworkBuyer>();
            List<NetworkSupplier> networkSupplier = new List<NetworkSupplier>();

            using (db)
            {
                networkEdge = db.ReleaseItems
                                .Include(x => x.Release)
                                  .ThenInclude(x => x.Buyer)
                                .Include(x => x.Supplier)
                                .Where(x => x.Release.DataSource == dataSource && x.TotalAmountUYU > 0)
                                .Select(x => new
                                {
                                    BuyerId = x.Release.BuyerId.GetValueOrDefault(),
                                    SupplierId = x.SupplierId
                                })
                                .Distinct()
                                .Select(x => new NetworkEdge()
                                {
                                    BuyerId = x.BuyerId,
                                    SupplierId = x.SupplierId
                                }).ToList();

                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "NetworkBuyers";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@datasource", dataSource));

                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            var item = new NetworkBuyer();
                            item.BuyerId = ((int)result[0]).ToString();
                            item.Name = (string)result[1];
                            item.Type = (string)result[2];
                            item.TotalAmountUYU = (decimal)result[3];
                            if (item.TotalAmountUYU >= 0)
                                networkBuyer.Add(item);
                        }
                    }
                }


                networkSupplier = db.ReleaseItems
                                    .Include(x => x.Supplier)
                                    .Include(x => x.Release)
                                    .Where(x => x.Release.DataSource == dataSource && x.TotalAmountUYU >= 0)
                                    .GroupBy(x => new { x.SupplierId, x.Supplier.Name }, y => y)
                                    .Select(x => new NetworkSupplier()
                                    {
                                        Name = x.Key.Name,
                                        SupplierId = x.Key.SupplierId,
                                        TotalAmountUYU = x.Sum(y => y.TotalAmountUYU)
                                    })
                                    .Where(x => x.TotalAmountUYU > 0)
                                    .ToList();

            }

            var nodes = networkSupplier.Cast<INetworkNode>().Concat(networkBuyer.Cast<INetworkNode>());
            this.dataProccessingService.ExportFile($"network-{migrationConfig.DataSource}.xlsx", nodes, networkEdge);

            return new { suppliers = networkSupplier, buyers = networkBuyer, edges = networkEdge };
        }

        [HttpGet]
        [Route("index")]
        [OutputCache(Duration = 600, VaryByParam = "year")]
        public List<Api.Index.OrganisationIndex> GetIndex([FromQuery(Name = "year")] string year)
        {
            return this.db.OrganisationIndexes.Where(x => x.Year == year)
                .ToList()
                .Select(x => Api.Index.OrganisationIndex.From(x))
                .OrderByDescending(x => x.PerformanceIndex)
                .ToList();
        }
    }
}