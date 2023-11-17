using System;

namespace task3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            float aFloat, bFloat;
            double aDouble, bDouble;
            aDouble = 1000;
            bDouble = 0.0001;
            aFloat = (float)aDouble;
            bFloat = (float)bDouble;
            
            float xFloat, yFloat, zFloat, resFloat;
            
            xFloat = (float)Math.Pow(aFloat + bFloat, 3);
            yFloat = (float)Math.Pow(aFloat, 3) + 3 * (float)Math.Pow(aFloat, 2) * bFloat;
            zFloat = (float)(3 * aFloat * Math.Pow(bFloat, 2)) + (float)Math.Pow(bFloat, 3);
            resFloat = (xFloat - yFloat) / zFloat;
            
            double xDouble, yDouble, zDouble, resDouble;
            
            xDouble = Math.Pow(aDouble + bDouble, 3);
            yDouble = Math.Pow(aDouble, 3) + 3 * Math.Pow(aDouble,2) * bDouble;
            zDouble = 3 * aDouble * Math.Pow(bDouble, 2) + Math.Pow(bDouble, 3);
            resDouble = (xDouble - yDouble) / zDouble;
            
            Console.WriteLine($"Результат при типе данных float: {resFloat}; a={aFloat}; b={bFloat}");
            Console.WriteLine($"Результат при типе данных double: {resDouble}; a={aDouble}; a={bDouble}");
        }
    }
}