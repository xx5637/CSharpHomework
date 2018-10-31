using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework7
{
    public class OrderDetails
    {
        public String num;
        public String name;
        public String customer;
        public int price;
        public override string ToString()
        {
            return "The number is:" + num + "\t" + "The product name is：" + name + "\t" + "The customer is：" + customer + "\t" + "the price of the product is：" + price;
        }
    }
}
