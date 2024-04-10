namespace ClassLibLab10
{
    public class Rose : Flower, IInit, ICloneable, IGetBase
    {

        protected bool isSpiked;
        public static int RoseNum { get; protected set; }

        public bool IsSpiked { get; set; }

        new public Plant GetBase()
        {
            return new Plant(this);
        }
        public Rose() : base()
        {
            RoseNum++;
            FlowerNum--;
            IsSpiked = false;
        }

        public Rose(string name, string color, string smell, bool isSpiked) : base(name, color, smell)
        {
            RoseNum++;
            FlowerNum--;
            IsSpiked = isSpiked;
        }

        public Rose(Rose rose) : base(rose)
        {
            RoseNum++;
            FlowerNum--;
            IsSpiked = rose.IsSpiked;
        }

        public new void Show()
        {
            IO.Write($"Название розы: {Name}, Цвет розы: {Color}, Запах: {Smell}, Шипы: {(IsSpiked ? "Да" : "Нет")}");
        }

        public override string ToString()
        {
            return $"Название розы: {Name}, Цвет розы: {Color}, Запах: {Smell}, Шипы: {(IsSpiked ? "Да" : "Нет")}";
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
                return Name == rose.Name && Color == rose.Color && Smell == rose.Smell && IsSpiked == rose.IsSpiked;
            return false;
        }
        public override object Clone()
        {
            return new Rose(this);
        }

        public override Rose ShallowCopy()
        {
            return (Rose)MemberwiseClone();
        }

    }

}
