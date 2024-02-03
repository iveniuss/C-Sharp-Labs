using System;
using System.Data.SqlTypes;

namespace Lab9
{
    public class PostCollection
    {

        static Random rnd = new Random();

        Post[] _posts;

        public int Lenght
        {
            get => _posts.Length;
        }

        public Post this[int index]
        {
            get
            {
                if (index >= 0 && index < _posts.Length)
                    return _posts[index];
                throw new IndexOutOfRangeException();
            }
            set
            {
                if(index >= 0 && index < _posts.Length)
                    _posts[index] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        }
        public PostCollection() //Конструктор без параметров
        {
            _posts = new Post[1];
            _posts[0] = new Post(0,0,0);
        }

        public PostCollection(int length, bool isKeyboard = false) //Конструктор рандомной генерации
        {
            _posts = new Post[length];
            for(int i = 0; i < length; i++)
            {
                if (isKeyboard)
                    _posts[i] = new Post(inputoutput.EnterIntNumber("Введите число просмотров"), inputoutput.EnterIntNumber("Введите число комментариев"), inputoutput.EnterIntNumber("Введите число реакций"));
                else
                    _posts[i] = new Post(rnd.Next(1000), rnd.Next(1000), rnd.Next(1000));
            }
        }
        public PostCollection(PostCollection postCol)
        {
            _posts = new Post[postCol.Lenght];
            for(int i=0;  i < postCol.Lenght; i++)
            {
                _posts[i] = new Post(postCol[i].Views, postCol[i].Comments, postCol[i].Reactions);
            }
            
        }

        public void Show()
        {
            for(int i=0; i < Lenght; i++)
                Console.WriteLine((Post)_posts[i]+"\n");
        }
       
    }
}
