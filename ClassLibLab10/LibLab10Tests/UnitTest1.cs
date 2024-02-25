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
            Plant[] plants = new Plant[] { new Plant("���������", "������"),
                                           new Tree("���", "����������", 60),
                                           new Flower("�������", "�����", "�������"),
                                           new Rose("����", "�������", "�������", true),
                                           new Rose("����", "�����", "�������", false) };
            string expectedroses = "�������� ����: ����, ����: �����, �����: �������";

            string roses = Plant.RosesWithoutSpikes(plants);

            Assert.AreEqual(expectedroses, roses);
        }
        [TestMethod]
        public void SmallestTreeTest1() //���� ������ ���� � ������
        {
            Tree expectedTree = new Tree("���", "����������", 35);
            Plant[] plants = new Plant[] { new Plant("���������", "������"),
                                           expectedTree,
                                           new Flower("�������", "�����", "�������"),
                                           new Rose("����", "�������", "�������", true),
                                           new Tree("���", "�������", 50) };

            Tree tree = Plant.SmallestTree(plants);

            Assert.AreEqual(expectedTree, tree);
        }

        [TestMethod]
        public void SmallestTreeTest2() //���� ������ ��� � ������
        {
            Plant[] plants = new Plant[] { new Plant("���������", "������"),
                                           new Flower("�������", "�����", "�������"),
                                           new Rose("����", "�������", "�������", true) };

            Assert.ThrowsException<ArgumentException>(() => Plant.SmallestTree(plants));
        }

        [TestMethod]
        public void FlowersBySmellTest()
        {
            string smell = "�������";
            Plant[] plants = new Plant[] { new Plant("���������", "������"),
                                           new Tree("���", "����������", 60),
                                           new Flower("�������", "�����", "�������"),
                                           new Rose("����", "�������", "�������", true),
                                           new Rose("����", "�����", "�������", false) };
            string expectedFlowers = "�������\n����";

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
        public void Constructor1() //������ �����������
        {
            string expectedName = "��� ��������";
            string expectedColor = "����������";
            string expectedSmell = "����������";
            bool expectedIsSpiked = false;

            Rose rose = new Rose();

            Assert.AreEqual(expectedName, rose.Name);
            Assert.AreEqual(expectedColor, rose.Color);
            Assert.AreEqual(expectedSmell, rose.Smell);
            Assert.AreEqual(expectedIsSpiked, rose.IsSpiked);
        }

        [TestMethod]
        public void Constructor2() //����������� � �����������
        {
            string expectedName = "����";
            string expectedColor = "�������";
            string expectedSmell = "�������";
            bool expectedIsSpiked = true;

            Rose rose = new Rose("����", "�������", "�������", true);

            Assert.AreEqual(expectedName, rose.Name);
            Assert.AreEqual(expectedColor, rose.Color);
            Assert.AreEqual(expectedSmell, rose.Smell);
            Assert.AreEqual(expectedIsSpiked, rose.IsSpiked);
        }

        [TestMethod]
        public void Constructor3() //���������� �����������
        {
            Rose r1 = new Rose("����", "�������", "�������", true);
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
        public void Constructor1() //������ �����������
        {
            string expectedName = "��� ��������";
            string expectedColor = "����������";
            int expectedHeight = 0;

            Tree tree = new Tree();

            Assert.AreEqual(expectedName, tree.Name);
            Assert.AreEqual(expectedColor, tree.Color);
            Assert.AreEqual(expectedHeight, tree.Height);
        }

        [TestMethod]
        public void Constructor2() //����������� � �����������
        {
            string expectedName = "���";
            string expectedColor = "����������";
            int expectedHeight = 25;

            Tree tree = new Tree("���","����������",25);

            Assert.AreEqual(expectedName, tree.Name);
            Assert.AreEqual(expectedColor, tree.Color);
            Assert.AreEqual(expectedHeight, tree.Height);
        }

        [TestMethod]
        public void Constructor3() //����������� �����������
        {
            Tree t1 = new Tree("���", "����������", 25);
            Tree t2 = new Tree(t1);

            Assert.AreEqual(t1, t2);
        }
    }
}