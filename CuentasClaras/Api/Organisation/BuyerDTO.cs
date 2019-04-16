using CuentasClaras.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Organisation
{
    public class BuyerDTO
    {
        public string BuyerExternalId { get; internal set; }
        public int BuyerId { get; internal set; }
        public string Name { get; internal set; }
        public List<ReleaseDTO> Releases { get; private set; }

        public static BuyerDTO From(Buyer buyer) {
            BuyerDTO buyerDTO = new BuyerDTO();
            buyerDTO.BuyerExternalId = buyer.BuyerExternalId;
            buyerDTO.BuyerId = buyer.BuyerId;
            buyerDTO.Name = buyer.Name;
            buyerDTO.Releases = ReleaseDTO.From(buyer.Releases);

            return buyerDTO;
        }
    }
}
