using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Beadando
{
    internal class Program
    {
        static void Main(string[] args)
        {

            State state = new State();
            TrialAndError ai = new TrialAndError();

            while (true)
            {
                Operator op;
                Console.Clear();
                Console.WriteLine(state);
                Console.WriteLine("Red turn:");
                state.LastTurn = LastTurn== 'R';
                do
                {
                    Console.Write("To: ");
                    char to = Convert.ToChar(Console.ReadLine());
                    op = new Operator(to);
                }
                while (!op.IsExistingState(state));
                op.ApplyState(state);
                Console.Clear();
                Console.WriteLine(state);
                if (state.IsTargetState('R'))
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(state);

                    Console.WriteLine("Red wins!");
                    break;
                }
                if (state.IsDraw())
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(state);
                    Console.WriteLine("DRAW!!");
                    break;
                }


                Console.WriteLine("Yellow turn:");
                Thread.Sleep(1000);
                state.LastTurn = LastTurn.Yellow;
                ai.GetMove(state);

                if (state.IsTargetState('Y'))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Clear();
                    Console.WriteLine(state);
                    Console.WriteLine("Yellow wins!");
                    break;
                }
                if (state.IsDraw())
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(state);
                    Console.WriteLine("DRAW!!");
                    break;
                }


            }



            Console.ReadLine();
        }
    }
}
