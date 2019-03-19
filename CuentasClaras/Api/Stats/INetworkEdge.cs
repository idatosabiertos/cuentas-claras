using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public interface INetworkEdge
    {
        string FromId { get; }
        string ToId { get; }
    }
}
