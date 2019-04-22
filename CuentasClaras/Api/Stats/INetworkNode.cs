using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CuentasClaras.Api.Stats
{
    public interface INetworkNode
    {
        string Id { get; }
        string Name { get; }
        double Weight { get; }
        string Type { get; }
        
    }

    public enum NetworkNodeTypes
    {
        Buyer = 1,
        Supplier = 2
    }
}
