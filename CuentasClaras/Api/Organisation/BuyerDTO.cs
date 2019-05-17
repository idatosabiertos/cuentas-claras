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
        public double ReleasesQuantity => Releases.Count;
        public List<ReleaseDTO> Releases { get; private set; }
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
                                                   .ToDictionary(x => x.Key ?? "", y => y.Sum(z => z.TotalAmountUYU));
            buyerDTO.SuppliersTotalAmountUYU = buyerReleases.GroupBy(x => x.Supplier.Name)
                                                   .ToDictionary(x => x.Key, y => y.Sum(z => z.TotalAmountUYU));
            var productTypesQuery = buyerReleases.SelectMany(x => x.ReleaseItems)
                                                   .GroupBy(x => x.ReleaseItemClassification.Description);
            buyerDTO.ProductsTypesTotalAmountUYU = productTypesQuery.ToDictionary(x => x.Key, y => y.Sum(z => z.TotalAmountUYU));
            buyerDTO.ProductsTypesQuantity = productTypesQuery.ToDictionary(x => x.Key, y => y.Count());

            buyerDTO.Releases = ReleaseDTO.From(buyerReleases.ToList());
            buyerDTO.OrganisationIndexes = Index.OrganisationIndex.From(buyer.OrganisationIndexes).Where(x => years.Contains(x.Year)).ToList();

            return buyerDTO;
        }
    }
}
