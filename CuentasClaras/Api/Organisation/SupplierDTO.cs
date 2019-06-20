using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuentasClaras.Model;

namespace CuentasClaras.Api.Organisation
{
    public class SupplierDTO
    {
        //TODO: DELETE
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public List<ReleaseDTO> Releases { get; set; }
    }
}
