using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab6
{
    internal class Program
    {
        static readonly char[] Dividers = { ' ', ',', '.', ':',';','?','!'};
        static int EnterNumber(int lowerBound = -2147483648, int upperBound = 2147483647)
        {
            int number;
            bool isParse;
            do
            {
                isParse = int.TryParse(Console.ReadLine(), out number);
                if (!isParse) Console.WriteLine("Вы ввели не целое число");
                if (number < lowerBound || number > upperBound)
                    Console.WriteLine($"Число должно быть от {lowerBound} до {upperBound}");
            }while (!isParse || number<lowerBound || number>upperBound);

            return number;
        }
        static void WriteDividerLine(string name = "")
        {
            string halfLine = new string('-',(54-name.Length)/2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(halfLine+name+halfLine);
            Console.ResetColor();
        }

        static void WriteError(string name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name);
            Console.ResetColor();
        }
        static String EnterString()
        {
            String str;
            do
            {
                str = Console.ReadLine(); 
                if(str=="") Console.WriteLine("Введите хоть что-нибудь");
            } while (string.IsNullOrEmpty(str));

            return str;

        }

        static string FormString(string str)
        {
            foreach (char divider in Dividers)
            {
                str = Regex.Replace(str, $"\\{divider}+", $"{divider}");
            }

            str = str.Trim(Dividers);
            str += '.';
            return str;
        }

        static string ChooseString()
        {
            string[] testStrings = {"   Строка   с   лишними    проблемами   ",
                ".. Строка.... с. Лишними точками.....",
                "-Идетификаторы: id1, id2. id123;   _id78  1notid"
            };
            Console.WriteLine("Выберите одну из следующих строк");
            for (int i = 1; i <= testStrings.Length; i++)
            {
                Console.WriteLine($"{i} - {testStrings[i-1]}");
            }

            return testStrings[EnterNumber(1, testStrings.Length) - 1];
        }

        static void LongestIds(string str)
        {
            string[] words = str.Split(Dividers, StringSplitOptions.RemoveEmptyEntries);
            string[] ids = new string[words.Length];
            int currentIdLen = 0;
            int currentIndex = 0;
            
            foreach (string word in words)
            {
                if (Regex.IsMatch(word,"^[a-zA-Z_][a-zA-Z0-9]+$"))
                    if (word.Length == currentIdLen)
                    {
                        ids[currentIndex] = word;
                        currentIndex++;
                        currentIdLen = word.Length;
                    }
                    else if(word.Length > currentIdLen)
                    {
                        for (int i = currentIndex; i >= 0; i--)
                        {
                            ids[i] = null;
                            currentIndex = i;
                        }

                        ids[currentIndex] = word;
                        currentIndex++;
                        currentIdLen = word.Length;
                    }
                
            }
            ids = ids.Where(c => c != null).ToArray();
            PrintIds(ids);
        }

        static void PrintIds(string[] strArr, string divider = "")
        {
            
            if (strArr.Length > 0)
            {
                Console.Write("Самые длинные идентификаторы: ");
                Console.Write(strArr[0]);
                if (strArr.Length > 1)
                {
                    for (int i = 1; i < strArr.Length; i++)
                    {
                        Console.Write($", {strArr[i]}");
                    }
                }

                Console.WriteLine();
            }
            else
                Console.WriteLine("В строке нет идентификаторов");
        }

        static string AskCreateWay()
        {
            bool exit = false;
            string str;
            Console.WriteLine("Выберите способ создания строки\n" +
                              "1 - Вручную\n" +
                              "2 - Из списка\n" +
                              "3 - Назад");
            while(!exit) 
                switch (EnterNumber(1, 3))
                {
                    case 1:
                        str = EnterString();
                        return FormString(str);
                    case 2:
                        str =  ChooseString();
                        return FormString(str);
                    case 3:
                        exit = true;
                        break;
                }

            return "";
        }
        public static void Main(string[] args)
        {
            string str = "";
            bool exit = false;
            while (!exit)
            {
                WriteDividerLine("Меню");
                Console.WriteLine("Выберите действие:\n" +
                                  "1 - Создание строки\n" +
                                  "2 - Печать строки\n" +
                                  "3 - Вывести самые длинные идентификаторы\n" +
                                  "4 - Выход");
                switch (EnterNumber(1,4))
                {
                    case 1:
                        WriteDividerLine("Создание строки");
                        str = AskCreateWay();
                        break;
                    case 2:
                        WriteDividerLine("Печать массива");
                        if (str!= "")
                            Console.WriteLine(str);
                        else
                            WriteError("Строка еще не создана");
                        break;
                    case 3:
                        WriteDividerLine("Идентификаторы");
                        if (str!= "")
                            LongestIds(str);
                        else
                            WriteError("Строка еще не создана");
                        break;
                    case 4:
                        exit = true;
                        break;

                }
            }
        }
    }
}