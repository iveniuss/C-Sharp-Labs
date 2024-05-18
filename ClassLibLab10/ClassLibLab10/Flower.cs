
namespace ClassLibLab10
{
    public class Flower : Plant, IInit, ICloneable, IGetBase
    {
        string[] flowerNameExamples = { "Роза", "Ромашка", "Орхидея", "Лилия", "Гвоздика", "Сирень", "Лилия" };
        string[] smellExamples = { "Сладкий", "Терпкий", "Душистый", "Пряный" };

        protected string? smell;
        public static int FlowerNum { get; protected set; }

        public Plant GetBase()
        {
            return new Plant(this);
        }

        public string? Smell
        {
            get => smell;
            set
            {
                if (value == null)
                    smell = "";
                else
                    smell = value;
            }
        }

        public Flower() : base()
        {
            FlowerNum++;
            PlantNum--;
            Smell = "Неизвестен";
        }

        public Flower(string? name, string? color, string? smell) : base(name, color)
        {
            FlowerNum++;
            PlantNum--;
            Smell = smell;
        }

        public Flower(Flower flower) : base(flower)
        {
            FlowerNum++;
            PlantNum--;
            Smell = flower.Smell;
        }

        public new void Show()
        {
            IO.WriteLine($"Название цветка: {Name}, Цвет: {Color}, Запах: {Smell}");
        }

        public override string ToString()
        {
            return ($"Название цветка: {Name}, Цвет: {Color}, Запах: {Smell}");
        }

        public override void Init()
        {
            base.Init();
            Smell = IO.EnterString("Введите запах");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Name = flowerNameExamples[rnd.Next(flowerNameExamples.Length)];
            Smell = smellExamples[rnd.Next(smellExamples.Length)];
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Flower flower)
                return Name == flower.Name && Color == flower.Color && Smell == flower.Smell;
            return false;
        }
        public override object Clone()
        {
            return new Flower(this);
        }
        public override Flower ShallowCopy()
        {
            return (Flower)MemberwiseClone();
        }
        public override int GetHashCode()
        {
            string str = Name + Color+Smell;
            return str.GetHashCode();
        }
    }
}
