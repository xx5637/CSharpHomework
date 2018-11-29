using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.DataAnnotations;

namespace homework7
{
    public class OrderDetails
    {
        [Key]
        public String num{ get; set; }
        public String name{ get; set; }
        public String customer { get; set; }
        public int price { get; set; }
        public long phone{ get; set; }
        public long order{ get; set; }
        public override string ToString()
        {
            return "The number is:" + num + "\t" + "The product name is：" + name + "\t" + "The customer is：" + customer + "\t" + "the price of the product is：" + price;
        }
    }
}
