using ClassLibLab10;

namespace Lab10Tests
{
    [TestClass]
    public class ClassPlant
    {
        [TestMethod]
        public void ToStringTest()
        {
            string expectedString = "��������: ����, ����: �������, id: 0";
            Plant plant = new Plant("����", "�������");

            string str = plant.ToString();

            Assert.AreEqual(expectedString, str);
        }

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
        public void FlowersBySmellTest() //���� ����� ���� � ������
        {
            string existingSmell = "�������";
            Plant[] plants = [ new Plant("���������", "������"),
                                           new Tree("���", "����������", 60),
                                           new Flower("�������", "�����", "�������"),
                                           new Rose("����", "�������", "�������", true),
                                           new Rose("����", "�����", "�������", false) ];
            string expectedFlowers = "�������\n����";

            string flowers1 = Plant.FlowersBySmell(plants,existingSmell);
            

            Assert.AreEqual(expectedFlowers, flowers1);

        }
        [TestMethod]
        public void FlowersBySmellTest2() //���� ������ ��� � ������
        {
            string notExistingSmell = "������";
            Plant[] plants = [ new Plant("���������", "������"),
                                           new Tree("���", "����������", 60),
                                           new Flower("�������", "�����", "�������"),
                                           new Rose("����", "�������", "�������", true),
                                           new Rose("����", "�����", "�������", false) ];
            string error = "� ������ ��� ������ � ����� �������";
            string flowers2 = Plant.FlowersBySmell(plants, notExistingSmell);

            Assert.AreEqual(error, flowers2);



        }

        [TestMethod]
        public void CompareToTest()
        {
            Plant p1 = new Plant("A", "");
            Plant p2 = new Plant("�", "");
            int expectedComp = 1;

            int comp = p1.CompareTo(p2);

            Assert.AreEqual(expectedComp, comp);
        }

        [TestMethod]
        public void CloneTest()
        {
            Plant p1 = new Plant();
            p1.RandomInit();

            Plant p2 = ( Plant )p1.Clone();

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void ShallowCopyTest()
        {
            Plant p1 = new Plant();
            p1.RandomInit();

            Plant p2 = p1.ShallowCopy();

            Assert.AreEqual(p1, p2);
        }
    }

    [TestClass]
    public class ClassRose
    {
        [TestMethod]
        public void ToStringTest()
        {
            string expectedString = "�������� ����: ����, ���� ����: �������, �����: �������, ����: ��";
            Rose rose = new Rose("����", "�������", "�������", true);

            string str = rose.ToString();

            Assert.AreEqual(expectedString, str);
        }

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

        [TestMethod]
        public void CloneTest()
        {
            Rose p1 = new Rose();
            p1.RandomInit();

            Rose p2 = (Rose)p1.Clone();

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void ShallowCopyTest()
        {
            Rose p1 = new Rose();
            p1.RandomInit();

            Rose p2 = p1.ShallowCopy();

            Assert.AreEqual(p1, p2);
        }
    }

    [TestClass]
    public class ClassFlower
    {
        [TestMethod]
        public void ToStringTest()
        {
            string expectedString = "�������� ������: ����, ����: �������, �����: �������";
            Flower flower = new Flower("����", "�������", "�������");

            string str = flower.ToString();

            Assert.AreEqual(expectedString, str);
        }

        [TestMethod]
        public void CloneTest()
        {
            Flower p1 = new Flower();
            p1.RandomInit();

            Flower p2 = (Flower)p1.Clone();

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void ShallowCopyTest()
        {
            Flower p1 = new Flower();
            p1.RandomInit();

            Flower p2 = p1.ShallowCopy();

            Assert.AreEqual(p1, p2);
        }
    }
    [TestClass]
    public class ClassTree
    {
        [TestMethod]
        public void ToStringTest()
        {
            string expectedString = "�������� ������: ���, ����: �������, ������: 50";
            Tree tree = new Tree("���", "�������", 50);

            string str = tree.ToString();

            Assert.AreEqual(expectedString, str);
        }
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
        [TestMethod]
        public void CloneTest()
        {
            Tree p1 = new Tree();
            p1.RandomInit();

            Tree p2 = (Tree)p1.Clone();

            Assert.AreEqual(p1, p2);
        }

        [TestMethod]
        public void ShallowCopyTest()
        {
            Tree p1 = new Tree();
            p1.RandomInit();

            Tree p2 = p1.ShallowCopy();

            Assert.AreEqual(p1, p2);
        }
    }
}