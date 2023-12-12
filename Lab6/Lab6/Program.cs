using System;
using System.Runtime.InteropServices;

namespace Lab6
{
    internal class Program
    {
        static String EnterString()
        {
            String str;
            do
            {
                str = Console.ReadLine();
                if(str=="") Console.WriteLine("Введите хоть что-нибудь");
            } while (str == "");

            return str;

        }

        static string DeleteOddSpaces(String str)
        {
            Char[] underline = new char[str.Length];
            char startChar = str[0];
            char endChar = str[str.Length - 1];
            int index = 0;
            int oddSpacesNum = 0;
            
            while (startChar == ' ')
            {
                underline[index] = '^';
                index++;
                startChar = str[index];
                oddSpacesNum++;
            }

            index = str.Length-1;
            while (endChar == ' ')
            {
                underline[index] = '^';
                index--;
                endChar = str[index];
                oddSpacesNum++;
            }

            for (index = 0; index < str.Length - 1; index++)
            {
                if (str[index] == ' ' && str[index + 1] == ' ')
                {
                    underline[index] = '^';
                    oddSpacesNum++;
                }

            }

            if (oddSpacesNum>0)
            {
                Console.WriteLine("В введенной строке есть лишние пробелы. Они будут удалены");
                Console.WriteLine(str);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(underline);
                Console.ResetColor();
                Char[] charArr = new char[str.Length - oddSpacesNum];
                int charSkip = 0;
                for (int i = 0; i < charArr.Length; i++)
                {
                    if (underline[i] == '^')
                        charSkip++;
                    else
                        charArr[i-charSkip] = str[i];
                }
                string newStr = new string(charArr);

                return newStr;

            }

            return str;

        }
        public static void Main(string[] args)
        {
            String s;
            s=EnterString();
            Console.WriteLine("Итоговая строка");
            s = DeleteOddSpaces(s);
            Console.WriteLine(s);
        }
    }
}