using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MI_MP_2_10_A
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
                Console.WriteLine("Blue turn:\n");
                do
                {
                    int fromX = int.Parse(Console.ReadLine());
                    int fromY = int.Parse(Console.ReadLine());
                    int toX = int.Parse(Console.ReadLine());
                    int toY = int.Parse(Console.ReadLine());

                    op = new Operator(fromX, fromY, toX, toY);
                } while (!op.IsPlayerBlueExistingState(gameState));
                op.PlayerBlueApplyState(gameState);
                Console.WriteLine(gameState);
                if (gameState.IsPlayerRedTargetState())
                {
                    Console.WriteLine("Red wins");
                    break;
                }
                Console.WriteLine("Red turn:\n");
                do
                {
                    int fromX = int.Parse(Console.ReadLine());
                    int fromY = int.Parse(Console.ReadLine());
                    int toX = int.Parse(Console.ReadLine());
                    int toY = int.Parse(Console.ReadLine());

                    op = new Operator(fromX, fromY, toX, toY);
                } while (!op.IsPlayerRedExistingState(gameState));
                op.PlayerRedApplyState(gameState);
                Console.WriteLine(gameState);
                if (gameState.IsPlayerBlueTargetState())
                {
                    Console.WriteLine("Blue wins");
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
