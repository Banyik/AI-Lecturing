using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Vector2
    {
        float x;
        float y;

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }
        public Vector2(double x, double y)
        {
            this.X = (float)x;
            this.Y = (float)y;
        }

        public float X { get => x; set => x = value; }
        public float Y { get => y; set => y = value; }

        public static float Distance(Vector2 a, Vector2 b)
        {
            return (float)Math.Sqrt(Math.Pow(b.x - a.x, 2) + Math.Pow(b.y - a.y, 2));
        }
    }
}
