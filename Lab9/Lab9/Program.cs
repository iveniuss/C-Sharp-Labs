
using System;

namespace Lab9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Post post1 = new Post();
            Post post2 = new Post(353, 151, 173);
            Post post3 = new Post(post2);
            Post post4 = new Post(post3);
            post3 = !post3;
            post3++;
            Console.WriteLine(post2.ToString());
            Console.WriteLine((double)post2);
            Console.WriteLine(post3.ToString());
            Console.WriteLine((double)post3);
            Console.WriteLine(post2==post3);
        }
        
    }
}