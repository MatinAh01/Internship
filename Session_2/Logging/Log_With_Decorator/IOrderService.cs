using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log_With_Decorator
{
    public interface IOrderService
    {
        void ProcessOrder(int orderId);
    }
}