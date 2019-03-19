using CuentasClaras.Api.Stats;
using CuentasClaras.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CuentasClaras.Controllers.Stats
{
    [Route("api/stats")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly CuentasClarasContext db;

        public StatsController(CuentasClarasContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("top-suppliers")]
        public List<TopSupplier> GetTopSupplier()
        {
            List<TopSupplier> ret = new List<TopSupplier>();

            using (db)
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC	TopSuppliers";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var item = new TopSupplier();
                        item.SupplierId = (int)result[0];
                        item.Name = (string)result[1];
                        item.TotalAmount = (int)result[2];
                        item.Quantity = (int)result[3];
                        ret.Add(item);
                    }
                }
            }

            return ret;
        }

        [HttpGet]
        [Route("top-buyers")]
        public List<TopBuyer> GetTopBuyers()
        {
            List<TopBuyer> ret = new List<TopBuyer>();

            using (db)
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC	TopBuyers";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var item = new TopBuyer();
                        item.BuyerId = (int)result[0];
                        item.Name = (string)result[1];
                        item.TotalAmount = (int)result[2];
                        item.Quantity = (int)result[3];
                        ret.Add(item);
                    }
                }
            }

            return ret;
        }

        [HttpGet]
        [Route("top-items")]
        public List<TopItemClassification> GetTopItemClassification()
        {
            List<TopItemClassification> ret = new List<TopItemClassification>();

            using (db)
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC	TopItemClassification";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var item = new TopItemClassification();
                        item.ReleaseItemClassificationId = (int)result[0];
                        item.Description = (string)result[1];
                        item.TotalAmount = (int)result[2];
                        ret.Add(item);
                    }
                }
            }

            return ret;
        }

        [HttpGet]
        [Route("network")]
        public object GetNetwork()
        {
            List<NetworkEdge> networkEdge = new List<NetworkEdge>();
            List<NetworkBuyer> networkBuyer = new List<NetworkBuyer>();
            List<NetworkSupplier> networkSupplier = new List<NetworkSupplier>();

            using (db)
            {
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "EXEC	NetworkEdges";
                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            var item = new NetworkEdge();
                            item.SupplierId = (int)result[0];
                            item.BuyerId = (int)result[1];
                            networkEdge.Add(item);
                        }
                    }
                }
                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "EXEC	NetworkBuyers";
                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            var item = new NetworkBuyer();
                            item.BuyerId = (int)result[0];
                            item.Name = (string)result[1];
                            item.TotalAmountUYU = (int)result[2];
                            networkBuyer.Add(item);
                        }
                    }
                }

                using (var command = db.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "EXEC	NetworkSuppliers";
                    db.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            var item = new NetworkSupplier();
                            item.SupplierId = (int)result[0];
                            item.Name = (string)result[1];
                            item.TotalAmountUYU = (int)result[2];
                            networkSupplier.Add(item);
                        }
                    }
                }
            }


            return new { suppliers = networkSupplier, buyers = networkBuyer, edges = networkEdge };
        }
    }
}