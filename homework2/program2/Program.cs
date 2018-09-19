using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            getarraydata();
        }
        static void getarraydata()
        {
            int size = 0;
            try
            {
                Console.WriteLine("please input how many integers you will input：");
                size = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("error！please retry again!\n");
                getarraydata();
            }
            if (size == 0)
            {
                Console.WriteLine("error！please retry again!\n");
                getarraydata();
            }
            int[] Array = new int[size];
            Console.WriteLine("please input the integers：");
            for (int i = 0; i < size; i++)
            {
                try
                {
                    Array[i] = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("error!please retry again!\n");
                    i--;
                }
            }//获得array数组
            //求最大值
            int Max = Array[0];
            foreach (int integer in Array)
            {
                if (integer >= Max)
                {
                    Max = integer;
                }
            }
            //求最小值
            int Min = Array[0];
            foreach (int integer in Array)
            {
                if (integer <= Min)
                {
                    Min = integer;
                }
            }
            //求和
            int Sum = 0;
            foreach (int integer in Array)
            {
                Sum += integer;
            }
            //求平均值
            double asum = Sum;
            double average = asum / Array.Length;
            Console.WriteLine("输入的数据的最大值，最小值，和以及平均数分别为：" + Max + " " + Min + " " + Sum + " " + average);
        }

    }
}
