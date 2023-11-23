using System;
using System.Runtime.InteropServices;

namespace Lab4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int n;
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
                int[] arr = new int[k]; 
                Console.WriteLine("Введите цифру для выбора способа заполнения массива\n" +
                                  "1 - С помощью датчика случаных чисел\n" +
                                  "2 - Ввод с клавиатуры");
                bool isGenerated = false;
                while(!isGenerated){
                    switch (EnterNumber())
                    {
                        case 1:
                            Random r = new Random(0);
                            for (int i = 0; i < k; i++)
                            {
                                arr[i] = r.Next(-100, 100);
                            }

                            isGenerated = true;

                            break;
                        case 2:
                            for (int i = 0; i < k; i++)
                            {
                                Console.WriteLine("Введите целое число");
                                arr[i] = EnterNumber();
                            }

                            isGenerated = true;

                            break;
                        default:
                            Console.WriteLine("Введите либо 1, либо 2");
                            break;
                    }
                }

                return arr;
            }

            void PrintArray(int[] arr)
            {
                Console.Write("Массив: ");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{arr[i]} ");
                }

                Console.Write('\n');
            }
            
            
            Console.WriteLine("Введите количество элементов массива");
            do
            {
                n = EnterNumber();
                if (n<1)
                    Console.WriteLine("Количество элментов должно быть больше 0");
            } while (n < 1);

            int[] a = FillArray(n);

            Console.WriteLine("--------------------Печать массива--------------------");
            
            PrintArray(a);
            
            Console.WriteLine("------------------Удаление элементов------------------");
            
            Console.WriteLine("Введите номер числа, которое хотите удалить: ");
            int index;
            do
            {
                index = EnterNumber() - 1;
                if (index < 0 || index>=n)
                    Console.WriteLine($"Номер элемента должен быть от 1 до {n}");
            } while (index < 0 || index>=n);
            Console.WriteLine(a[index]);
            int[] tempA = new int[n-1];
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                if (i != index)
                    tempA[i - s] = a[i];
                else
                    s++;
            }
            n--;
            a = tempA;
            PrintArray(a);

            Console.WriteLine("-----------------Добавление элементов-----------------");

            Console.WriteLine("Введите с какого номера начать добавлять элементы: ");
            int startIndex,num;
            do
            {
                startIndex = EnterNumber() - 1;
                if (startIndex < 0 || startIndex >= n)
                    Console.WriteLine($"Номер элемента должен быть от 1 до {n}");
            } while (startIndex < 0|| startIndex>=n);

            Console.WriteLine("Введите сколько элементов добавить: ");
            do
            {
                num = EnterNumber();
                if(num < 0)
                    Console.WriteLine("Нельзя добавить отрицательное число элементов");
            } while (num < 0);

            if (num != 0)
            {
                n += num;
                tempA = new int[n];
                s = 0;
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

                a = tempA;
            }
            else
                Console.WriteLine("Числа добавлены не были");
            
            PrintArray(a);

            Console.WriteLine("---------------------Перестановка---------------------");
            
            Console.WriteLine($"Введите на сколько элементов влево сдвинуть массив: ");
            int shift;
            do
            {
                shift = EnterNumber();
                if (shift < 0 || shift > n)
                    Console.WriteLine($"Смещение должно быть от 0 до {n}");
            } while (shift < 0|| shift>n);

            if (shift != 0 && shift!=n)
            {

                tempA = new int[shift];

                for (int i = 0; i < shift; i++)
                    tempA[i] = a[i];

                for (int i = 0; i < n - shift; i++)
                    a[i] = a[i + shift];
                for (int i = 0; i < shift; i++)
                    a[n - shift + i] = tempA[i];

            }
            else
                Console.WriteLine("Элементы переставленны не были");
            PrintArray(a);

            Console.WriteLine("------------------------Поиск-------------------------");
            
            Console.WriteLine("Введите значение искомого элемента: ");
            int obj = EnterNumber();
            bool isFind = false;
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
                  $"Число проверок - {index+1}"
                : "Такого элемента в массиве нет");

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
            
            PrintArray(a);
            
            Console.WriteLine("--------------------Бинарный поиск--------------------");

            Console.WriteLine("Введите значние искомого элемента: ");
            obj = EnterNumber();
            int start = 0;
            int end = n - 1;
            int c = 0;
            isFind = false;
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
                ? $"Искомый элемент находится под номером {index}\n" +
                  $"Количество сравнений - {c}"
                : "Такого элемента в массиве нет");
        }
        
    }
}