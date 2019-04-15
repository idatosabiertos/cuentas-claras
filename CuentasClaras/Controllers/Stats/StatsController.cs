using CuentasClaras.Api.Codes;
using CuentasClaras.Api.Stats;
using CuentasClaras.Model;
using CuentasClaras.Services.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                        item.TotalAmount = (double)result[2];

                        if (item.TotalAmount > 0)
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
                            item.BuyerId = ((int)result[0]).ToString();
                            item.SupplierId = (int)result[1];
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
                            item.BuyerId = (string)result[0];
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

            var nodes = networkSupplier.Cast<INetworkNode>().Concat(networkBuyer.Cast<INetworkNode>());
            this.dataProccessingService.ExportFile("prueba1.xlsx", nodes, networkEdge);

            return new { suppliers = networkSupplier, buyers = networkBuyer, edges = networkEdge };
        }

        [HttpGet]
        [Route("network-long-grouping")]
        public object GetNetworkLong()
        {
            List<NetworkEdge> networkEdge = new List<NetworkEdge>();
            List<NetworkBuyer> networkBuyer = new List<NetworkBuyer>();
            List<NetworkSupplier> networkSupplier = new List<NetworkSupplier>();

            //  using (db)
            //  {
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC	NetworkEdges";
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
                command.CommandText = "EXEC	NetworkBuyers";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var item = new NetworkBuyer();
                        int buyerId = (int)result[0];
                        item.BuyerId = buyerId.ToString();
                        item.Name = (string)result[1];
                        item.TotalAmountUYU = (double)result[2];
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
                        item.TotalAmountUYU = (double)result[2];
                        networkSupplier.Add(item);
                    }
                }
            }
            //}

            List<NetworkBuyer> networkBuyerGrouped = new List<NetworkBuyer>();
            //using (db)
            //{
            foreach (var b in networkBuyer)
            {
                #region GROUPING LOGIC
                int buyerId = Convert.ToInt32(b.BuyerId);
                var currentBuyer = db.Buyers.Find(buyerId);
                int section = Convert.ToInt32(currentBuyer.BuyerExternalId.Split('-')[1]);

                if (TranslatorSectionToGroupingCode.LongList.ContainsKey(section))
                {
                    string sectionId = $"SECTION-{TranslatorSectionToGroupingCode.LongList[section]}";

                    var buyer = networkBuyerGrouped.Where(x => x.BuyerId == sectionId).FirstOrDefault();
                    if (buyer == null)
                    {
                        b.BuyerId = sectionId;
                        b.Name = GroupingCodesLongList.Items[TranslatorSectionToGroupingCode.LongList[section]];
                        networkBuyerGrouped.Add(b);
                    }
                    else
                    {
                        buyer.TotalAmountUYU += b.TotalAmountUYU;
                    }

                    foreach (var item in networkEdge)
                    {
                        if (item.BuyerId == buyerId.ToString())
                        {
                            item.BuyerId = sectionId;
                        }
                    }
                }
                else
                {
                    networkBuyerGrouped.Add(b);
                }
                #endregion
            }
            //}

            var nodes = networkSupplier.Cast<INetworkNode>().Concat(networkBuyerGrouped.Cast<INetworkNode>());
            this.dataProccessingService.ExportFile("long-list.xlsx", nodes, networkEdge);

            return new { suppliers = networkSupplier, buyers = networkBuyer, edges = networkEdge };
        }

        [HttpGet]
        [Route("network-short-grouping")]
        public object GetNetworkShort()
        {
            List<NetworkEdge> networkEdge = new List<NetworkEdge>();
            List<NetworkBuyer> networkBuyer = new List<NetworkBuyer>();
            List<NetworkSupplier> networkSupplier = new List<NetworkSupplier>();

            //  using (db)
            //  {
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC	NetworkEdges";
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
                command.CommandText = "EXEC	NetworkBuyers";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var item = new NetworkBuyer();
                        int buyerId = (int)result[0];
                        item.BuyerId = buyerId.ToString();
                        item.Name = (string)result[1];
                        item.TotalAmountUYU = (double)result[2];
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
            //}

            List<NetworkBuyer> networkBuyerGrouped = new List<NetworkBuyer>();
            //using (db)
            //{
            foreach (var b in networkBuyer)
            {
                #region GROUPING LOGIC
                int buyerId = Convert.ToInt32(b.BuyerId);
                var currentBuyer = db.Buyers.Find(buyerId);
                int section = Convert.ToInt32(currentBuyer.BuyerExternalId.Split('-')[1]);

                if (TranslatorSectionToGroupingCode.ShortList.ContainsKey(section))
                {
                    string sectionId = $"SECTION-{TranslatorSectionToGroupingCode.ShortList[section]}";

                    var buyer = networkBuyerGrouped.Where(x => x.BuyerId == sectionId).FirstOrDefault();
                    if (buyer == null)
                    {
                        b.BuyerId = sectionId;
                        b.Name = GroupingCodesLongList.Items[TranslatorSectionToGroupingCode.ShortList[section]];
                        networkBuyerGrouped.Add(b);
                    }
                    else
                    {
                        buyer.TotalAmountUYU += b.TotalAmountUYU;
                    }

                    foreach (var item in networkEdge)
                    {
                        if (item.BuyerId == buyerId.ToString())
                        {
                            item.BuyerId = sectionId;
                        }
                    }
                }
                else
                {
                    networkBuyerGrouped.Add(b);
                }
                #endregion
            }
            //}

            var nodes = networkSupplier.Cast<INetworkNode>().Concat(networkBuyerGrouped.Cast<INetworkNode>());
            this.dataProccessingService.ExportFile("short-list.xlsx", nodes, networkEdge);

            return new { suppliers = networkSupplier, buyers = networkBuyer, edges = networkEdge };
        }
    }
}