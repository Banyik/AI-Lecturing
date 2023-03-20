using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class BreadthFirst : Solver
    {
        public Queue<Node> openNodes = new Queue<Node>();
        public List<Node> closedNodes = new List<Node>();
        State state;
        Node path;
        Node currentNode;
        public BreadthFirst(State state) : base(state)
        {
            this.state = state;
            Solver();
        }
        void Solver()
        {
            openNodes.Clear();
            closedNodes.Clear();
            path = null;
            openNodes.Enqueue(new Node(state, null));
            while (openNodes.Count > 0)
            {
                currentNode = openNodes.Dequeue();
                closedNodes.Add(currentNode);
                Operator currentOperator = GetOperator();
                while (currentOperator != null)
                {
                    State newState = currentOperator.ApplyState(currentNode.State);
                    Node newNode = new Node(newState, currentNode);
                    if (newNode.IsTargetNode())
                    {
                        path = newNode;
                        break;
                    }
                    if(!openNodes.Contains(newNode) && !closedNodes.Contains(newNode))
                    {
                        openNodes.Enqueue(newNode);
                    }
                    currentOperator = GetOperator();
                }
            }
            if(path != null)
            {
                Console.WriteLine(path);
                Console.WriteLine($"Steps: {path.Depth}");
            }
            else
            {
                Console.WriteLine("Failed to find path!");
            }
        }

        Operator GetOperator()
        {
            int index = currentNode.Index++;
            while (index < Operators.Count)
            {
                if (Operators[index].IsExistingState(currentNode.State))
                {
                    return Operators[index];
                }
                index = currentNode.Index++;
            }
            return null;
        }
    }
}
