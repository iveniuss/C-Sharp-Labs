using ClassLibLab10;

namespace Lab10Tests
{
    [TestClass]
    public class ClassRose
    {
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