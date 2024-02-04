
using System;

namespace Lab9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IO.WriteDividerLine("Создание объектов");
            Post p1 = new Post();
            Post p2 = new Post(345, 234, 123);
            Post p3 = new Post(p2);
            Console.WriteLine("p1 (Контруктор без параметров):\n" + (Post)p1);
            Console.WriteLine("p2 (Контруктор с параментрами 345,234,123):\n" + (Post)p2);
            Console.WriteLine("p3 (Конструктор копирования p2):\n" + (Post)p3);
            IO.WriteDividerLine("Коэфициент вовлеченности");
            Console.WriteLine("метод класса(p3):");
            Console.WriteLine(p3.EngRate());
            Console.WriteLine("Статическая функция");
            Console.WriteLine(Post.EngRateStatic(p3));
            IO.WriteDividerLine("Операторы");
            Console.WriteLine("++ - Увеличение кол-ва просмотров");
            p3++;
            Console.WriteLine("p3++: " + (Post)p3);
            Console.WriteLine("! - Увеличение кол-ва реакций");
            p3 = !p3;
            Console.WriteLine("p3=!p3: " + (Post)p3);
            Console.WriteLine("== - равенство");
            Console.Write("p2==p3 - ");
            Console.WriteLine(p2 == p3);
            Console.WriteLine("!= - равенство");
            Console.Write("p2!=p3 - ");
            Console.WriteLine(p2 != p3);
            IO.WriteDividerLine("Преобразования");
            Console.Write("(bool)p3 - ");
            Console.WriteLine((bool)p3);
            Console.Write("(double)p3 - ");
            Console.WriteLine((double)p3);
            IO.WriteDividerLine("Создание коллекций");
            PostCollection posts1 = new PostCollection();
            PostCollection posts2 = new PostCollection(3);
            Console.WriteLine("posts1 (Конструктор без параметров)\n" + posts1);
            Console.WriteLine("posts2 (Конструктор случайной генерации)(размер - 3)\n" + posts2);
            Console.WriteLine("posts3 (Конструктор для ввода с клавиаутры)(размер - 2)");
            Post[] values = { new Post ( IO.EnterIntNumber("Введите просмотры"),
                                         IO.EnterIntNumber("Введите комментарии"),
                                         IO.EnterIntNumber("Введите рекации")),
                              new Post ( IO.EnterIntNumber("Введите просмотры"),
                                         IO.EnterIntNumber("Введите комментарии"),
                                         IO.EnterIntNumber("Введите рекации"))};
            PostCollection posts3 = new PostCollection(values);
            Console.WriteLine("posts3: \n" + posts3);
            IO.WriteDividerLine("Коэффициент вовлечения в коллекции");
            Console.Write("posts2 - ");
            Console.WriteLine(posts2.EngRate());
            Console.Write("posts3 - ");
            Console.WriteLine(posts3.EngRate());
            IO.WriteDividerLine("Всего создано объектов и коллекций");
            Console.Write("Объектов (Включая те, что в коллекциях): ");
            Console.WriteLine(Post.ObjNum);
            Console.Write("Коллекций:");
            Console.WriteLine(PostCollection.ColNum);
        }

    }
}