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
            FindPrimeFactor();
        }
        static void FindPrimeFactor()
        {
            int Num = 1;
            try
            {
                Console.WriteLine("please input an integer：");
                Num = Int32.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("error!please input an integer again \n");
                FindPrimeFactor();
            }
            if (Num == 1)
            {
                Console.WriteLine("1 is not the prime factor,retry again!");
                FindPrimeFactor();
            }
            else
            {
                int primeFactor = 2;
                Console.Write("The prime factors of this integer are：");
                while (primeFactor <= Num)
                {
                    if (Num % primeFactor == 0)
                    {
                        Console.Write(primeFactor + " ");
                        Num = Num / primeFactor;
                    }
                    else
                    {
                        primeFactor++;
                    }
                }
            }
        }
    }
}
