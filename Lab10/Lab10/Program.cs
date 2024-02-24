using ClassLibLab10;

namespace Lab10
{
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            Plant[] plants = new Plant[20];
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
            foreach (Plant p in plants)
            {
                p.Show();
            }
            IO.WriteDividerLine();
            foreach(Plant p in plants)
            {
                p.VirtualShow();
            }

        }
    }
}
