using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Beadando
{
    internal class TrialAndError : Asolver
    {
        private int operatorIndex;
        public override void GetMove(State state)
        {
            Random rnd = new Random();
            while(true)
            {
                operatorIndex = rnd.Next(Operators.Count);
                Operator CurrentOperator = Operators[operatorIndex];

                if(CurrentOperator.IsExistingState(state))
                {
                    CurrentOperator.ApplyState(state);
                    break;
                }
                

            }
        }
    }
}
