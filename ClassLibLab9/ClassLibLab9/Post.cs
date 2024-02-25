using ClassLibLab10;

namespace ClassLibLab9
{
    public class Post: IInit
    {
        static Random rnd = new Random();

        private int _views, _comments, _reactions;

        public static int ObjNum { get; private set; }

        public int Views
        {
            set
            {
                if (value < 0)
                    _views = 0;
                else
                    _views = value;
            }
            get => _views;
        }
        public int Comments
        {
            set
            {
                if (value > _views)
                {
                    _comments = _views;
                }
                else if(value < 0)
                {
                    _comments = 0;
                }
                else
                    _comments = value;
            }
            get => _comments;
        }
        public int Reactions
        {
            set
            {
                if (value > _views)
                {
                    _reactions = _views;
                }
                else if (value < 0)
                {
                    _reactions = 0;
                }
                else
                    _reactions = value;
            }
            get => _reactions;
        }

        public Post(int views, int comments, int reactions)
        {
            Views = views;
            Comments = comments;
            Reactions = reactions;
            ObjNum++;
        }

        public Post()
        {
            Views = 0;
            Comments = 0;
            Reactions = 0;
            ObjNum++;
        }

        public Post(Post post)
        {
            Views = post.Views;
            Comments = post.Comments;
            Reactions = post.Reactions;
            ObjNum++;

        }

        public override string ToString()
        {
            return $"Просмотров: {Views} Комментариев: {Comments} Реакций: {Reactions}";
        }

        public static Post operator ++(Post post)
        {
            post.Views += 1;
            return post;
        }

        public static Post operator !(Post post)
        {
            post.Reactions += 1;
            return post;
        }

        public static bool operator ==(Post p1, Post p2)
        {
            return p1.Views == p2.Views && p1.Comments == p2.Comments && p1.Reactions == p2.Reactions;
        }

        public static bool operator !=(Post p1, Post p2)
        {
            return p1.Views != p2.Views || p1.Comments != p2.Comments || p1.Reactions != p2.Reactions;
        }

        public override bool Equals(object obj)
        {
            if (obj is Post p) return Views == p.Views && Comments == p.Comments && Reactions == p.Reactions;
            return false;
        }


        public double EngRate()
        {
            double engRate = (Views + Comments + Reactions) / 10.0;
            return engRate > 100 ? 100.0 : engRate;
        }

        public static double EngRateStatic(Post post)
        {
            double engRate = (post.Views + post.Comments + post.Reactions) / 10.0;
            return engRate > 100 ? 100.0 : engRate;
        }

        public static implicit operator bool(Post post)
        {
            return post.Reactions + post.Reactions > 0 && post.Views > 0;
        }

        public static explicit operator double(Post post)
        {
            return post.EngRate();
        }

        public void Init()
        {
            Views = IO.EnterIntNumber("Введите число просмотров");
            Comments = IO.EnterIntNumber("Введите число комментариев");
            Reactions = IO.EnterIntNumber("Введите число реакций");
        }

        public void RandomInit()
        {
            Views = rnd.Next(1000);
            Comments = rnd.Next(Views);
            Reactions = rnd.Next(Views);
        }
    }
}