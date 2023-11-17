using System;

namespace task1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double n, m;
            string buf;
            bool isConvert;
            double x;
            do
            {
                Console.WriteLine("Введите вещественное число n");
                buf = Console.ReadLine();
                isConvert = double.TryParse(buf, out n);
                if (!isConvert)
                {
                    Console.WriteLine("вы ввели не число");
                }
            } while (!isConvert);
            do
            {
                Console.WriteLine("Введите вещественное число m");
                buf = Console.ReadLine();
                isConvert = double.TryParse(buf, out m);
                if (!isConvert)
                {
                    Console.WriteLine("вы ввели не число");
                }
            } while (!isConvert);
            
            double res1 = m-- - n;
            Console.WriteLine($"m-- -n = {res1}, n={n}, m={m}");

            bool res2 = m++ < n;
            Console.WriteLine($"m++ < n = {res2}, n = {n}, m = {m}");

            bool res3 = n++ > m;
            Console.WriteLine($"n++ > m = {res3}, n = {n}, m = {m}");
            
            do
            {
                Console.WriteLine("Введите вещественное число x");
                buf = Console.ReadLine();
                isConvert = double.TryParse(buf, out x);
                if (!isConvert)
                {
                    Console.WriteLine("вы ввели не вещественное число");
                }
            } while (!isConvert);
            
            if (Math.Abs(x) > 1)
            {
                Console.WriteLine("нельзя вычислить");
            }
            else
            {
                double res4 = Math.Pow(x,4) - Math.Cos(Math.Asin(x));
                Console.WriteLine($"x^4 - cos(arcsin(x)) = {res4}");
            }
            
        }
    }
}