using CuentasClaras.Api.Stats;
using CuentasClaras.Model;
using System.Collections.Generic;
using System.Linq;

namespace CuentasClaras.Api.Organisation
{
    public class BuyerDTO
    {
        public string BuyerExternalId { get; internal set; }
        public int BuyerId { get; internal set; }
        public string Name { get; internal set; }
        public double TotalAmountUYU { get; set; }
        public double ReleasesQuantity { get; set; }

        public List<TopGraph> topProductsByQuantity;
        public List<TopGraph> topProductsByTotalAmountUYU;

        public List<Index.OrganisationIndex> OrganisationIndexes { get; private set; }
        public Dictionary<string, double> ReleasesTypes { get; set; }
        public Dictionary<string, int> ProductsTypesTotalAmountUYU { get; set; }
        public Dictionary<string, int> ProductsTypesQuantity { get; set; }
        public Dictionary<string, double> SuppliersTotalAmountUYU { get; set; }

        public static BuyerDTO From(Buyer buyer, string[] years)
        {

            var buyerReleases = buyer.Releases.Where(x => years.Contains(x.DataSource)).ToList();

            BuyerDTO buyerDTO = new BuyerDTO();
            buyerDTO.BuyerExternalId = buyer.BuyerExternalId;
            buyerDTO.BuyerId = buyer.BuyerId;
            buyerDTO.Name = buyer.Name;
            buyerDTO.TotalAmountUYU = buyerReleases.Sum(x => x.TotalAmountUYU);
            buyerDTO.ReleasesTypes = buyerReleases.GroupBy(x => x.TenderProcurementMethodDetails)
                                                   .ToDictionary(x => x.Key ?? "Otros", y => y.Sum(z => z.TotalAmountUYU));
            buyerDTO.SuppliersTotalAmountUYU = buyerReleases.GroupBy(x => x.Supplier.Name)
                                                   .ToDictionary(x => x.Key, y => y.Sum(z => z.TotalAmountUYU));
            var productTypesQuery = buyerReleases.SelectMany(x => x.ReleaseItems)
                                                   .GroupBy(x => x.ReleaseItemClassification.Description);
            buyerDTO.ProductsTypesTotalAmountUYU = productTypesQuery.ToDictionary(x => x.Key, y => y.Sum(z => z.TotalAmountUYU));
            buyerDTO.ProductsTypesQuantity = productTypesQuery.ToDictionary(x => x.Key, y => y.Count());

            var query = buyerReleases
                .SelectMany(x => x.ReleaseItems)
                .Select(x => new TopProductQuery
                {
                    Key = $"{x.ReleaseItemClassificationId}_{x.UnitName}",
                    TotalAmountPerUnit = x.Quantity > 0 ? x.TotalAmountUYU / x.Quantity : 0,
                    TotalAmountUYU = x.TotalAmountUYU,
                    Quantity = x.Quantity,
                    UnitId = x.UnitId,
                    UnitName = x.UnitName,
                    ReleaseItemClassificationId = x.ReleaseItemClassification.ReleaseItemClassificationId,
                    Description = x.ReleaseItemClassification.Description,
                    DescriptionLong = $"{x.ReleaseItemClassification.Description} x {x.UnitName}"
                });

            buyerDTO.topProductsByQuantity = GetBoxedGraph(GetTopProductsByQuantity(query));
            buyerDTO.topProductsByTotalAmountUYU = GetBoxedGraph(GetTopProductsByTotalAmountUYU(query));
            buyerDTO.ReleasesQuantity = ReleaseDTO.From(buyerReleases.ToList()).Count;
            buyerDTO.OrganisationIndexes = Index.OrganisationIndex.From(buyer.OrganisationIndexes).Where(x => years.Contains(x.Year)).ToList();

            return buyerDTO;
        }

        private static IEnumerable<List<TopProductQuery>> GetTopProductsByQuantity(IEnumerable<TopProductQuery> query)
        {
            return query
                    .GroupBy(x => x.Key)
                    .OrderByDescending(x => x.Select(y => y.Quantity).Sum())
                    .Take(10)
                    .Select(x => x.ToList());
        }

        private static IEnumerable<List<TopProductQuery>> GetTopProductsByTotalAmountUYU(IEnumerable<TopProductQuery> query)
        {
            return query
                    .GroupBy(x => x.ReleaseItemClassificationId)
                    .OrderByDescending(x => x.Select(y => y.TotalAmountUYU).Sum())
                    .Take(10)
                    .Select(x => x.ToList());
        }

        private static List<TopGraph> GetBoxedGraph(IEnumerable<List<TopProductQuery>> topItemsClassificationsBy)
        {
            List<TopGraph> topByQuantity = new List<TopGraph>();
            foreach (var item in topItemsClassificationsBy)
            {
                var query = item.OrderBy(x => x.TotalAmountPerUnit).ToList();

                TopGraph t = new TopGraph();
                t.Description = query.First().Description;
                t.DescriptionLong = query.First().DescriptionLong;
                t.Min = query.First().TotalAmountPerUnit;
                t.Max = query.Last().TotalAmountPerUnit;
                t.Mean = query.Average(x => x.TotalAmountPerUnit);

                int iQ1 = query.Count / 4 * 1 - 1;
                int iQ2 = query.Count / 4 * 2 - 1;
                int iQ3 = query.Count / 4 * 3 - 1;

                iQ1 = iQ1 < 0 ? 0 : iQ1;
                iQ2 = iQ2 < 0 ? 0 : iQ2;
                iQ3 = iQ3 < 0 ? 0 : iQ3;

                if (query.Count > 1)
                {
                    t.Q1 = (query[iQ1].TotalAmountPerUnit + query[iQ1 + 1].TotalAmountPerUnit) / 2;
                    t.Median = (query[iQ2].TotalAmountPerUnit + query[iQ2 + 1].TotalAmountPerUnit) / 2;
                    t.Q3 = (query[iQ3].TotalAmountPerUnit + query[iQ3 + 1].TotalAmountPerUnit) / 2;
                }
                else
                {
                    t.Q1 = query[iQ1].TotalAmountPerUnit;
                    t.Median = t.Q1;
                    t.Q3 = t.Q1;
                }

                topByQuantity.Add(t);
            }

            return topByQuantity;
        }
    }
}
