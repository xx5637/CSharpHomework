using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question4
{
    class question4
    {
        static void Main(string[] args)
        {
            double result;
            Console.WriteLine("Please input the first number:");
            string Str1 = Console.ReadLine();
            double Number1 = double.Parse(Str1);
            Console.WriteLine("Please input the second number:");
            string Str2 = Console.ReadLine();
            double Number2 = double.Parse(Str2);
            result = Number1 * Number2;
            Console.WriteLine("The result is:" + result);
        }
    }
}
