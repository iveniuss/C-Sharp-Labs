﻿using System;

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
                if (index >= 0 && index < posts.Length)
                    posts[index] = value;
            }
        }
        public PostCollection()
        {
            posts = new Post[1];
            posts[0] = new Post(0, 0, 0);
            ColNum++;
        }

        public PostCollection(int length)
        {
            posts = new Post[length];
            for (int i = 0; i < length; i++)
            {
                int views = rnd.Next(1000);
                int comments = rnd.Next(views);
                int reactions = rnd.Next(views);
                posts[i] = new Post(views, comments, reactions);
            }

            ColNum++;
        }

        public PostCollection(Post[] posts)
        {
            this.posts = new Post[posts.Length];
            for (int i = 0; i < posts.Length; i++)
                this.posts[i] = posts[i];
            ColNum++;
        }


        public PostCollection(PostCollection postCol)
        {
            posts = new Post[postCol.Length];
            for (int i = 0; i < postCol.Length; i++)
            {
                posts[i] = new Post(postCol[i].Views, postCol[i].Comments, postCol[i].Reactions);
            }

            ColNum++;

        }

        public override bool Equals(object obj)
        {
            if (obj is PostCollection postCol)
            {
                if (postCol.Length != this.Length)
                    return false;
                for (int i = 0; i < this.Length; i++)
                    if (this[i] != postCol[i])
                        return false;
                return true;
            }
            return false;
        }


        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Length; i++)
            {
                str += (Post)posts[i];
                if (i < Length - 1)
                    str += "\n";
            }
            return str;
        }

        public double EngRate()
        {
            double rate = 0;
            for (int i = 0; i < Length; i++)
            {
                rate += (double)posts[i];
            }

            return Math.Round(rate / Length,2);
        }

    }
}
