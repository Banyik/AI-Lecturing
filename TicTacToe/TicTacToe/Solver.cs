using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Solver
    {
        List<Operator> operators = new List<Operator>();

        internal List<Operator> Operators { get => operators; set => operators = value; }

        public void GenerateOperators(State state)
        {
            for (int i = 0; i < state.table.GetLength(0); i++)
            {
                for (int j = 0; j < state.table.GetLength(1); j++)
                {
                    operators.Add(new Operator(i, j, 'O'));
                }
            }
        }
    }
}
