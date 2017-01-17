using EasyNetQ;
using EasyNetQ.Topology;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.GamesBackend.WebApi
{
    public interface IEventBus
        :IDisposable
    {
        IAdvancedBus Bus { get; }
        IExchange Exchange { get;  }
    }    
}
