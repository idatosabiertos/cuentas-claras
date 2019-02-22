using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuentasClaras.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public List<String> getSupplier() {
            List<String> ret = new List<string>();

            using (db)
            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "EXEC	TopSuppliers";
                db.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                        ret.Add(result[1].ToString());
                }
            }

            return null;
        }
    }
}