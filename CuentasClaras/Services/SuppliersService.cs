using CuentasClaras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Services
{
    public class SuppliersService
    {
        public CuentasClarasContext Db { get; }

        public SuppliersService(CuentasClarasContext db)
        {
            Db = db;
        }

        public List<Supplier> GetAll() => this.Db.Suppliers.ToList();
    }
}
