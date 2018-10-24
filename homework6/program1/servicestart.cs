using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class servicestart
    {
        public int Getway { get; set; }
        public void service(OrderService neworder)
        {
            try 
            { 
                neworder.Inxml(); 
            }
            catch 
            {  };
            bool a = true;
            while (a == true)
            {
                Console.WriteLine("choose in the following:" + "\n" + "       1.addorder" + "\n" + "       2.deleteorder" + "\n" + "       3.changeorder" + "\n" + "       4.searchorder" + "\n" + "       5.look at all orders" + "\n" + "       6.Finish");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        neworder.createorder();
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
                    case "6":
                        a = false;
                        break;
                    default:
                        Console.WriteLine("error!please make a choice from 1-6");
                        break;
                }
            }
        }
    }
}
