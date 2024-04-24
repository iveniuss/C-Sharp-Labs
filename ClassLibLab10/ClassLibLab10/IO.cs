

namespace ClassLibLab10
{
    public class IO
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

        public static string EnterString(string message = "Введите строку")
        {
            string? str;
            Console.WriteLine(message);
            do
            {
                str = Console.ReadLine();
                if (str == "") Console.WriteLine("Введите хоть что-нибудь");
            } while (string.IsNullOrEmpty(str));

            return str;

        }

        public static bool EnterBool(string message = "Введите логическую переменную")
        {
            bool isParse;
            bool value;
            string? str;
            do
            {
                Console.WriteLine(message + "(Y/N)");
                str = Console.ReadLine();
                if (str == "Y")
                {
                    isParse = true;
                    value = true;
                }
                else if (str == "N")
                {
                    isParse = true;
                    value = false;
                }
                else
                    isParse = bool.TryParse(str, out value);
            } while (!isParse);
            return value;
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

        public static void Write(string name)
        {
            Console.WriteLine(name);
        }



    }
}
