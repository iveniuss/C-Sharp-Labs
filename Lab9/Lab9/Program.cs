
using System;

namespace Lab9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Post p1 = new Post();
            Post p2 = new Post(573,174, 70);
            Post p3 = new Post(p2);
            p3 = !p3;
            ++p3;
            Console.WriteLine("p1 - " + (Post)p1);
            Console.WriteLine("коэффициент вовлеченности - "+(double)p1);
            Console.WriteLine("p2 - " + (Post)p2);
            Console.WriteLine("коэффициент вовлеченности - " + (double)p1);
            Console.WriteLine("p3 - " + (Post)p3);
            Console.WriteLine("коэффициент вовлеченности - " + (double)p1);
            Console.WriteLine("Всего создано объектов:" + Post.ObjNum);

            PostCollection psts1 = new PostCollection();
            PostCollection psts2 = new PostCollection(3);
            PostCollection psts3 = new PostCollection(1,true);
            PostCollection psts4 = new PostCollection(psts2);
            ++psts4[1];
            psts4[1] = !psts4[1];
            Console.WriteLine("psts3[1] - " + (Post)psts4[1]);
            try
            {
                psts4[5]++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                Console.WriteLine(psts4[4]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("psts1:");
            psts1.Show();
            Console.WriteLine("psts2:");
            psts2.Show();
            Console.WriteLine("psts3:");
            psts3.Show();
            Console.WriteLine("psts4:");
            psts4.Show();





        }

    }
}