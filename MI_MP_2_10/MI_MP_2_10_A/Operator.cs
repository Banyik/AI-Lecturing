using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_MP_2_10_A
{
    class Operator
    {
        int fromX, fromY, toX, toY;

        public Operator(int fromX, int fromY, int toX, int toY)
        {
            this.fromX = fromX;
            this.fromY = fromY;
            this.toX = toX;
            this.toY = toY;
        }

        public int FromX { get => fromX; set => fromX = value; }
        public int FromY { get => fromY; set => fromY = value; }
        public int ToX { get => toX; set => toX = value; }
        public int ToY { get => toY; set => toY = value; }

        public bool IsPlayerRedExistingState(State state)
        {
            if(toX > -1 && toY > -1 && toX < state.board.GetLength(0) && toY < state.board.GetLength(1) &&
               fromX > -1 && fromY > -1 && fromX < state.board.GetLength(0) && fromY < state.board.GetLength(1) &&
               (fromX - toX == 0 || fromY - toY == 0) && Math.Abs(fromX - toX) <= 1 && Math.Abs(fromY - toY) <= 1 &&
               state.board[fromX, fromY] == 'R' &&
               state.board[toX, toY] == ' ')
            {
                return true;
            }
            return false;
        }

        public State PlayerRedApplyState(State state)
        {
            State newState = state;
            newState.board[fromX, fromY] = ' ';
            newState.board[toX, toY] = 'R';
            return newState;
        }

        public bool IsPlayerBlueExistingState(State state)
        {
            if (toX > -1 && toY > -1 && toX < state.board.GetLength(0) && toY < state.board.GetLength(1) &&
               fromX > -1 && fromY > -1 && fromX < state.board.GetLength(0) && fromY < state.board.GetLength(1) &&
               (fromX - toX == 0 || fromY - toY == 0) && Math.Abs(fromX - toX) <= 1 && Math.Abs(fromY - toY) <= 1 &&
               state.board[fromX, fromY] == 'B' &&
               state.board[toX, toY] == 'R')
            {
                return true;
            }
            return false;
        }

        public State PlayerBlueApplyState(State state)
        {
            State newState = state;
            newState.board[fromX, fromY] = ' ';
            newState.board[toX, toY] = 'B';
            return newState;
        }
    }
}
