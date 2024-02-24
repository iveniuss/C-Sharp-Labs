
namespace ClassLibLab10
{
    public class Flower:Plant
    {
        static Random rnd = new Random();
        string[] flowerNameExamples = { "Роза", "Ромашка", "Орхидея", "Лилия", "Гвоздика", "Сирень", "Лилия" };
        string[] smellExamples = { "Сладкий", "Терпкий", "Душистый", "Пряный" };

        protected string? smell;

        public string Smell { get; set; }

        public Flower():base()
        {
            Smell = "Неизвестен";
        }

        public Flower(string name, string color, string smell) : base(name,color)
        {
            Smell = smell;
        }

        public Flower(Flower flower):base(flower)
        {
            Smell = flower.Smell;
        }

        public new void Show()
        {
            IO.Write($"Название цветка: {Name}, Цвет: {Color}, Запах: {Smell}");
        }

        public override void VirtualShow()
        {
            IO.Write($"Название цветка: {Name}, Цвет: {Color}, Запах: {Smell}");
        }

        public override void Init()
        {
            base.Init();
            Smell = IO.EnterString("Введите запах");
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Name = flowerNameExamples[rnd.Next( flowerNameExamples.Length)];
            Smell = smellExamples[rnd.Next(smellExamples.Length)];
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Flower flower)
                return Name == flower.Name && Color == flower.Color && Smell==flower.Smell;
            return false;
        }
    }
}
