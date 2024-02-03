using System;
using NUnit.Framework;
using Lab9;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            // Arrange
            Post expectedPost1 = new Post(0,0,0);
            Post expectedPost2 = new Post(250, 250, 222);
            Post expectedPost3 = new Post(251, 250, 223);
            double expectedEngRate3 = 72.4;
            
            
            // Act
            Post post1 = new Post();
            Post post2 = new Post(250, 300,222);
            Post post3 = new Post(post2);
            post3++;
            post3 = !post3;
            
            // Assert
            Assert.AreEqual(post1,expectedPost1);
            Assert.AreEqual(post2,expectedPost2);
            Assert.AreEqual(post3,expectedPost3);
            Assert.AreEqual((double)post3,expectedEngRate3);
            Assert.AreEqual(Post.EngRateStatic(post3),expectedEngRate3);
            Assert.AreNotEqual(post2,post3);


        }
    }
}