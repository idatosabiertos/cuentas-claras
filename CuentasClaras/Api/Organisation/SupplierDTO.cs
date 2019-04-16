using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CuentasClaras.Model;

namespace CuentasClaras.Api.Organisation
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public List<ReleaseDTO> Releases { get; set; }


        public static SupplierDTO From(Supplier supplier)
        {
            SupplierDTO supplierDTO = new SupplierDTO();
            supplierDTO.ExternalId = supplier.ExternalId;
            supplierDTO.SupplierId = supplier.SupplierId;
            supplierDTO.Name = supplier.Name;
            supplierDTO.Releases = ReleaseDTO.From(supplier.Releases);

            return supplierDTO;
        }
    }
}
