using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class BranchAndBound : Solver
    {
        Stack<Node> route = new Stack<Node>();
        Node currentNode;
        State state;
        public BranchAndBound(State state) : base(state)
        {
            this.state = state;
            Solve();
        }
        void Solve()
        {
            route.Push(new Node(state, null));

            while (route.Count > 0)
            {
                currentNode = route.Peek();
                if(currentNode.Index < Operators.Count && (Routes.Count == 0 || Routes.Count > route.Count))
                {
                    Operator currentOperator = Operators[currentNode.Index];
                    if (currentOperator.IsExistingState(currentNode.State))
                    {
                        State newState = currentOperator.ApplyState(currentNode.State);
                        Node newNode = new Node(newState, currentNode);
                        if (!route.Contains(newNode))
                        {
                            route.Push(newNode);
                        }
                    }
                    currentNode.Index++;
                }
                else
                {
                    route.Pop();
                }
                if(route.Count > 0 && route.Peek().State.IsTargetReached())
                {
                    if(Routes.Count == 0 || route.Count < Routes.Count)
                    {
                        Routes.Clear();
                        for (int i = 0; i < route.Count; i++)
                        {
                            Routes.Add(route.ElementAt(i).State);
                        }
                        Routes.Reverse();
                    }
                }
            }
            foreach(var state in Routes)
            {
                Console.WriteLine(state.ToString());
            }
            Console.WriteLine($"Steps: {Routes.Count-1}");
        }
    }
}
