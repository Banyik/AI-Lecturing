using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_MP_S_1
{
    class Operator
    {
        string[,] tableCoord = { { "a1", "b1", "c1", "d1", "e1" },
                                 { "a2", "b2", "c2", "d2", "e2" },
                                 { "a3", "b3", "c3", "d3", "e3" },
                                 { "a4", "b4", "c4", "d4", "e4" },
                                 { "a5", "b5", "c5", "d5", "e5" }};
        int fromX, fromY, toX, toY;
        public Operator(string from, string to)
        {
            for (int i = 0; i < tableCoord.GetLength(0); i++)
            {
                for (int j = 0; j < tableCoord.GetLength(1); j++)
                {
                    if(tableCoord[i,j] == from)
                    {
                        fromX = i;
                        fromY = j;
                    }
                    if (tableCoord[i, j] == to)
                    {
                        toX = i;
                        toY = j;
                    }
                }
            }
        }

        public bool IsExistingState(State state)
        {
            char enemy = state.GetEnemyColor();
            char last = state.GetLastColor();

            if(IsInsideTheTable() && Math.Abs(fromX - toX) <= 2 && Math.Abs(fromY - toY) <= 2 &&
                state.Table[fromX, fromY] == last && state.Table[toX, toY] != 'X')
            {
                if(IsDiagnoal() && state.Table[toX, toY] == enemy)
                {
                    return true;
                }
                else if(!IsDiagnoal() && !IsEnemyOrBlackInBetween(state) && state.Table[toX, toY] == ' ')
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsEnemyOrBlackInBetween(State state)
        {
            if(Math.Abs(fromX - toX) == 1 || Math.Abs(fromY - toY) == 1)
            {
                return false;
            }
            else if(state.Table[(fromX + toX)/2, (fromY + toY)/2] == ' ')
            {
                return false;
            }
            return true;
        }

        private bool IsDiagnoal()
        {
            if(Math.Abs(fromX - toX) == 1 && Math.Abs(fromY - toY) == 1)
            {
                return true;
            }
            return false;
        }

        private bool IsInsideTheTable()
        {
            if(toX > -1 && toY > -1 && toX < tableCoord.GetLength(0) && toY < tableCoord.GetLength(1) &&
               fromX > -1 && fromY > -1 && fromX < tableCoord.GetLength(0) && fromY < tableCoord.GetLength(1))
            {
                return true;
            }
            return false;
        }

        public State ApplyState(State state)
        {
            State newState = state;
            newState.Table[fromX, fromY] = ' ';
            switch (state.LastTurn)
            {
                case LastTurn.Red:
                    newState.Table[toX, toY] = 'R';
                    break;
                case LastTurn.Blue:
                    newState.Table[toX, toY] = 'B';
                    break;
            }
            return newState;
        }
    }
}
