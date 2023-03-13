using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Node
    {
        State state;
        Node parent;
        int index;
        int depth;

        public int Index { get => index; set => index = value; }
        public int Depth { get => depth; set => depth = value; }
        internal State State { get => state; set => state = value; }
        internal Node Parent { get => parent; set => parent = value; }
        public Node(State state, Node parent)
        {
            this.state = state;
            this.parent = parent;
            Index = 0;
            if(parent == null)
            {
                Depth = 0;
            }
            else
            {
                Depth = parent.depth + 1;
            }
        }
        public bool IsTargetNode()
        {
            return state.IsTargetReached();
        }

        public override bool Equals(object obj)
        {
            if(obj == null ||!(obj is Node))
            {
                return false;
            }
            Node other = obj as Node;
            return state.Equals(other.state);
        }

        public override string ToString()
        {
            string value = "";
            if(parent != null)
            {
                value += parent.ToString() + "\n";
            }
            value += state.ToString();
            return value;
        }
    }
}
