using System;
using System.Collections.Generic;
using System.Text;

namespace Endless.Core
{
    public class AreaEffect
    {
        public readonly string id;
        public readonly Point origin;
        public readonly double radius;
        public readonly double power;

        public AreaEffect(string id, Point origin, double radius, double power)
        {
            this.id = id;
            this.origin = origin;
            this.radius = radius;
            this.power = power;
        }

        public double PowerAt(Point point)
        {
            var distance = point.Distance(origin);
            if (distance > radius) return 0;

            return (1 - distance / radius) * power;
        }
    }
}
