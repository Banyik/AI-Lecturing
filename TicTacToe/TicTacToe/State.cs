using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class State
    {
        public char[,] table = {{' ', ' ', ' '},
                                {' ', ' ', ' '},
                                {' ', ' ', ' '}};

        public bool IsTargetState(char item)
        {
            int count = 0;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] == item)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                }
                if (count == 3)
                {
                    return true;
                }
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[j, i] == item)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                        break;
                    }
                }
                if (count == 3)
                {
                    return true;
                }
            }

            for (int i = 0; i < table.GetLength(1); i++)
            {
                if (table[i, i] == item)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    break;
                }
            }
            if (count == 3)
            {
                return true;
            }
            for (int i = table.GetLength(1)-1; i >= 0 ; i--)
            {
                if (table[i, 2-i] == item)
                {
                    count++;
                }
                else
                {
                    count = 0;
                    break;
                }
            }
            if (count == 3)
            {
                return true;
            }

            return false;
        }

        public bool IsDraw()
        {
            if (!IsTargetState('X') &&!IsTargetState('O'))
            {
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    for (int j = 0; j < table.GetLength(1); j++)
                    {
                        if (table[i, j] == ' ')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            string value = "-------\n";
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    value += "|" + table[i, j];
                }
                value += "|\n-------\n";
            }
            return value;
        }

    }
}
