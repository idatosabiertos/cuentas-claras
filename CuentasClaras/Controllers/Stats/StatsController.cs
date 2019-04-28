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
        public List<TopSupplier> GetTopSupplier([FromQuery(Name = "year")] string dataSource)
        {
            List<TopSupplier> ret = new List<TopSupplier>();

            using (db)
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "TopSuppliers";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@datasource", dataSource));

                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var item = new TopSupplier();
                        item.SupplierId = (int)result[0];
                        item.Name = (string)result[1];
                        item.TotalAmount = (double)result[2];
                        item.Quantity = (int)result[3];

                        if (item.TotalAmount > 0)
                            ret.Add(item);
                    }
                }
            }

            return ret;
        }

        [HttpGet]
        [Route("top-buyers")]
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
                        item.TotalAmount = (double)result[2];
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
                        item.TotalAmount = (double)result[2];

                        if (item.TotalAmount > 0)
                            ret.Add(item);
                    }
                }
            }

            return ret;
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
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "NetworkEdges";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@datasource", dataSource));

                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            var item = new NetworkEdge();
                            item.BuyerId = ((int)result[0]).ToString();
                            item.SupplierId = (int)result[1];
                            networkEdge.Add(item);
                        }
                    }
                }
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
                            item.TotalAmountUYU = (double)result[3];
                            if (item.TotalAmountUYU >= 0)
                                networkBuyer.Add(item);
                        }
                    }
                }

                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "NetworkSuppliers";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@datasource", dataSource));

                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            var item = new NetworkSupplier();
                            item.SupplierId = (int)result[0];
                            item.Name = (string)result[1];
                            item.TotalAmountUYU = (double)result[2];

                            if (item.TotalAmountUYU >= 0)
                                networkSupplier.Add(item);
                        }
                    }
                }
            }

            var nodes = networkSupplier.Cast<INetworkNode>().Concat(networkBuyer.Cast<INetworkNode>());
            this.dataProccessingService.ExportFile($"network-{migrationConfig.DataSource}.xlsx", nodes, networkEdge);

            return new { suppliers = networkSupplier, buyers = networkBuyer, edges = networkEdge };
        }
    }
}