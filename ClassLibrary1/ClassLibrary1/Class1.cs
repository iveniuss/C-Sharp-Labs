﻿using System;
using System.Runtime.InteropServices;

namespace ClassLibrary1
{
    public class Lib
    {
        public static void WriteDividerLine(string name = "")
        {
            int lineLength = 54;
            if (name.Length < lineLength)
                lineLength = lineLength - name.Length;
            else
                lineLength = 0;
            string halfLine = new string('-',(lineLength)/2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(halfLine+name+halfLine);
            Console.ResetColor();
        }
        public static string EnterString()
        {
            String str;
            Console.WriteLine("Введите строку");
            do
            {
                str = Console.ReadLine(); 
                if(str=="") Console.WriteLine("Введите хоть что-нибудь");
            } while (string.IsNullOrEmpty(str));

            return str;

        }
        public static void WriteError(string name)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(name);
            Console.ResetColor();
        }
        public static int EnterNumber(int lowerBound = -2147483648, int upperBound = 2147483647)
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
    }
}