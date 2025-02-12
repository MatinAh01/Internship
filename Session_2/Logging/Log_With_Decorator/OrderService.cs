using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log_With_Decorator
{
    public class OrderService : IOrderService
    {
        private readonly ILogger<OrderService> _logger;

        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }
        public void ProcessOrder(int orderId)
        {
            // without using decorator
            // _logger.LogInformation("Start processing order {OrderId}", orderId);

            // /* business logic
            //  {

            //  }*/

            //  _logger.LogInformation("Finished processing order {OrderId}", orderId);





            // with decorator pattern
            // /* business logic
            //  {

            //  }*/
        }
    }
}