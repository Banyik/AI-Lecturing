using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Solver
    {
        List<Operator> operators = new List<Operator>();
        public Solver(State state)
        {
            GenerateOperators(state);
        }

        internal List<Operator> Operators { get => operators; set => operators = value; }

        void GenerateOperators(State state)
        {
            for (int i = 0; i < state.Poles.Count; i++)
            {
                for (int j = 0; j < state.Poles.Count; j++)
                {
                    if (i != j)
                    {
                        Operators.Add(new Operator(i, j));
                    }
                }
            }
        }
    }
}
