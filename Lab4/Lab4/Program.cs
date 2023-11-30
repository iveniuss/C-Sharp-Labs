using System;

namespace Lab4
{
    internal static class Program
    {
        private static readonly Random R = new Random(0);
        public static void Main(string[] args)
        {
            int n;
            bool isSorted = false;
            bool isCreated = false;
            bool exit = false;
            int EnterNumber()
            {
                int number;
                bool isParse;
                do
                {
                    isParse = int.TryParse(Console.ReadLine(), out number);
                    if (!isParse) Console.WriteLine("Вы ввели не целое число");
                }while (!isParse);

                return number;
            }

            int[] FillArray(int k)
            {
                int[] a = new int[k]; 
                Console.WriteLine("Введите цифру для выбора способа заполнения массива\n" +
                                  "1 - С помощью датчика случаных чисел\n" +
                                  "2 - Ввод с клавиатуры");
                isCreated = false;
                while(!isCreated){
                    switch (EnterNumber())
                    {
                        case 1:
                            
                            for (int i = 0; i < k; i++)
                            {
                                a[i] = R.Next(-100, 100);
                            }

                            isCreated = true;

                            break;
                        case 2:
                            for (int i = 0; i < k; i++)
                            {
                                Console.WriteLine("Введите целое число");
                                a[i] = EnterNumber();
                            }

                            isCreated = true;

                            break;
                        default:
                            Console.WriteLine("Введите либо 1, либо 2");
                            break;
                    }
                }

                return a;
            }

            void PrintArray(int[] a)
            {
                Console.WriteLine("--------------------Печать массива--------------------");
                Console.Write("Массив: ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{a[i]} ");
                }

                Console.Write('\n');
            }

            int[] CreateArray()
            {
                Console.WriteLine("Введите количество элементов массива");
                do
                {
                    n = EnterNumber();
                    if (n < 1)
                        Console.WriteLine("Количество элементов должно быть больше 0");
                } while (n < 1);
                
                return FillArray(n);
            }

            int[] DeleteElements(int[] a)
            {

                Console.WriteLine("------------------Удаление элементов------------------");
                if (n != 0)
                {
                    Console.WriteLine("Введите номер числа, которое хотите удалить: ");
                    int index;
                    do
                    {
                        index = EnterNumber() - 1;
                        if (index < 0 || index >= n)
                            Console.WriteLine($"Номер элемента должен быть от 1 до {n}");
                    } while (index < 0 || index >= n);

                    Console.WriteLine(a[index]);
                    int[] tempA = new int[n - 1];
                    int s = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (i != index)
                            tempA[i - s] = a[i];
                        else
                            s++;
                    }
                    Console.WriteLine("Элементы удалены");
                    if (--n == 0)
                        isCreated = false;
                    return tempA;
                }
                Console.WriteLine("Массив пустой");
                isCreated = false;
                return a;
            }

            int[] AddElements(int[] a)
            {
                Console.WriteLine("-----------------Добавление элементов-----------------");

                Console.WriteLine("Введите с какого номера начать добавлять элементы: ");
                int startIndex, num;
                do
                {
                    startIndex = EnterNumber() - 1;
                    if (startIndex < 0 || startIndex >= n+1)
                        Console.WriteLine($"Номер элемента должен быть от 1 до {n+1}");
                } while (startIndex < 0 || startIndex >= n+1);

                Console.WriteLine("Введите сколько элементов добавить: ");
                do
                {
                    num = EnterNumber();
                    if (num < 0)
                        Console.WriteLine("Нельзя добавить отрицательное число элементов");
                } while (num < 0);

                if (num != 0)
                {
                    if (startIndex == n + 1)
                        n += num + 1;
                    else
                        n += num;
                    int[] tempA = new int[n];
                    int s = 0;
                    for (int i = 0; i < n; i++)
                    {
                        if (i >= startIndex && i < startIndex + num)
                        {
                            tempA[i] = 0;
                            s++;
                        }
                        else
                        {
                            tempA[i] = a[i - s];
                        }
                    }

                    int[] tempB = FillArray(num);
                    for (int i = startIndex; i < startIndex + num; i++)
                    {
                        tempA[i] = tempB[i - startIndex];
                    }
                    Console.WriteLine("Элементы добавлены");
                    return tempA;
                }
                Console.WriteLine("Числа добавлены не были");
                return a;


            }

            int[] Shift(int[] a)
            {
                Console.WriteLine("---------------------Перестановка---------------------");

                Console.WriteLine($"Введите на сколько элементов влево сдвинуть массив: ");
                int shift;
                do
                {
                    shift = EnterNumber();
                    if (shift < 0 || shift > n)
                        Console.WriteLine($"Смещение должно быть от 0 до {n}");
                } while (shift < 0 || shift > n);

                if (shift != 0 && shift != n)
                {

                    int[] tempA = new int[shift];

                    for (int i = 0; i < shift; i++)
                        tempA[i] = a[i];

                    for (int i = 0; i < n - shift; i++)
                        a[i] = a[i + shift];
                    for (int i = 0; i < shift; i++)
                        a[n - shift + i] = tempA[i];
                    Console.WriteLine("Элементы переставлены");

                }
                else
                    Console.WriteLine("Элементы переставленны не были");

                return a;
            }

            void Find(int[] a)
            {

                Console.WriteLine("------------------------Поиск-------------------------");

                Console.WriteLine("Введите значение искомого элемента: ");
                int obj = EnterNumber();
                bool isFind = false;
                int index=0;
                for (int i = 0; i < n; i++)
                {
                    if (a[i] == obj)
                    {
                        index = i;
                        isFind = true;
                        break;
                    }
                }

                Console.WriteLine(isFind
                    ? $"Искомый элемент находится под номером {index + 1}\n" +
                      $"Число проверок - {index + 1}"
                    : "Такого элемента в массиве нет");
            }

            int[] Sort(int[] a)
            {
                Console.WriteLine("----------------------Сортировка----------------------");

                for (int i = 1; i < n; i++)
                {
                    int j = i - 1;
                    int key = a[i];
                    while (j >= 0 && a[j] > key)
                    {
                        a[j + 1] = a[j];
                        j--;
                    }

                    a[j + 1] = key;
                }

                isSorted = true;
                return a;
            }

            void BinFind(int[] a)
            {

                Console.WriteLine("--------------------Бинарный поиск--------------------");

                Console.WriteLine("Введите значние искомого элемента: ");
                int obj = EnterNumber();
                int start = 0;
                int end = n - 1;
                int c = 0;
                bool isFind = false;
                int index = 0;
                while (start <= end && !isFind)
                {
                    int center = (start + end) / 2;
                    if (a[center] > obj)
                    {
                        end = --center;
                        c++;
                    }
                    else if (a[center] < obj)
                    {
                        start = ++center;
                        c++;
                    }
                    else
                    {
                        index = center;
                        c++;
                        isFind = true;
                    }

                }

                Console.WriteLine(isFind
                    ? $"Искомый элемент находится под номером {index+1}\n" +
                      $"Количество сравнений - {c}"
                    : "Такого элемента в массиве нет");
            }

            
            int[] arr=new int[0];
            n = 0;
            while (!exit)
            {
                Console.WriteLine("------------------------------------------------------\n" +
                                  "Выберите действие\n" +
                                  "1 - Создание массива\n" +
                                  "2 - Печать массива\n" +
                                  "3 - Удаление элементов\n" +
                                  "4 - Добавление элементов\n" +
                                  "5 - Перестановка\n" +
                                  "6 - Поиск\n" +
                                  "7 - Сортировка\n" +
                                  "8 - Бинарный поиск\n" +
                                  "9 - Выход");
                switch (EnterNumber())
                {
                    case 1:
                        arr = CreateArray();
                        Console.WriteLine("Новый массив создан");
                        isCreated = true;
                        isSorted = false;
                        break;
                    case 2:
                        if (isCreated)
                            PrintArray(arr);
                        else
                            Console.WriteLine("Массив еще не создан");
                        break;
                    case 3:
                    {
                        if (isCreated)
                        {
                            arr = DeleteElements(arr);
                            
                        }
                        else
                            Console.WriteLine("Массив еще не создан");
                        break;
                    }
                    case 4:
                    {
                        if (isCreated)
                        {
                            arr = AddElements(arr);
                            isSorted = false;
                        }
                        else
                            Console.WriteLine("Массив еще не создан");
                        break;
                    }
                    case 5:
                        if (isCreated)
                        {
                            arr = Shift(arr);
                            isSorted = false;
                        }
                        else
                            Console.WriteLine("Массив еще не создан");
                        break;
                    case 6:
                        if (isCreated)
                            Find(arr);
                        else
                            Console.WriteLine("Массив еще не создан");
                        break;
                    case 7:
                        if (isCreated)
                        {
                            arr = Sort(arr);
                            isSorted = true;
                            Console.WriteLine("Массив отсортирован");
                        }
                        else
                            Console.WriteLine("Массив еще не создан");
                        break;
                    case 8:
                        switch (isCreated)
                        {
                            case true when isSorted:
                                BinFind(arr);
                                break;
                            case true:
                                Console.WriteLine("Сначала отсортируйте массив");
                                break;
                            default:
                                Console.WriteLine("Массив еще не создан");
                                break;
                        }
                        break;
                    case 9:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Такого числа нет в списке");
                        break;
                }
            }
        }
        
    }
}