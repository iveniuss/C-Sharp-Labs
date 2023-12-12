using System;

namespace Lab5
{
    
    internal class Program
    {
        private static readonly Random R = new Random(0);
        private const int LowerBound = -3;
        private const int UpperBound = 5;
        private const int NumLen = 3;
        private const int DividerLength = 54;

        static int EnterNumber(int lowerBound = int.MinValue, int upperBound = int.MaxValue)
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
            int lineLength;
            if (name.Length > DividerLength)
                lineLength = 0;
            else
                lineLength = (DividerLength - name.Length) / 2;

            string halfLine = new string('-',lineLength);
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

        static bool AskFillWay()
        {
            bool isRandom = false;
            bool isChosen = false;
            Console.WriteLine("Выберите способ заполнения массива:\n" +
                              "1 - Случайные числа\n" +
                              "2 - Ввод с клавиатуры");
            while (!isChosen)
            {
                switch (EnterNumber(1,2))
                {
                    case 1:
                        isRandom = true;
                        isChosen = true;
                        break;
                    case 2:
                        isChosen = true;
                        break;
                }
            }

            return isRandom;
        }

        static int[] FillRow(int len, bool isRandom)
        {
            int[] newArr = new int[len];
            if (isRandom)
                for (int i = 0; i < len; i++)
                    newArr[i] = R.Next(LowerBound, UpperBound);
            else
                for (int i = 0; i < len; i++)
                {
                    Console.WriteLine("Введите целое число");
                    newArr[i] = EnterNumber();
                }

            return newArr;
        }

        static int Find(int[] arr, out bool isFind)
        {
            int obj = EnterNumber();
            isFind = false;
            int index = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == obj)
                {
                    index = i;
                    isFind = true;
                    break;
                }
            }

            return index;

        }

        static int[] CreateArray1D()
        {
            
            Console.WriteLine("Введите длину одномерного массива");
            int len = EnterNumber(1);
            return FillRow(len, AskFillWay());
        }

        static int[,] CreateArray2D()
        {
            
            Console.WriteLine("Введите количество строк двумерного массива");
            int rows = EnterNumber(1);
            Console.WriteLine("Введите количество столбцов двумерного массива");
            int columns = EnterNumber(1);
            bool isRandom = AskFillWay();
            int[,] newArr = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                if(!isRandom)
                    Console.WriteLine($"Введите числа строки {i+1}");
                int[] tempRow = FillRow(columns, isRandom);
                for (int j = 0; j < columns; j++)
                    newArr[i, j] = tempRow[j];
            }

            return newArr;
        }

        static int[][] CreateArrayJagged()
        {
            Console.WriteLine("Введите количество строк рваного массива");
            int rows = EnterNumber(1);
            int[][] newArr = new int[rows][];
            bool isRandom = AskFillWay();
            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine($"Введите длину строки {i+1}");
                int tempRowLen = EnterNumber(1);
                int[] tempRow = FillRow(tempRowLen, isRandom);
                newArr[i] = tempRow;
            }

            return newArr;
        }

        static void PrintArray(int[] arr)
        {
            
            foreach (int x in arr)
            {
                Console.Write($"{x,NumLen} ");
            }

            Console.WriteLine();
        }

        static void PrintArray(int[,] arr)
        {
            
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i,j],NumLen} ");
                }

                Console.WriteLine();
            }
        }

        static void PrintArray(int[][] arr)
        {
            
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                foreach(int j in arr[i])
                    Console.Write($"{j,NumLen} ");

                Console.WriteLine();
            }
        }

        static int[] DeleteElements(int[] arr, ref bool is1DCreated)
        {
            Console.WriteLine("Введите число, которое хотите удалить: ");
            int index = Find(arr, out bool isFind);
            if (isFind)
            {
                int[] newArr = new int[arr.Length - 1];
                int shiftRow = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != index)
                        newArr[i - shiftRow] = arr[i];
                    else
                        shiftRow++;
                }

                is1DCreated = newArr.Length != 0;
                Console.WriteLine("Число удалено");

                return newArr;
            }

            WriteError("Искомого числа нет в массиве");
            return arr;
        }

        static int[,] AddRow(int[,] arr)
        {
            
            int oldRowNum = arr.GetLength(0);
            int newRowNum = oldRowNum + 1;
            int colNum = arr.GetLength(1);
            int[,] newArr = new int[newRowNum, colNum];
            for(int i = 0;i<oldRowNum;i++)
            {
                for (int j=0; j < colNum; j++)
                {
                    newArr[i, j] = arr[i, j];
                }
            }

            int[] c = FillRow(colNum,AskFillWay());
            for (int i = 0; i < colNum; i++)
            {
                newArr[oldRowNum, i] = c[i];
            }

            return newArr;
        }
        

        static int[][] DeleteRowsWithZero(int[][] arr, ref bool isJaggedCreated)
        {
            
            int [] deleteArr = new int[arr.GetLength(0)];
            for (int i = 0; i < arr.GetLength(0); i++)
                    foreach (int j in arr[i])
                        if (j == 0)
                        {
                            deleteArr[i] = 1;
                            break;
                        }
            int deleteNum=0;
            foreach (int i in deleteArr)
                deleteNum += i;
            if (deleteNum != 0)
            {
                int shiftRow = 0;
                int[][] newArr = new int[arr.GetLength(0) - deleteNum][];
                Console.Write("Удалены строки: ");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    if (deleteArr[i] == 0)
                        newArr[i - shiftRow] = arr[i];
                    else
                    {
                        shiftRow++;
                        Console.Write($"{i + 1} ");
                    }
                }
                
                isJaggedCreated = newArr.Length != 0;
                Console.WriteLine();
                return newArr;
                
            }
            Console.WriteLine("В массиве нет строк с нулями");
            return arr;

        }


        public static void Main(string[] args)
        {
            bool exit = false;
            bool is1DCreated = false;
            bool is2DCreated = false;
            bool isJaggedCreated = false;
            int[] arr1D = new int[0];
            int[,] arr2D = new int[0,0];
            int[][] arrJagged = new int[0][];

            
            while (!exit)
            {
                WriteDividerLine("Меню");
                Console.WriteLine("1 - Создать одномерный массив\n" +
                                  "2 - Создать двумерный массив\n" +
                                  "3 - Создать рваный массив\n" +
                                  "4 - Печать одномерного массива\n" +
                                  "5 - Печать двумерного массива\n" +
                                  "6 - Печать рваного массива\n" +
                                  "7 - Удаление элемента из одномерного массива\n" +
                                  "8 - Добавление строки в конец матрицы\n" +
                                  "9 - Удаление из рваного массива всех строк с нулями\n" +
                                  "10 - Выход");
                switch (EnterNumber(1,10))
                {
                    case 1:
                        WriteDividerLine("Создание одномерного массива");
                        arr1D = CreateArray1D();
                        is1DCreated = true;
                        break;
                    case 2:
                        WriteDividerLine("Создание двумерного массива");
                        arr2D = CreateArray2D();
                        is2DCreated = true;
                        break;
                    case 3:
                        WriteDividerLine("Создание рваного массива");
                        arrJagged = CreateArrayJagged();
                        isJaggedCreated = true;
                        break;
                    case 4:
                        WriteDividerLine("Одномерный массив");
                        if(is1DCreated)
                            PrintArray(arr1D);
                        else
                            WriteError("Одномерный массив не создан");
                        break;
                    case 5:
                        WriteDividerLine("Двумерный массив");
                        if(is2DCreated)
                            PrintArray(arr2D);
                        else
                            WriteError("Двумерный массив не создан");
                        break;
                    case 6:
                        WriteDividerLine("Рваный массив");
                        if(isJaggedCreated)
                            PrintArray(arrJagged);
                        else
                            WriteError("Рваный массив массив не создан");
                        break;
                    case 7:
                        WriteDividerLine("Удаление элемента");
                        if (is1DCreated)
                            arr1D = DeleteElements(arr1D, ref is1DCreated);
                        else
                            WriteError("Одномерный массив не создан");
                        break;
                    case 8:
                        WriteDividerLine("Добавление строки");
                        if (is2DCreated)
                            arr2D = AddRow(arr2D);
                        else
                            WriteError("Двумерный массив не создан");
                        break;
                    case 9:
                        WriteDividerLine("Удаление строк с 0");
                        if (isJaggedCreated)
                            arrJagged = DeleteRowsWithZero(arrJagged, ref isJaggedCreated);
                        else
                            WriteError("Рваный массив массив не создан");
                        break;
                    case 10:
                        exit = true;
                        break;
                }
            }
            
        }
    }
}