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
        decimal Weight { get; }
    }
}
