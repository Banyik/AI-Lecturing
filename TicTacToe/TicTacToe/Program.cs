using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            State gameState = new State();
            Console.WriteLine(gameState);
            while (true)
            {
                Console.WriteLine("X turn:\n");
                Operator op;
                do
                {
                    op = new Operator(int.Parse(Console.ReadLine()), 'X');
                } while (!op.IsExistingState(gameState));
                op.ApplyState(gameState);
                Console.WriteLine(gameState);
                if (gameState.IsTargetState('X'))
                {
                    Console.WriteLine("X won!");
                    break;
                }
                else if (gameState.IsDraw())
                {
                    Console.WriteLine("Draw!");
                    break;
                }
                Console.WriteLine("O turn:\n");
                do
                {
                    op = new Operator(int.Parse(Console.ReadLine()), 'O');
                } while (!op.IsExistingState(gameState));
                op.ApplyState(gameState);
                Console.WriteLine(gameState);
                if (gameState.IsTargetState('O'))
                {
                    Console.WriteLine("O won!");
                    break;
                }
                else if (gameState.IsDraw())
                {
                    Console.WriteLine("Draw!");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
