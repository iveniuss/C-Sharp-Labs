﻿
using System;

namespace ClassLibLab10
{
    public class IdNumber
    {
        private int number;

        public int Number
        {
            get => number;
            set
            {
                if (value < 0)
                    number = 0;
                else
                    number = value;
            }
        }

        public IdNumber()
        {
            Number = 0;
        }
        public IdNumber(int number)
        {
            Number = number;
        }
        public override string ToString()
        {
            return number.ToString();
        }

        public override bool Equals(object? obj)
        {
            if (obj is IdNumber id)
                return id.Number == Number;
            return false;
        }
    }

    public class Plant : IInit, IComparable, ICloneable
    {
        

        protected string[] nameExamples = { "Картофель", "Помидор", "Огурец", "Капуста", "Морковь", "Лук", "Чеснок", "Баклажан", "Тыква", "Лук-порей", "Кабачок", "Перец", "Шпинат", "Редис", "Щавель", "Редька", "Лук-шалот", "Свекла", "Фасоль", "Горох" };
        protected string[] colorExamples = { "Красный", "Оранжевый", "Желтый", "Зеленый", "Голубой", "Синий", "Фиолетовый", "Розовый", "Белый", "Черный", "Серый", "Коричневый", "Бежевый", "Фиолетовый", "Салатовый", "Пурпурный", "Оливковый" };

        protected static Random rnd = new Random();
        protected string? name;
        protected string? color;
        public IdNumber Id { get; set; }
        public static int PlantNum { get; protected set; }

        public string? Name
        {
            get => name;
            set
            {
                if (value == null)
                    name = "";
                else name = value;
            }
        }

        public string? Color
        {
            get => color;
            set
            {
                if (value == null)
                    color = "";
                else color = value;
            }
        }

        public Plant()
        {
            PlantNum++;
            Id = new IdNumber(0);
            Name = "Без названия";
            Color = "Неизвестен";
        }

        public Plant(string name, string color)
        {
            PlantNum++;
            Id = new IdNumber(0);
            Name = name;
            Color = color;
        }

        public Plant(Plant plant)
        {
            PlantNum++;
            Id = new IdNumber(plant.Id.Number);
            Name = plant.Name;
            Color = plant.Color;
        }

        public void Show()
        {
            IO.Write($"Название: {Name} Цвет: {Color}");
        }
        public override string ToString()
        {
            return $"Название: {Name}, Цвет: {Color}, id:{Id.Number}";
        }

        public virtual void Init()
        {
            Name = IO.EnterString("Введите название растения");
            Color = IO.EnterString("Введите цвет растения");
            Id.Number = IO.EnterIntNumber("Введите id");
        }

        public virtual void RandomInit()
        {
            Name = nameExamples[rnd.Next(nameExamples.Length)];
            Color = colorExamples[rnd.Next(colorExamples.Length)];
            Id.Number = rnd.Next(1000);
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Plant plant)
                return Name == plant.Name && Color == plant.Color;
            return false;
        }

        public static string RosesWithoutSpikes(Plant[] plants)
        {
            string roses = "";
            foreach (Plant plant in plants)
                if (plant is Rose rose && !rose.IsSpiked)
                    roses += $"Название розы: {rose.Name}, Цвет: {rose.Color}, Запах: {rose.Smell}\n";
            return roses.Remove(roses.Length - 1);
        }

        public static Tree SmallestTree(Plant[] plants)
        {
            Tree? smallestTree = null;
            foreach (Plant plant in plants)
                if (plant is Tree tree && (smallestTree == null || tree.Height < smallestTree.Height))
                    smallestTree = tree;
            if (smallestTree != null)
                return smallestTree;
            throw new ArgumentException("В списке нет деревьев");
        }

        public static string FlowersBySmell(Plant[] plants, string smell)
        {
            string flowers = "";
            foreach (Plant plant in plants)
                if (plant is Flower flower && flower.Smell == smell)
                    flowers += flower.Name + "\n";
            return flowers.Remove(flowers.Length - 1);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return -1;
            else if (obj is Plant plant)
                return string.Compare(Name, plant.Name);
            return -1;
        }

        public virtual object Clone()
        {
            return new Plant(this);
        }

        public virtual Plant ShallowCopy()
        {
            return (Plant)MemberwiseClone();
        }





    }
}