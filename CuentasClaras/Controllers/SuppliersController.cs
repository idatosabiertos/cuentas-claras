using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuentasClaras.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuentasClaras.Controllers
{
    [Route("api/suppliers")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly CuentasClarasContext db;

        public SuppliersController(CuentasClarasContext db )
        {
            this.db = db;
        }

        [HttpGet]
        public Supplier getSupplier() {
            return db.Suppliers.First();
        }
    }
}