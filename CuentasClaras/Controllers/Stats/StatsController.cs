using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuentasClaras.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CuentasClaras.Controllers.Stats
{
    [Route("api/stats")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly CuentasClarasContext db;

        public StatsController(CuentasClarasContext db )
        {
            this.db = db;
        }

        [HttpGet]
        public Supplier getSupplier() {
            return null;
        }
    }
}