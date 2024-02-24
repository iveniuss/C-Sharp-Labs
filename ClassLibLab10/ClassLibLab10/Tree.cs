

namespace ClassLibLab10
{
    public class Tree : Plant
    {
        static Random rnd = new Random();

        string[] treeNameExamples = { "Дуб", "Береза", "Ель", "Пихта", "Баобаб", "Секвоя","Тополь","Клен"};

        protected int height;

        public int Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                    height = 0;
                else if (value > 150)
                    height = 150;
                else
                    height = value;
            }
        }

        public Tree() : base()
        {
            height = 0;
        }

        public Tree(string name, string color, int height):base(name, color)
        {
            Height = height;
        }
        public Tree(Tree tree) : base(tree)
        {
            Height= tree.Height;
        }

        public new void Show()
        {
            IO.Write($"Название дерева: {Name}, Цвет: {Color}, Высота: {Height}");
        }
        public override void VirtualShow()
        {
            IO.Write($"Название дерева: {Name}, Цвет: {Color}, Высота: {Height}");
        }

        public override void Init()
        {
            base.Init();
            Height = IO.EnterIntNumber("Введите высоту", 0);
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Name = treeNameExamples[rnd.Next(treeNameExamples.Length)];
            Height = rnd.Next(0, 150);
        }

        public override bool Equals(object? obj)
        {
            if(obj != null && obj is Tree tree)
                return Name == tree.Name && Color == tree.Color && Height == tree.Height;
            return false;
        }
    }
}
