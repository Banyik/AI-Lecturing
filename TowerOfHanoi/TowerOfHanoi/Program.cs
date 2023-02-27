using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            State state = new State(new List<Pole>(), 3);
            state.SetStartingState(3);
            Console.WriteLine(state.ToString());
            do
            {
                int from;
                int to;
                while (true)
                {
                    Console.Write("From: ");
                    if (int.TryParse(Console.ReadLine(), out from))
                        break;
                    Console.WriteLine("Bad arg.");
                }
                while (true)
                {
                    Console.Write("To: ");
                    if (int.TryParse(Console.ReadLine(), out to))
                        break;
                    Console.WriteLine("Bad arg.");
                }
                Operator o = new Operator(from, to);
                if (o.IsExistingState(state))
                {
                    state = o.ApplyState(state);
                    Console.WriteLine(state.ToString());
                }
                else
                {
                    Console.WriteLine("Invalid State!");
                }
            } while (!state.IsTargetReached());
            Console.WriteLine("Target reached!");
            Console.ReadLine();
        }
    }
}
