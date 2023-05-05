using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_MP_S_1
{
    class Program
    {
        static void Main(string[] args)
        {
            State gameState = new State();
            Console.WriteLine(gameState);
            while (true)
            {
                Operator op;
                Console.WriteLine("Red turn:");
                gameState.LastTurn = LastTurn.Red;
                do
                {
                    Console.Write("From: ");
                    string from = Console.ReadLine();
                    Console.Write("To: ");
                    string to = Console.ReadLine();
                    op = new Operator(from, to);
                } while (!op.IsExistingState(gameState));
                op.ApplyState(gameState);
                Console.WriteLine(gameState);
                if (gameState.IsTargetState())
                {
                    Console.WriteLine("Red wins!");
                    break;
                }
                Console.WriteLine("Blue turn:");
                gameState.LastTurn = LastTurn.Blue;
                do
                {
                    Console.Write("From: ");
                    string from = Console.ReadLine();
                    Console.Write("To: ");
                    string to = Console.ReadLine();
                    op = new Operator(from, to);
                } while (!op.IsExistingState(gameState));
                op.ApplyState(gameState);
                Console.WriteLine(gameState);
                if (gameState.IsTargetState())
                {
                    Console.WriteLine("Blue wins!");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
