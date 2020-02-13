using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Star_Wars_Trading_Game
{
    class World
    {
        double x;
        double y;
        public string Name { get; set; }


        public World(double x, double y, string name)
        {
            this.x = x;
            this.y = y;
            this.Name = name;
        }


        public double DistanceTo(World other)
        {
            var deltaX = Math.Abs(this.x - other.x);
            var deltaY = Math.Abs(this.y - other.y);

            var result = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            return result;
        }
    }
}
