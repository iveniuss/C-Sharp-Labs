using ClassLibLab10;

namespace Lab10Tests
{
    [TestClass]
    public class ClassPlant
    {
        [TestMethod]
        public void NameNullTest()
        {
            string expectedName = "";
            Plant plant = new Plant();

            plant.Name = null;

            Assert.AreEqual(expectedName, plant.Name);
        }

        [TestMethod]
        public void ColorNullTest()
        {
            string expectedColor = "";
            Plant plant = new Plant();

            plant.Color = null;

            Assert.AreEqual(expectedColor, plant.Color);
        }
        [TestMethod]
        public void RosesWithoutSpikesTest()
        {
            Plant[] plants = new Plant[] { new Plant("Картофель", "Желтый"),
                                           new Tree("Дуб", "Коричневый", 60),
                                           new Flower("Ромашка", "Белый", "Сладкий"),
                                           new Rose("Роза", "Красный", "Терпкий", true),
                                           new Rose("Роза", "Белый", "Сладкий", false) };
            string expectedroses = "Название розы: Роза, Цвет: Белый, Запах: Сладкий";

            string roses = Plant.RosesWithoutSpikes(plants);

            Assert.AreEqual(expectedroses, roses);
        }
        [TestMethod]
        public void SmallestTreeTest1() //Если дерево есть в списке
        {
            Tree expectedTree = new Tree("Дуб", "Коричневый", 35);
            Plant[] plants = new Plant[] { new Plant("Картофель", "Желтый"),
                                           expectedTree,
                                           new Flower("Ромашка", "Белый", "Сладкий"),
                                           new Rose("Роза", "Красный", "Терпкий", true),
                                           new Tree("Ель", "Зеленый", 50) };

            Tree tree = Plant.SmallestTree(plants);

            Assert.AreEqual(expectedTree, tree);
        }

        [TestMethod]
        public void SmallestTreeTest2() //Если дерева нет в списке
        {
            Plant[] plants = new Plant[] { new Plant("Картофель", "Желтый"),
                                           new Flower("Ромашка", "Белый", "Сладкий"),
                                           new Rose("Роза", "Красный", "Терпкий", true) };

            Assert.ThrowsException<ArgumentException>(() => Plant.SmallestTree(plants));
        }

        [TestMethod]
        public void FlowersBySmellTest()
        {
            string smell = "Сладкий";
            Plant[] plants = new Plant[] { new Plant("Картофель", "Желтый"),
                                           new Tree("Дуб", "Коричневый", 60),
                                           new Flower("Ромашка", "Белый", "Сладкий"),
                                           new Rose("Роза", "Красный", "Терпкий", true),
                                           new Rose("Роза", "Белый", "Сладкий", false) };
            string expectedFlowers = "Ромашка\nРоза";

            string flowers = Plant.FlowersBySmell(plants,smell);

            Assert.AreEqual(expectedFlowers, flowers);

        }
    }

    [TestClass]
    public class ClassRose
    {
        [TestMethod]
        public void SmellNullTest()
        {
            string expectedSmell = "";
            Rose rose = new Rose();

            rose.Smell = null;

            Assert.AreEqual(expectedSmell, rose.Smell);
        }

        [TestMethod]
        public void Constructor1() //Пустой конструктор
        {
            string expectedName = "Без названия";
            string expectedColor = "Неизвестен";
            string expectedSmell = "Неизвестен";
            bool expectedIsSpiked = false;

            Rose rose = new Rose();

            Assert.AreEqual(expectedName, rose.Name);
            Assert.AreEqual(expectedColor, rose.Color);
            Assert.AreEqual(expectedSmell, rose.Smell);
            Assert.AreEqual(expectedIsSpiked, rose.IsSpiked);
        }

        [TestMethod]
        public void Constructor2() //Конструктор с параматрами
        {
            string expectedName = "Роза";
            string expectedColor = "Красный";
            string expectedSmell = "Сладкий";
            bool expectedIsSpiked = true;

            Rose rose = new Rose("Роза", "Красный", "Сладкий", true);

            Assert.AreEqual(expectedName, rose.Name);
            Assert.AreEqual(expectedColor, rose.Color);
            Assert.AreEqual(expectedSmell, rose.Smell);
            Assert.AreEqual(expectedIsSpiked, rose.IsSpiked);
        }

        [TestMethod]
        public void Constructor3() //Коструктор копирования
        {
            Rose r1 = new Rose("Роза", "Красный", "Сладкий", true);
            Rose r2 = new Rose(r1);

            Assert.AreEqual(r1, r2);
        }
    }
    [TestClass]
    public class ClassTree
    {
        [TestMethod]
        public void PropertyHeight()
        {
            int expectedHeight1 = 0;
            int expectedHeight2 = 150;
            Tree t1 = new Tree();
            Tree t2 = new Tree();

            t1.Height = -10;
            t2.Height = 200;

            Assert.AreEqual(expectedHeight1, t1.Height);
            Assert.AreEqual(expectedHeight2, t2.Height);


        }

        [TestMethod]
        public void Constructor1() //Пустой конструктор
        {
            string expectedName = "Без названия";
            string expectedColor = "Неизвестен";
            int expectedHeight = 0;

            Tree tree = new Tree();

            Assert.AreEqual(expectedName, tree.Name);
            Assert.AreEqual(expectedColor, tree.Color);
            Assert.AreEqual(expectedHeight, tree.Height);
        }

        [TestMethod]
        public void Constructor2() //Конструктор с параматрами
        {
            string expectedName = "Дуб";
            string expectedColor = "Коричневый";
            int expectedHeight = 25;

            Tree tree = new Tree("Дуб","Коричневый",25);

            Assert.AreEqual(expectedName, tree.Name);
            Assert.AreEqual(expectedColor, tree.Color);
            Assert.AreEqual(expectedHeight, tree.Height);
        }

        [TestMethod]
        public void Constructor3() //Конструктор копирования
        {
            Tree t1 = new Tree("Дуб", "Коричневый", 25);
            Tree t2 = new Tree(t1);

            Assert.AreEqual(t1, t2);
        }
    }
}