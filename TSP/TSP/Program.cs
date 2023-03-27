using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Program
    {
        static void Main(string[] args)
        {
            State state = new State(10, 420);
            Solver nn = new NearestNeighbour(state);
            Console.ReadLine();
        }
    }
}
