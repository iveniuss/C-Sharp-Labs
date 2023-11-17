using System;

namespace task1
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
                }while (!isParse);

                return n;
            }

            int sum = 0;
            int k;
            Console.WriteLine("Введите длину последовательности(>=2)");
            do
            {
                k = EnterNumber();
                if (k<2) Console.WriteLine("Длина последовательности не может быть меньше 2");
            } while (k < 2);
            
            for (int i = 1; i <= k; i++)
            {
                Console.WriteLine("Введите целое число");
                int num = EnterNumber();
                if (i % 2 == 0)
                {
                    sum += num;
                }

            }

            Console.WriteLine($"Сумма элементов с четным номером = {sum}");
                
        }
    }
}