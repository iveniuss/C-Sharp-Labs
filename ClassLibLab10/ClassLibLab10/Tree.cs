

namespace ClassLibLab10
{
    public class Tree : Plant, IInit, ICloneable, IGetBase
    {

        string[] treeNameExamples = { "Дуб", "Береза", "Ель", "Пихта", "Баобаб", "Секвоя","Тополь","Клен"};

        protected int height;
        public static int TreeNum { get; protected set; }

        public Plant GetBase()
        {
            return new Plant(this);
        }

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
            TreeNum++;
            PlantNum--;
            height = 0;
        }

        public Tree(string name, string color, int height):base(name, color)
        {
            TreeNum++;
            PlantNum--;
            Height = height;
        }
        public Tree(Tree tree) : base(tree)
        {
            TreeNum++;
            PlantNum--;
            Height = tree.Height;
        }

        public new void Show()
        {
            IO.Write($"Название дерева: {Name}, Цвет: {Color}, Высота: {Height}");
        }
        public override string ToString()
        {
            return ($"Название дерева: {Name}, Цвет: {Color}, Высота: {Height}");
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
        public override object Clone()
        {
            return new Tree(this);
        }
        public override Tree ShallowCopy()
        {
            return (Tree)MemberwiseClone();
        }
    }

    
}
