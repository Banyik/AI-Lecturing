using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    class Solver
    {
        List<Operator> operators = new List<Operator>();

        internal List<Operator> Operators { get => operators; set => operators = value; }

        public void GenerateOperators(State state, City lastCity)
        {
            operators.Clear();
            for (int i = 0; i < state.Cities.Count; i++)
            {
                if(lastCity != state.Cities[i])
                {
                    operators.Add(new Operator(lastCity, state.Cities[i]));
                }
            }
        }
    }
}
