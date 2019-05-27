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
    }
}