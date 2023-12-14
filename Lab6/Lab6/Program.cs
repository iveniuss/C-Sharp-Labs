using System;
using System.Linq;
using System.Text.RegularExpressions;
using ClassLibrary1;

namespace Lab6
{
    internal class Program
    {
        private static readonly char[] Dividers = { ' ', ',', '.', ':',';','?','!'};

        private static readonly string[] TestStrings = {
            "   Строка   с   лишними    проблемами   ",
            ".. Строка.... с. Лишними точками.....",
            "-Идетификаторы: id1, id2. id123;   _id78  1notid"
        };
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
            
            Console.WriteLine("Выберите одну из следующих строк");
            for (int i = 1; i <= TestStrings.Length; i++)
            {
                Console.WriteLine($"{i} - {TestStrings[i-1]}");
            }

            return TestStrings[Lib.EnterNumber(1, TestStrings.Length) - 1];
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
        static void PrintIds(string[] strArr, string divider = ", ")
        {
            
            if (strArr.Length > 0)
            {
                Console.Write("Самые длинные идентификаторы: ");
                Console.Write(strArr[0]);
                if (strArr.Length > 1)
                {
                    for (int i = 1; i < strArr.Length; i++)
                    {
                        Console.Write(divider+strArr[i]);
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
                switch (Lib.EnterNumber(1, 3))
                {
                    case 1:
                        str = Lib.EnterString();
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
                Lib.WriteDividerLine("Меню");
                Console.WriteLine("Выберите действие:\n" +
                                  "1 - Создание строки\n" +
                                  "2 - Печать строки\n" +
                                  "3 - Вывести самые длинные идентификаторы\n" +
                                  "4 - Выход");
                switch (Lib.EnterNumber(1,4))
                {
                    case 1:
                        Lib.WriteDividerLine("Создание строки");
                        str = AskCreateWay();
                        break;
                    case 2:
                        Lib.WriteDividerLine("Печать массива");
                        if (str!= "")
                            Console.WriteLine(str);
                        else
                            Lib.WriteError("Строка еще не создана");
                        break;
                    case 3:
                        Lib.WriteDividerLine("Идентификаторы");
                        if (str!= "")
                            LongestIds(str);
                        else
                            Lib.WriteError("Строка еще не создана");
                        break;
                    case 4:
                        exit = true;
                        break;

                }
            }
        }
    }
}