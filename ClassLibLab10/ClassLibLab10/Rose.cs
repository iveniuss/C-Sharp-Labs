

namespace ClassLibLab10
{
    public class Rose:Flower
    {
        Random rnd = new Random();

        protected bool isSpiked;

        public bool IsSpiked
        {
            get => isSpiked;
            set => isSpiked = value;
        }

        public Rose() : base()
        {
            IsSpiked = false;
        }

        public Rose(string name,string color,string smell,bool isSpiked) : base(name, color, smell)
        {
            IsSpiked = isSpiked;
        }

        public Rose(Rose rose) : base(rose)
        {
            IsSpiked = rose.IsSpiked;
        }

        public new void Show()
        {
            IO.Write($"Название розы: {Name}, Цвет розы: {Color}, Запах: {Smell}, Шипы: {isSpiked}");
        }

        public override void VirtualShow()
        {
            IO.Write($"Название розы: {Name}, Цвет розы: {Color}, Запах: {Smell}, Шипы: {isSpiked}");
        }

        public override void Init()
        {
            base.Init();
            isSpiked = IO.EnterBool("Есть ли шипы");
            
        }
        public override void RandomInit()
        {
            base.RandomInit();
            Name = "Роза";
            isSpiked = rnd.Next(2) == 1;
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Rose rose)
                return Name == rose.Name && Color == rose.Color && Smell == rose.Smell && IsSpiked==rose.IsSpiked;
            return false;
        }
    }

}
