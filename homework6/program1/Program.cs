using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            servicestart program1 = new servicestart();
            OrderService order = new OrderService();
            program1.service(order);
        }
    }
}
       