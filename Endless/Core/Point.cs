using System;

namespace Endless.Core
{
    public struct Point
    {
        public readonly double x;
        public readonly double y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public bool InBounds(int minX, int minY, int maxX, int maxY)
        {
            return x >= minX
                   && x <= maxX
                   && y >= minY
                   && y <= maxY;
        }

        public double Distance(Point other)
        {
            return Math.Sqrt((x - other.x) * (x - other.x) + (y - other.y) * (y - other.y));
        }
    }
}
