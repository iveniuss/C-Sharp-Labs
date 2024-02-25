using System;
using System.Collections;

namespace ClassLibLab10
{
    public class ByColor: IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x == null || y == null)
                return -1;
            else if (x is Plant plantX && y is Plant plantY)
                return string.Compare(plantX.Color, plantY.Color);
            else
                return -1;
        }
    }
}
