using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class State
    {
        List<City> cities = new List<City>();
        float distance;

        public float Distance { get => distance; set => distance = value; }
        internal List<City> Cities { get => cities; set => cities = value; }

        public State(int amount, int seed)
        {
            Random rnd = new Random(seed);
            for (int i = 0; i < amount; i++)
            {
                Cities.Add(new City(new Vector2(rnd.NextDouble() * 10, rnd.NextDouble() * 10), $"City {i}"));
            }
        }

        public bool IsTargetState()
        {
            if(Cities.Count < 1)
            {
                return true;
            }
            return false;
        }
    }
}
