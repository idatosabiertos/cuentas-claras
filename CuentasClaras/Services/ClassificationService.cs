using CuentasClaras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Services
{
    public class ClassificationService
    {
        public CuentasClarasContext Db { get; }

        public ClassificationService(CuentasClarasContext db)
        {
            Db = db;
        }

        public List<ReleaseItemClassification> GetAll() => this.Db.ReleaseItemClassifications.ToList();
    }
}
