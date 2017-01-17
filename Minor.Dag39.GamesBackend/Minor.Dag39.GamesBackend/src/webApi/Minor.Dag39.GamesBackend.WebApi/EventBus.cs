using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Topology;

namespace Minor.Dag39.GamesBackend.WebApi
{
    public class EventBus
        : IEventBus
    {
        private IAdvancedBus _bus;
        private IExchange _exchange;

        public EventBus()
        {
            _bus = RabbitHutch.CreateBus("host=rabbit").Advanced;
            if (_bus.IsConnected)
            {
                _exchange = _bus.ExchangeDeclare("exchangeName", "topic");
            }
        }
        public IAdvancedBus Bus
        {
            get
            {
                return _bus;
            }
        }

        public IExchange Exchange
        {
            get
            {
                return _exchange;
            }
        }

        public void Dispose()
        {
            Bus.Dispose();
        }
    }
}
