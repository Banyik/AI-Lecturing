using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Operator
    {
        int x, y;

        
        char item;

        public char Item
        {
            get { return item; }
            set { item = value; }
        }
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public Operator(int x, int y, char item)
        {
            this.x = x;
            this.y = y;
            this.item = item;
        }
        public Operator(int num, char item)
        {
            switch (num)
            {
                case 7:
                    x = 0;
                    y = 0;
                    break;
                case 8:
                    x = 0;
                    y = 1;
                    break;
                case 9:
                    x = 0;
                    y = 2;
                    break;
                case 4:
                    x = 1;
                    y = 0;
                    break;
                case 5:
                    x = 1;
                    y = 1;
                    break;
                case 6:
                    x = 1;
                    y = 2;
                    break;
                case 1:
                    x = 2;
                    y = 0;
                    break;
                case 2:
                    x = 2;
                    y = 1;
                    break;
                case 3:
                    x = 2;
                    y = 2;
                    break;
            }
            this.item = item;
        }

        public bool IsExistingState(State state)
        {
            if (state.table[x, y] == ' ')
            {
                return true;
            }
            return false;
        }
        public State ApplyState(State state)
        {
            State newState = state;
            newState.table[x, y] = item;
            return newState;
        }
    }
}
