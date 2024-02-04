using Lab9;

namespace Tests
{
    [TestClass]
    public class PostTest
    {
        [TestMethod]
        public void EmptyConstructorTest()
        {
            //Arrange
            int expectedViews = 0;
            int expectedComments = 0;
            int expectedReactions = 0;

            //Act
            Post post = new Post();

            //Assert
            Assert.AreEqual(expectedViews, post.Views);
            Assert.AreEqual(expectedComments, post.Comments);
            Assert.AreEqual(expectedReactions, post.Reactions);
        }

        [TestMethod]
        public void ParameterContructorTest1() //Если значения реакций и комментариев больше просмотров
        {
            //Arrange
            int expectedViews = 100;
            int expectedComments = 100;
            int expectedReactions = 100;

            //Act
            Post post = new Post(100, 120, 120);

            //Assert
            Assert.AreEqual(expectedViews, post.Views);
            Assert.AreEqual(expectedComments, post.Comments);
            Assert.AreEqual(expectedReactions, post.Reactions);
        }

        [TestMethod]
        public void ParameterContructorTest2() //Если отрицательные значения
        {
            //Arrange
            int expectedViews = 0;
            int expectedComments = 0;
            int expectedReactions = 0;

            //Act
            Post post = new Post(-100, -100, -100);

            //Assert
            Assert.AreEqual(expectedViews, post.Views);
            Assert.AreEqual(expectedComments, post.Comments);
            Assert.AreEqual(expectedReactions, post.Reactions);
        }

        [TestMethod]
        public void CopyContructorPost()
        {
            //Arrange
            Post p1 = new Post(789, 456, 123);
            Post p2 = new Post(p1);
            Post expectedP2 = new Post(789, 456, 124);

            //Act
            p2.Reactions += 1;

            //Assert
            Assert.AreNotEqual(p1, p2);
            Assert.AreEqual(expectedP2, p2);
        }

        [TestMethod]
        public void ToStringTest()
        {
            //Arrange
            Post post = new Post(987, 654, 321);

            //Act
            string str = "Просмотров: 987 Комментариев: 654 Реакций: 321";

            //Assert
            Assert.AreEqual(str, post.ToString());
        }

        [TestMethod]
        public void OperatorTest1() //Оператор !
        {
            //Arrange
            Post post = new Post(987, 654, 321);
            Post expectedPost = new Post(987, 654, 322);

            //Act
            post = !post;

            //Assert
            Assert.AreEqual(expectedPost, post);
        }

        [TestMethod]
        public void OperatorTest2() //Оператор ++
        {
            //Arrange
            Post post = new Post(987, 654, 321);
            Post expectedPost = new Post(988, 654, 321);

            //Act
            post++;

            //Assert
            Assert.AreEqual(expectedPost, post);
        }

        [TestMethod]
        public void OperatorTest3() //Оператор ==
        {
            //Arrange
            Post post1 = new Post(987, 654, 321);
            Post post2 = new Post(post1);
            Post post3 = new Post();

            //Act
            bool post12 = post1 == post2;
            bool post23 = post2 == post3;

            //Assert
            Assert.IsTrue(post12);
            Assert.IsFalse(post23);
        }

        [TestMethod]
        public void OperatorTest4() //Оператор !=
        {
            //Arrange
            Post post1 = new Post(987, 654, 321);
            Post post2 = new Post(post1);
            Post post3 = new Post();

            //Act
            bool post12 = post1 != post2;
            bool post23 = post2 != post3;

            //Assert
            Assert.IsFalse(post12);
            Assert.IsTrue(post23);
        }



        [TestMethod]
        public void EngRateTest1()
        {
            //Arrange
            Post post = new Post(345, 234, 123);
            double expectedEngRate = 70.2;

            //Act
            double engRate1 = post.EngRate();
            double engRate2 = Post.EngRateStatic(post);

            //Assert
            Assert.AreEqual(expectedEngRate, engRate1);
            Assert.AreEqual(expectedEngRate, engRate2);
        }

        [TestMethod]
        public void EngRateTest2()
        {
            //Arrange
            Post post = new Post(545, 434, 323);
            double expectedEngRate = 100.0;

            //Act
            double engRate1 = post.EngRate();
            double engRate2 = Post.EngRateStatic(post);

            //Assert
            Assert.AreEqual(expectedEngRate, engRate1);
            Assert.AreEqual(expectedEngRate, engRate2);
        }

        [TestMethod]
        public void ConversionOperatorTest1() //Явное преобразование в bool
        {
            //Arrange
            Post post1 = new Post(345, 234, 123);
            Post post2 = new Post();

            //Asssert
            Assert.IsTrue(post1);
            Assert.IsFalse(post2);
        }

        [TestMethod]
        public void ConversionOperatorTest2() //Неявное преобразоваие в double
        {
            Post post = new Post(345, 234, 123);
            double expectedEngRate = 70.2;

            //Assert
            Assert.AreEqual(expectedEngRate, (double)post);
        }
    }

    [TestClass]
    public class PostCollectionTest
    {
        [TestMethod]
        public void EmptyContructorTest()
        {
            //Arrange
            int expectedLength = 1;
            int expectedViews = 0;
            int expectedComments = 0;
            int expectedReactions = 0;

            //Act
            PostCollection posts = new PostCollection();

            //Assert
            Assert.AreEqual(expectedLength, posts.Length);
            Assert.AreEqual(expectedViews, posts[0].Views);
            Assert.AreEqual(expectedComments, posts[0].Comments);
            Assert.AreEqual(expectedReactions, posts[0].Reactions);
        }

        [TestMethod]
        public void ParameterContructorTest()
        {
            //Arrange
            int expectedLength = 3;
            Post[] expectedPosts = { new Post(345, 234, 123), new Post(456, 345, 234), new Post(567, 456, 345) };

            //Act
            PostCollection posts = new PostCollection(expectedPosts);

            //Assert
            Assert.AreEqual(expectedLength, posts.Length);
            for (int i = 0; i < posts.Length; i++)
                Assert.AreEqual(expectedPosts[i], posts[i]);
        }

        [TestMethod]
        public void CopyContructorTest()
        {
            //Arrange
            Post[] postsArr = { new Post(345, 234, 123), new Post(456, 345, 234), new Post(567, 456, 345) };
            PostCollection posts1 = new PostCollection(postsArr);
            PostCollection posts2 = new PostCollection(posts1);
            PostCollection posts3 = new PostCollection(posts2);

            //Act
            posts3[0]++;

            //Assert
            Assert.AreEqual(posts1.Length, posts2.Length);
            for (int i = 0; i < posts1.Length; i++)
                Assert.AreEqual(posts1[i], posts2[i]);
            Assert.AreNotEqual(posts2, posts3);
        }

        [TestMethod]
        public void IndexerSetTest() 
        {
            //Arrange
            Post[] postsArr = { new Post(345, 234, 123), new Post(456, 345, 234), new Post(567, 456, 345) };
            PostCollection posts1 = new PostCollection(postsArr);
            PostCollection posts2 = new PostCollection(posts1);

            //Act
            posts1[10] = new Post();

            //Assert
            Assert.AreEqual(posts1,posts2);
        }

        [TestMethod]
        public void IndexerGetTest()
        {
            //Arrange
            Post[] postsArr = { new Post(345, 234, 123), new Post(456, 345, 234), new Post(567, 456, 345) };
            PostCollection posts = new PostCollection(postsArr);

            //Assert
            Assert.ThrowsException<IndexOutOfRangeException>(() => posts[10]);
        }


        [TestMethod]
        public void ToStringTest()
        {
            //Arrange
            Post[] postsArr = { new Post(345, 234, 123), new Post(456, 345, 234), new Post(567, 456, 345) };
            PostCollection posts = new PostCollection(postsArr);
            string expectedStr = "Просмотров: 345 Комментариев: 234 Реакций: 123\nПросмотров: 456 Комментариев: 345 Реакций: 234\nПросмотров: 567 Комментариев: 456 Реакций: 345";

            //Act
            string Str = posts.ToString();

            //Assert
            Assert.AreEqual(expectedStr, Str);
        }

        [TestMethod]
        public void EngRate()
        {
            //Arrange
            Post[] postsArr = { new Post(345, 234, 123), new Post(456, 345, 234), new Post(567, 456, 345) };
            PostCollection posts = new PostCollection(postsArr);
            double expectedEngRate = 90.07;

            //Act
            double engRate = posts.EngRate();

            //Assert
            Assert.AreEqual(expectedEngRate, engRate); 

        }


    }
}