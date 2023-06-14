using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class Operator
    {
        public int X, Y;

        public Operator(char column)
        {
            switch (column)
            {
                case '1':
                    Y = 0;
                    break;
                case '2':
                    Y = 1;
                    break;
                case '3':
                    Y = 2;
                    break;
                case '4':
                    Y = 3;
                    break;
                case '5':
                    Y = 4;
                    break;
                case '6':
                    Y = 5;
                    break;
                default:
                    throw new Exception();

            }

        }

        public State ApplyState(State state)
        {
            
            State newState = state;
            switch(state.Last)
            {
                case State.LastTurn:
                    newState.Board[X, Y] = 'R';
                    newState.LastTurn = LastTurn.Yellow;
                    break;
                case LastTurn.Yellow:
                    newState.Board[X, Y] = 'Y';
                    newState.LastTurn = LastTurn.Red;
                    break;
            }
            return newState;
        }

    }
}
