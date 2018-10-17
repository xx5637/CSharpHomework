using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class orderprogram
    {
        public class OrderDetails : Object
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
        public class OrderService
        {
            public List<OrderDetails> testList = new List<OrderDetails>();
            public void creatorder()
            {
                OrderDetails order = new OrderDetails();
                Console.WriteLine("input the number of the product：");
                order.num = Console.ReadLine();
                Console.WriteLine("input the name of the product：");
                order.name = Console.ReadLine();
                Console.WriteLine("input the name of the customer：");
                order.customer = Console.ReadLine();
                Console.WriteLine("input the price of the product：");
                order.price = Convert.ToInt32(Console.ReadLine());
                testList.Add(order);
            }
            public void ShowList()
            {
                foreach (OrderDetails order in testList)
                {
                    Console.WriteLine(order.ToString());
                }
            }
            public void Deletelist()
            {
                try
                {
                    Console.WriteLine(" input the number of which one you want to delete：");
                    string num = Console.ReadLine();
                    int n = Convert.ToInt32(num);
                    testList.RemoveAt(n - 1);
                }
                catch
                {
                    Console.WriteLine("error!please retry!");
                    Deletelist();
                }
            }
            public void ChangeList()
            {
                OrderDetails order = new OrderDetails();
                Console.WriteLine("input the number of the product：");
                order.num = Console.ReadLine();
                foreach (OrderDetails o in testList)
                {
                    if (o.num == order.num)
                    {
                        Console.WriteLine("input new product name：");
                        o.name = Console.ReadLine();
                        Console.WriteLine("input new customer：");
                        o.customer = Console.ReadLine();
                        Console.WriteLine("input new price：");
                        o.price = Convert.ToInt32(Console.ReadLine());
                    }
                };
            }
            public void Searchlist()
            {
                OrderDetails order = new OrderDetails();
                Console.WriteLine("choose 1.search for number");
                Console.WriteLine("       2.search for product");
                Console.WriteLine("       3.search for customer");
                Console.WriteLine("       4.search for the product whose price is over 10000");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("input the number：");
                        order.num = Console.ReadLine();
                        var i = from n in testList where n.num == order.num select n;
                        foreach (OrderDetails o in i)
                        {
                            Console.WriteLine(o.ToString());
                        };
                        break;
                    case "2":
                        Console.WriteLine("input the name of the product：");
                        order.name = Console.ReadLine();
                        var j = from n in testList where n.name == order.name select n;
                        foreach (OrderDetails o in j)
                        {
                            Console.WriteLine(o.ToString());
                        }
                        break;
                    case "3":
                        Console.WriteLine("input the name of the customer：");
                        order.customer = Console.ReadLine();
                        foreach (OrderDetails o in testList)
                        {
                            if (order.name == o.name)
                            {
                                Console.WriteLine("number: " + o.num + " product " + o.name + " customer: " + o.customer);
                            }
                        };
                        break;
                    case "4":
                        var k = from n in testList where n.price > 10000 select n;
                        foreach (OrderDetails o in k)
                        {
                            Console.WriteLine(o.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("please choose your operation from 1-4");
                        break;
                }
            }
        }
        public void servicestart(OrderService neworder)
        {
            bool a = true;
            while (a == true)
            {
                Console.WriteLine("choose in the following:" + "\n" + "       1.addorder" + "\n" + "       2.deleteorder" + "\n" + "       3.changeorder" + "\n" + "       4.searchorder" + "\n" + "       5.look at all orders" + "\n" + "       6.Finish");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        neworder.creatorder();
                        break;
                    case "2":
                        neworder.Deletelist();
                        break;
                    case "3":
                        neworder.ChangeList();
                        break;
                    case "4":
                        neworder.Searchlist();
                        break;
                    case "5":
                        neworder.ShowList();
                        break;
                    case "6": a = false; break;
                    default:
                        Console.WriteLine("error!please make a choice from 1-6");
                        break;
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                orderprogram program1 = new orderprogram();
                OrderService order = new OrderService();
                program1.servicestart(order);
            }
        }
    }
}