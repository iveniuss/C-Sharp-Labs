using System;

namespace task2
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

            int num,firstNum;
            int k = 0;
            firstNum = 0;
            Console.WriteLine("Вводите последовательность по одному числу(0 - завершение ввода)");
            do
            {
                num = EnterNumber();
                if (num != 0) 
                    firstNum = num;
                else Console.WriteLine("Первое число не может быть 0");
            } while (num == 0);

            do
            {
                Console.WriteLine("Введите целое число");
                num = EnterNumber();
                if (num != 0 && num % firstNum == 0) 
                    k++;
            } while (num != 0);

            Console.WriteLine($"Количество чисел последовательности кратных {firstNum} - {k} ");
        }
    }
}