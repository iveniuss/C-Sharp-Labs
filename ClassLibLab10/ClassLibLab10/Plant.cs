
namespace ClassLibLab10
{
    public class Plant
    {
        protected string[] nameExamples = { "Картофель", "Помидор", "Огурец", "Капуста", "Морковь", "Лук", "Чеснок", "Баклажан", "Тыква", "Лук-порей", "Кабачок", "Перец", "Шпинат", "Редис", "Щавель", "Редька", "Лук-шалот", "Свекла", "Фасоль", "Горох" };
        protected string[] colorExamples = { "Красный", "Оранжевый", "Желтый", "Зеленый", "Голубой", "Синий", "Фиолетовый", "Розовый", "Белый", "Черный", "Серый", "Коричневый", "Бежевый", "Фиолетовый", "Салатовый", "Пурпурный", "Оливковый" };

        static Random rnd = new Random();
        protected string? name;
        protected string? color;

        public string Name { get; set; }

        public string Color { get; set; }

        public Plant()
        {
            Name = "Без названия";
            Color = "Неизвестен";
        }

        public Plant(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public Plant(Plant plant)
        {
            Name = plant.Name;
            Color = plant.Color;
        }

        public void Show()
        {
            IO.Write($"Название: {Name} Цвет: {Color}");
        }
        public virtual void VirtualShow()
        {
            IO.Write($"Название: {Name}, Цвет: {Color}");
        }

        public virtual void Init()
        {
            Name = IO.EnterString("Введите название растения");
            Color = IO.EnterString("Введите цвет растения");
        }

        public virtual void RandomInit()
        {
            Name = nameExamples[rnd.Next(nameExamples.Length)];
            Color = colorExamples[rnd.Next(colorExamples.Length)];
        }

        public override bool Equals(object? obj)
        {
            if (obj !=null && obj is Plant plant)
                return Name==plant.Name && Color==plant.Color;
            return false;
        }




    }
}
