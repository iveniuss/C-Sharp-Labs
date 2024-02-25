using ClassLibLab10;
using ClassLibLab9;
using System.Collections.Immutable;
using System.Linq.Expressions;

namespace Lab10
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        { 
            //-----------------------------------------------------------
            bool finish = false;
            int part = 0;
            Plant[] plants = new Plant[20];
            IInit[] objects = new IInit[20];
            bool isPlantsCreated = false;
            bool isObjectsCreated = false;

            do
            {
                switch (part)
                {
                    case 0:
                        IO.WriteDividerLine("Меню");
                        Console.WriteLine("1 - Часть 1\n" +
                                          "2 - Часть 2\n" +
                                          "3 - Часть 3\n" +
                                          "4 - Выход");
                        IO.WriteDividerLine();
                        switch (IO.EnterIntNumber())
                        {
                            case 1:
                                part = 1;
                                break;
                            case 2:
                                part = 2;
                                break;
                            case 3:
                                part = 3;
                                break;
                            case 4:
                                finish = true;
                                break;
                        }
                        break;
                    case 1:
                        IO.WriteDividerLine("1 часть");
                        Console.WriteLine("1 - Создать массив объектов разных классов\n" +
                                          "2 - Вывод массива обычными функциями\n" +
                                          "3 - Вывод массива виртульными функциями\n" +
                                          "4 - Назад");
                        IO.WriteDividerLine(); 
                        switch (IO.EnterIntNumber())
                        {
                            case 1:
                                for (int i = 0; i < plants.Length; i++)
                                {
                                    int plantType = random.Next(4);
                                    switch (plantType)
                                    {
                                        case 0:
                                            plants[i] = new Plant();
                                            plants[i].RandomInit();
                                            break;
                                        case 1:
                                            plants[i] = new Tree();
                                            plants[i].RandomInit();
                                            break;
                                        case 2:
                                            plants[i] = new Flower();
                                            plants[i].RandomInit();
                                            break;
                                        case 3:
                                            plants[i] = new Rose();
                                            plants[i].RandomInit();
                                            break;
                                    }
                                }
                                isPlantsCreated = true;
                                break;
                            case 2:
                                if (isPlantsCreated)
                                    foreach (Plant p in plants)
                                        p.Show();
                                else
                                    IO.WriteError("Массив еще не создан");
                                break;
                            case 3:
                                if (isPlantsCreated)
                                    foreach (Plant p in plants)
                                        Console.WriteLine(p.ToString());
                                else
                                    IO.WriteError("Массив еще не создан");
                                break;
                            case 4:
                                part = 0;
                                break;
                            default:
                                IO.WriteError("Неверное число");
                                break;
                        }
                        break;
                    case 2:
                        IO.WriteDividerLine("2 часть");
                        Console.WriteLine("1 - Название, цвет и запах всех роз без шипов.\n" +
                                          "2 - Самое маленькое (низкое) дерево.\n" +
                                          "3 - Названия всех цветов с заданным запахом.\n" +
                                          "4 - Назад");
                        IO.WriteDividerLine();
                        switch (IO.EnterIntNumber())
                        {
                            case 1:
                                if (isPlantsCreated)
                                    Console.WriteLine(Plant.RosesWithoutSpikes(plants));
                                else
                                    IO.WriteError("Массив еще не создан(1 часть)");
                                break;
                            case 2:
                                if (isPlantsCreated)
                                {
                                    try
                                    {
                                        Console.WriteLine(Plant.SmallestTree(plants));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex);
                                    }
                                }
                                else
                                    IO.WriteError("Массив еще не создан(1 часть)");
                                break;
                            case 3:
                                if (isPlantsCreated)
                                    Console.WriteLine(Plant.FlowersBySmell(plants, IO.EnterString("Введите запах")));
                                else
                                    IO.WriteError("Массив еще не создан(1 часть)");
                                break;
                            case 4:
                                part = 0;
                                break;
                            default:
                                IO.WriteError("Неверное число");
                                break;
                        }
                        break;
                    case 3:
                        IO.WriteDividerLine("2 часть");
                        Console.WriteLine("1 - Cоздать массив с иерархией классов и классом из лаб. 9\n" +
                                          "2 - Вывести массив\n" +
                                          "3 - Подсчитать кол-во созданных объектов\n" +
                                          "4 - Сортировка массива из 1 части по имени\n" +
                                          "5 - Сортировка массива из 1 части по цвету\n" +
                                          "6 - Бинарный поиск в отсортированном по имени массиве\n" +
                                          "7 - Бинарный поиск в отсортированном по цвету массиве\n" +
                                          "8 - Пример глубокого и поверхностного копирования\n" +
                                          "9 - Назад");
                        IO.WriteDividerLine();
                        switch (IO.EnterIntNumber())
                        {
                            case 1:
                                for (int i = 0; i < 20; i++)
                                {
                                    int objType = random.Next(5);
                                    switch (objType)
                                    {
                                        case 0:
                                            objects[i] = new Plant();
                                            objects[i].RandomInit();
                                            break;
                                        case 1:
                                            objects[i] = new Tree();
                                            objects[i].RandomInit();
                                            break;
                                        case 2:
                                            objects[i] = new Flower();
                                            objects[i].RandomInit();
                                            break;
                                        case 3:
                                            objects[i] = new Rose();
                                            objects[i].RandomInit();
                                            break;
                                        case 4:
                                            objects[i] = new Post();
                                            objects[i].RandomInit();
                                            break;
                                    }
                                }
                                isObjectsCreated = true;
                                break;
                            case 2:
                                if (isObjectsCreated)
                                    foreach (IInit obj in objects)
                                        Console.WriteLine(obj.ToString());
                                else
                                    IO.WriteError("Массив еще не создан");
                                break;
                            case 3:
                                if (isObjectsCreated)
                                {
                                    Console.WriteLine($"Объектов класса Plant - {Plant.PlantNum}");
                                    Console.WriteLine($"Объектов класса Tree - {Tree.TreeNum}");
                                    Console.WriteLine($"Объектов класса Flower - {Flower.FlowerNum}");
                                    Console.WriteLine($"Объектов класса Rose - {Rose.RoseNum}");
                                    Console.WriteLine($"Объектов класса Post - {Post.ObjNum}");
                                }
                                else
                                    IO.WriteError("Массив еще не создан");
                                break;
                            case 4:
                                if (isPlantsCreated)
                                {
                                    Array.Sort(plants);
                                    foreach (Plant plant in plants)
                                        Console.WriteLine(plant.ToString());
                                }
                                else
                                    IO.WriteError("Массив еще не создан");
                                break;
                            case 5:
                                if (isPlantsCreated)
                                {
                                    Array.Sort(plants, new ByColor());
                                    foreach (Plant plant in plants)
                                        Console.WriteLine(plant.ToString());
                                }
                                else
                                    IO.WriteError("Массив еще не создан");
                                break;
                            case 6:
                                if (isPlantsCreated)
                                {
                                    Array.Sort(plants);
                                    Plant searchPlant = new Plant();
                                    searchPlant.Name = IO.EnterString("Введите имя искомого растения");
                                    Console.WriteLine(Array.BinarySearch(plants, searchPlant));
                                }
                                else
                                    IO.WriteError("Массив еще не создан");
                                break;
                            case 7:
                                if (isPlantsCreated)
                                {
                                    Array.Sort(plants, new ByColor());
                                    Plant searchPlant = new Plant();
                                    searchPlant.Color = IO.EnterString("Введите цвет искомого растения");
                                    Console.WriteLine(Array.BinarySearch(plants, searchPlant, new ByColor()));
                                }
                                else
                                    IO.WriteError("Массив еще не создан");
                                break;
                            case 8:
                                Plant p1 = new Plant();
                                p1.RandomInit();
                                p1.Id.Number = 1;
                                Console.WriteLine("p1 - оригинальный объект");
                                Console.WriteLine(p1);
                                Console.WriteLine("p2 - Поверхностная копия, p2 - глубокая копия");
                                Console.WriteLine("Увеличим id p2 на 1, а id p3 на 10");
                                Plant p2 = p1.ShallowCopy();
                                Plant p3 = (Plant)p1.Clone();
                                p2.Id.Number++;
                                p3.Id.Number += 10;
                                Console.WriteLine($"p1: {p1}");
                                Console.WriteLine($"p2: {p2}");
                                Console.WriteLine($"p3: {p3}");
                                Console.WriteLine("Id p1 также увечисло на 1, так как p2 это поверхностная копия");
                                break;
                            case 9:
                                part = 0;
                                break;
                            default:
                                IO.WriteError("Неверное число");
                                break;

                        }
                        break;
                    default:
                        IO.WriteError("Неверное число");
                        break;
                }

            } while (!finish);
        }
    }
}

