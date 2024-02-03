using Lab9;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPost()
        {
            // Arrange
            Post expectedPost1 = new Post(0, 0, 0);
            Post expectedPost2 = new Post(400, 400, 199);
            Post expectedPost3 = new Post(401, 400, 200);
            string expectedString2 = "Просмотров: 400 Комментариев: 400 Реакций: 199";
            double expectedEngRate2 = 99.9;
            double expectedEngRate3 = 100.0;


            // Act
            Post post1 = new Post();
            post1.Comments = -100;
            post1.Views = -100;
            Post post2 = new Post(400, 500, 500);
            post2.Reactions = -100;
            post2.Reactions = 199;
            Post post3 = new Post(post2);
            post3++;
            post3 = !post3;

            // Assert
            Assert.AreEqual(post1, expectedPost1);
            Assert.IsTrue(post2 == expectedPost2);
            Assert.IsTrue(post2 != expectedPost3);
            Assert.AreEqual(expectedEngRate2, (double)post2);
            Assert.AreEqual(expectedEngRate3, (double)post3);
            Assert.AreEqual(Post.EngRateStatic(post3), expectedEngRate3);
            Assert.AreNotEqual(post2, post3);
            Assert.IsTrue(post2);
            Assert.AreEqual(post2.ToString(), expectedString2);
            
        }
        [TestMethod]
        public void TestPostCollection()
        {
            //Arrange
            Post[] posts1 = { new Post() };
            PostCollection expectedPostCol1 = new PostCollection(posts1);

            //Act
            PostCollection postCol1 = new PostCollection();
            Post[] posts2 = { new Post(345, 234, 123), new Post(573, 234, 130), new Post(121, 76, 45) };
            PostCollection PostCol2 = new PostCollection(posts2);

            //Assert 
            Assert.AreEqual(expectedPostCol1, postCol1);
            Assert.AreNotEqual(expectedPostCol1, PostCol2 );




        }
    }
}