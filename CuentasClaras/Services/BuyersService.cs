using CuentasClaras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Services
{
    public class BuyersService
    {
        public CuentasClarasContext Db { get; }

        public BuyersService(CuentasClarasContext db)
        {
            Db = db;
        }

        public List<Buyer> GetAll() => this.Db.Buyers.ToList();
    }
}
