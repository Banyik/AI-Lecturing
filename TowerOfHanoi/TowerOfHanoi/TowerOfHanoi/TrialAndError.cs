using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class TrialAndError : Solver
    {
        public TrialAndError(State state) : base(state)
        {
            Solve(state);
        }

        void Solve(State state)
        {
            Random random = new Random();
            Console.WriteLine(state.ToString());
            for (int i = 0; i < 1000; i++)
            {
                int operatorIndex = random.Next(0, Operators.Count);
                Operator currentOperator = Operators[operatorIndex];
                if (currentOperator.IsExistingState(state))
                {
                    state = currentOperator.ApplyState(state);
                    Console.WriteLine(state.ToString());
                    if (state.IsTargetReached())
                    {
                        Console.WriteLine("Target reached!");
                        break;
                    }
                }
            }
            if (!state.IsTargetReached())
            {
                Console.WriteLine("Solver failed");
            }
        }
    }
}
