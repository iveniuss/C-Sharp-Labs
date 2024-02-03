using System;
using System.Data.SqlTypes;

namespace Lab9
{
    public class PostCollection
    {

        static Random rnd = new Random();

        private Post[] posts;

        public int Length
        {
            get => posts.Length;
        }

        public static int ColNum { get; private set; }

        public Post this[int index]
        {
            get
            {
                if (index >= 0 && index < posts.Length)
                    return posts[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if(index >= 0 && index < posts.Length)
                    posts[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public PostCollection() //Конструктор без параметров
        {
            posts = new Post[1];
            posts[0] = new Post(0,0,0);
            ColNum++;
        }

        public PostCollection(int length, bool isKeyboard = false) //Конструктор рандомной генерации
        {
            posts = new Post[length];
            for(int i = 0; i < length; i++)
            {
                if (isKeyboard)
                    posts[i] = new Post(inputoutput.EnterIntNumber("Введите число просмотров"), inputoutput.EnterIntNumber("Введите число комментариев"), inputoutput.EnterIntNumber("Введите число реакций"));
                else
                    posts[i] = new Post(rnd.Next(1000), rnd.Next(1000), rnd.Next(1000));
            }

            ColNum++;
        }
        public PostCollection(PostCollection postCol)
        {
            posts = new Post[postCol.Length];
            for(int i=0;  i < postCol.Length; i++)
            {
                posts[i] = new Post(postCol[i].Views, postCol[i].Comments, postCol[i].Reactions);
            }

            ColNum++;

        }

        public void Show()
        {
            for(int i=0; i < Length; i++)
                Console.WriteLine((Post)posts[i]+"\n");
        }

        public double EngRate()
        {
            double rate = 0;
            for (int i = 0; i < Length; i++)
            {
                rate += (double)posts[i];
            }

            return rate / Length;
        }
       
    }
}
