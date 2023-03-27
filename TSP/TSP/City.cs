using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class City
    {
        Vector2 position;
        string name;

        public City(Vector2 position, string name)
        {
            this.Position = position;
            this.Name = name;
        }

        public string Name { get => name; set => name = value; }
        internal Vector2 Position { get => position; set => position = value; }

        public override string ToString()
        {
            return $"{name}\n Position: {position.X}; {position.Y}\n-------------------";
        }
    }
}
