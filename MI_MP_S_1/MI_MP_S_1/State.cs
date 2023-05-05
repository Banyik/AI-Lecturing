using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_MP_S_1
{
    class State
    {
        char[,] table = { { 'B', 'B', 'B', 'B', 'B' },
                          { ' ', ' ', ' ', ' ', ' ' },
                          { ' ', 'X', ' ', 'X', ' ' },
                          { ' ', ' ', ' ', ' ', ' ' },
                          { 'R', 'R', 'R', 'R', 'R' }};
        LastTurn lastTurn;

        public char[,] Table { get => table; set => table = value; }
        internal LastTurn LastTurn { get => lastTurn; set => lastTurn = value; }

        public bool IsTargetState()
        {
            char enemy = GetEnemyColor();
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if(table[i,j] == enemy)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public char GetEnemyColor()
        {
            if(lastTurn == LastTurn.Red)
            {
                return 'B';
            }
            else
            {
                return 'R';
            }
        }
        public char GetLastColor()
        {
            if (lastTurn == LastTurn.Red)
            {
                return 'R';
            }
            else
            {
                return 'B';
            }
        }

        public override string ToString()
        {
            string value = "-----------------------\n";
            for (int i = 0; i < table.GetLength(0); i++)
            {
                value += i+1;
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    value += $" | {table[i, j]}";
                }
                value += " |\n-----------------------\n";
            }
            value += "  | a | b | c | d | e |";
            return value;
        }
    }
}
