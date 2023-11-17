using System;

namespace task3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int EnterNumber()
            {
                int n;
                bool isParse;
                do
                {
                    isParse = int.TryParse(Console.ReadLine(), out n);
                    if (!isParse) Console.WriteLine("Вы ввели не целое число");
                    else if (n<1) Console.WriteLine("Количество слагаемых не может быть меньше 1");
                }while (!isParse || n<1);

                return n;
            }

            Console.WriteLine("Введите количество слагаемых(>=1)");
            int num = EnterNumber();
            int s = 0;
            for (int i=1; i<=num;i++)
            {
                if (i % 3 == 0) s += -i;
                else s += i;
            }

            Console.WriteLine($"S = {s}");
        }
    }
}