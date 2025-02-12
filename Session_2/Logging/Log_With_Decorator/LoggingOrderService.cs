using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log_With_Decorator
{
    public class LoggingOrderService : IOrderService
    {
        private readonly IOrderService _inner;
        private readonly ILogger<LoggingOrderService> _logger;

        public LoggingOrderService(IOrderService inner, ILogger<LoggingOrderService> logger)
        {
            _inner = inner;
            _logger = logger;
        }
        public void ProcessOrder(int orderId)
        {
            _logger.LogInformation("Starting order processing for order {OrderId}", orderId);
            _inner.ProcessOrder(orderId);
            _logger.LogInformation("Completed order processing for order {OrderId}", orderId);
        }
    }
}