using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_MP_2_10_A
{
    class State
    {
        public char[,] board = { {'R', 'R', 'R', 'R', 'B'},
                                 {'R', 'R', 'R', 'R', 'R'},
                                 {'R', 'R', 'B', 'R', 'R'},
                                 {'R', 'R', 'R', 'R', 'R'},
                                 {'B', 'R', 'R', 'R', 'R'}};

        public bool IsPlayerRedTargetState()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(board[i,j] == 'B')
                    {
                        count++;
                    }
                }
                if(count == 3)
                {
                    return true;
                }
                count = 0;
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(board[j,i] == 'B')
                    {
                        count++;
                    }
                }
                if(count == 3)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPlayerBlueTargetState()
        {
            List<int> x = new List<int>();
            List<int> y = new List<int>();

            List<Operator> operators = new List<Operator>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if(board[i,j] == 'B')
                    {
                        x.Add(i);
                        y.Add(j);
                    }
                }
            }
            for (int i = 0; i < x.Count; i++)
            {
                operators.Add(new Operator(x[i], y[i], x[i] + 1, y[i]));
                operators.Add(new Operator(x[i], y[i], x[i], y[i] + 1));
                operators.Add(new Operator(x[i], y[i], x[i] - 1, y[i]));
                operators.Add(new Operator(x[i], y[i], x[i], y[i] - 1));
            }
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i].IsPlayerBlueExistingState(this))
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            string value = "-----------------------\n";
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    value += $" | {board[i, j]}";
                }
                value += " |\n-----------------------\n";
            }
            return value;
        }
    }
}
