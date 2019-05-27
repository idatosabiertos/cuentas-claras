using CuentasClaras.Api.Organisation;
using CuentasClaras.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CuentasClaras.Controllers
{
    [Route("api/organisation")]
    [ApiController]
    public class OrganisationController : ControllerBase
    {
        private CuentasClarasContext db;

        public OrganisationController(CuentasClarasContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("buyers/search")]
        public List<Buyer> GetBuyers([FromQuery(Name = "name")] String name)
        {
            return db.Buyers.Where(x => x.Name.Contains(name)).ToList();
        }

        [HttpGet]
        [Route("suppliers/search")]
        public List<Supplier> GetSuppliers([FromQuery(Name = "name")] String name)
        {
            return db.Suppliers.Where(x => x.Name.Contains(name)).ToList();
        }

        [HttpGet]
        [Route("suppliers/stats/{id}")]
        public SupplierDTO GetSupplier([FromRoute(Name = "id")] int id)
        {
            var supplier = db.Suppliers
                .Where(s => s.SupplierId == id)
                .Include(x => x.Releases)
                .ThenInclude(r => r.ReleaseItems)
                .SingleOrDefault();

            return SupplierDTO.From(supplier);
        }

        [HttpGet]
        [Route("buyers/stats/{id}")]
        public BuyerDTO GetBuyer([FromRoute(Name = "id")] int id, [FromQuery(Name = "years")] string years)
        {
            var yearsList = years.Split(",");

            var buyer = db.Buyers
                .Where(s => s.BuyerId == id)
                .Include(x => x.Releases)
                    .ThenInclude(r => r.ReleaseItems)
                        .ThenInclude(ri => ri.ReleaseItemClassification)
                .Include(x => x.Releases)
                    .ThenInclude(r => r.Supplier)
                .Include(x => x.OrganisationIndexes)
                .SingleOrDefault();

            /*
            var query = (from b in db.Buyers
                         where b.BuyerId == id
                         select new
                         {
                             BuyerExternalId = b.BuyerExternalId,
                             BuyerId = b.BuyerId,
                             Name = b.Name,
                             Type = b.Type,
                             OrganisationIndexes = from o in db.OrganisationIndexes
                                                   where o.BuyerId == b.BuyerId
                                                   select new OrganisationIndex
                                                   {
                                                       OrganisationId = o.OrganisationId,
                                                       AccumulationOfSuppliersByOrganisation = o.AccumulationOfSuppliersByOrganisation,
                                                       BuyerId = o.BuyerId,
                                                       CompletedInfo = o.CompletedInfo
                                                   },
                             Releases = b.Releases.Where(x => yearsList.Contains(x.DataSource))
                         }).First();*/

            return BuyerDTO.From(buyer, yearsList);
        }

    }
}