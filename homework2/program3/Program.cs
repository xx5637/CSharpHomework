using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList array = new ArrayList();
            for (int i = 2; i <= 100; i++)
            {
                array.Add(i);
            }
            for (int i = 2; i <= 100; i++)
            {
                for (int j = 2; j <= 100; j++)
                {
                    if (j > i&& j % i == 0)
                    {
                        array.Remove(j);
                    }
                }

            }
            Console.WriteLine("2-100之间的素数为:");
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(array[i]+" ");
            }
        }
    }
}
