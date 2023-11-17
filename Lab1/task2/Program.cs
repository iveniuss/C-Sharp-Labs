using System;

namespace task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double x, y;
            bool isConvert;
            string buf;
            do
            {
                Console.WriteLine("Введите координату x");
                buf = Console.ReadLine();
                isConvert = double.TryParse(buf, out x);
                if (!isConvert)
                {
                    Console.WriteLine("вы ввели не число");
                }
            } while (!isConvert);
            
            do
            {
                Console.WriteLine("Введите координату y");
                buf = Console.ReadLine();
                isConvert = double.TryParse(buf, out y);
                if (!isConvert)
                {
                    Console.WriteLine("вы ввели не число");
                }
            } while (!isConvert);

            bool isInside = y <= -x + 2 
                            && y >= x - 2 
                            && y <= x + 2 
                            && y >= -x - 2;
            if (isInside)
            {
                Console.WriteLine("Точка внутри области");
            }
            else
            {
                Console.WriteLine("Точка не внутри области");
            }
        }
    }
}