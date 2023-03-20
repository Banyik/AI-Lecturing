using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Backtrack : Solver
    {
        Stack<Node> route = new Stack<Node>();
        Node currentNode;
        Node path;
        State state;
        public Backtrack(State state) : base(state)
        {
            this.state = state;
            Solve();
        }
        void Solve()
        {
            route.Push(new Node(state, null));
            while (route.Count > 0 && !route.Peek().State.IsTargetReached())
            {
                currentNode = route.Peek();
                if(Operators.Count > currentNode.Index)
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
            }

            if(route.Count > 0)
            {
                path = route.Peek();
                Console.WriteLine(path);
                Console.WriteLine($"Steps: {path.Depth}");
            }
            else
            {
                Console.WriteLine("Failed to find path!");
            }
        }
    }
}
