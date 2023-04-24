using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class TrialAndError : Solver
    {
        public TrialAndError(State state)
        {
            GenerateOperators(state);
        }

        public void GetMove(State state)
        {
            Random rnd = new Random();

            while (true)
            {
                int operatorIndex = rnd.Next(0, Operators.Count);
                Operator currentOperator = Operators[operatorIndex];
                if (currentOperator.IsExistingState(state))
                {
                    currentOperator.ApplyState(state);
                    break;
                }
            }
        }
    }
}
