using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class list
    {
        public void GetOrder(OrderDetails order)
        {
            order.num = Console.ReadLine();
            order.name = Console.ReadLine();
            order.customer = Console.ReadLine();
            order.price = Convert.ToInt32(Console.ReadLine());
        }
    }
}
