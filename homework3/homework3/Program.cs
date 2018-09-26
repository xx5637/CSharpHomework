using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
    class Program
    {
        public class graph
        {
            public double r;
            public double length1;
            public double length2;
            public double length3;
            public virtual void Setlength()
            {
            }
            public virtual void Setarea()
            {
            }
            public virtual void getarea()
            {
            }
            public graph()
            {
                this.r = 0;
                this.length1 = 0;
                this.length2 = 0;
                this.length3 = 0;
            }
        }
        public class Circle : graph
        {
            double S;
            public override void Setlength()
            {
                Console.Write("Please input the radius of this circle: ");
                try
                {
                    String a = Console.ReadLine();
                    this.r = double.Parse(a);
                }
                catch
                {
                    Console.WriteLine("error!try again ");
                }
            }
            public override void Setarea()
            {
                this.S = r * r * 3.14;

            }
            public override void getarea()
            {
                Setarea();
                Console.WriteLine("The area of this circle is: " + S);
            }
        }
        public class Square : graph
        {
            double S;
            public override void Setlength()
            {
                Console.Write("Please input the length of one side of this square: ");
                try
                {
                    String length = Console.ReadLine();
                    this.length1 = double.Parse(length);
                }
                catch
                {
                    Console.WriteLine("error!try again please");
                }
            }
            public override void Setarea()
            {
                this.S = length1 * length1;

            }
            public override void getarea()
            {
                Setarea();
                Console.WriteLine("The area of this square is: " + S);
            }
        }
        public class Rectangle : graph
        {
            double S;
            public override void Setlength()
            {
                Console.WriteLine("Please input the length(width) of this rectangle: ");
                try
                {
                    String length = Console.ReadLine();
                    this.length1 = double.Parse(length);
                    Console.WriteLine("Please input the length(width) of this rectangle");
                    String width = Console.ReadLine();
                    this.length2 = double.Parse(width);
                }
                catch
                {
                    Console.WriteLine("error!try again!");
                }
            }
            public override void Setarea()
            {
                this.S = length1 * length2;

            }
            public override void getarea()
            {
                Setarea();
                Console.WriteLine("The area of this rectangle is: " + S);
            }
        }
        public class Triangle : graph
        {
            double S;
            double p;
            public override void Setlength()
            {
                try
                {
                    Console.WriteLine("Please input the first length of one side of this triangle: ");
                    Console.WriteLine("Please input the second length of another side of this triangle: ");
                    Console.WriteLine("Please input the last number of the last side of this triangle: ");
                    String a = Console.ReadLine();
                    this.length1 = double.Parse(a);
                    String b = Console.ReadLine();
                    this.length2 = double.Parse(b);
                    String c = Console.ReadLine();
                    this.length3 = double.Parse(c);
                }
                catch
                {
                    Console.WriteLine("error!try again!");
                }
            }
            public override void Setarea()
            {
                if (length1 + length3 > length2 && length1 + length2 > length3 && length2 + length3 > length1)
                {
                    p = (length1 + length2 + length3) / 2;
                }
                else
                {
                    Console.WriteLine("These data can't make a triangle!Retry again");
                    this.length1 = 0;
                    this.length2 = 0;
                    this.length3 = 0;
                    Setlength();
                    Setarea();
                }
            }
            public override void getarea()
            {
                Setarea();
                this.S = Math.Sqrt(p * (p - length1) * (p - length2) * (p - length3));
                Console.WriteLine("The area of this triangle is: " + S);
            }
        }
        public class SimpleFactory
        {
            public graph creategraph(String type)
            {
                graph newgraph = null;
                if (type.Equals("Rectangle"))
                {
                    newgraph = new Rectangle();
                }
                else if (type.Equals("Square"))
                {
                    newgraph = new Square();
                }
                else if (type.Equals("Circle"))
                {
                    newgraph = new Circle();
                }
                else if (type.Equals("Triangle"))
                {
                    newgraph = new Triangle();
                }
                return newgraph;
            }
            public class produce
            {
                SimpleFactory graphmake;
                public produce(SimpleFactory graphmake)
                {
                    this.graphmake = graphmake;
                }
                public void getgraph()
                {
                    try
                    {
                        Console.WriteLine("Please input the type of the graph: Circle,Square,Rectangle or Triangle: ");
                        String type = Console.ReadLine();
                        graph g;
                        g = graphmake.creategraph(type);
                        g.Setlength();
                        g.Setarea();
                        g.getarea();
                    }
                    catch
                    {
                        Console.WriteLine("error!please try again!");
                    }
                }
            }
            static void Main(string[] args)
            {
                SimpleFactory g = new SimpleFactory();
                produce p = new produce(g);
                p.getgraph();
            }
        }
    }
}
