using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    internal class IO
    {
        public static int EnterIntNumber(string message = "Введите целое число", int lowerBound = int.MinValue, int upperBound = int.MaxValue)
        {
            int number;
            bool isParse;
            do
            {
                Console.WriteLine(message);
                isParse = int.TryParse(Console.ReadLine(), out number);
                if (!isParse) Console.WriteLine("Вы ввели не целое число");
                if (number < lowerBound || number > upperBound)
                    Console.WriteLine($"Число должно быть от {lowerBound} до {upperBound}");
            } while (!isParse || number < lowerBound || number > upperBound);

            return number;
        }

        public static void WriteDividerLine(string name = "")
        {
            int lineLength = 54;
            if (name.Length < lineLength)
                lineLength = lineLength - name.Length;
            else
                lineLength = 0;
            string halfLine = new string('-', (lineLength) / 2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(halfLine + name + halfLine);
            Console.ResetColor();
        }

        public static void WriteError(string name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name);
            Console.ResetColor();
        }




    }
}
