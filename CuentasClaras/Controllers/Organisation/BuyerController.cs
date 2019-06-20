using CuentasClaras.Api.Organisation;
using CuentasClaras.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CuentasClaras.Controllers
{
    [Route("api/buyer")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private CuentasClarasContext db;

        public BuyerController(CuentasClarasContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("")]
        [OutputCache(Duration = 600)]
        public List<Buyer> GetBuyers()
        {
            return db.Buyers.ToList();
        }

        [HttpGet]
        [Route("{id}/stats")]
        public BuyerDTO GetBuyer([FromRoute(Name = "id")] int id, [FromQuery(Name = "years")] string years)
        {
            var yearsList = years.Split(",");

            var buyer = db.Buyers
                .Where(s => s.BuyerId == id)
                .Include(x => x.Releases)
                    .ThenInclude(r => r.ReleaseItems)
                        .ThenInclude(ri => ri.ReleaseItemClassification)
                .Include(x => x.Releases)
                    .ThenInclude(r => r.ReleaseItems)
                    .ThenInclude(ri => ri.Supplier)
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