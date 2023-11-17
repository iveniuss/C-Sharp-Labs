using System;

namespace lab3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int n = 40;
            const double e = 0.0001;
            const double a = 0.1;
            const double b = 0.8;
            double SumN(double x)
            {
                double sum = 0;
                double z = x;
                double c;
                for (int i = 1; i <= n; i++)
                {
                    c = z * Math.Sin(i*Math.PI / 4);
                    sum += c;
                    z *= x;
                }

                return sum;
            }

            double SumE(double x)
            {
                double sum = 0;
                double z = x;
                double c;
                int i = 1;
                do
                {
                    if (i % 4 == 0)
                        c = 0;
                    else
                        c = z * Math.Sin(i * Math.PI / 4);
                    sum += c;
                    i++;
                    z *= x;
                    
                } while (Math.Abs(c) > e || c==0);
                
                return sum;
            }
            double step = (b - a) / 10;
            for (double x = a;x < b; x += step)
            {
                Console.WriteLine($"x={x}; " +
                                  $"y={Math.Round(x*Math.Sin(Math.PI/4)/(1-2*x*Math.Cos(Math.PI/4)+x*x),4)}; " +
                                  $"sum(n)={Math.Round(SumN(x),4)}; " +
                                  $"sum(e)={Math.Round(SumE(x),4)}");

            }
        }
    }
}