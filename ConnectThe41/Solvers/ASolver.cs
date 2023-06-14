using System.Collections.Generic;

namespace Beadando
{
    internal abstract class Asolver
    {
        public List<Operator> Operators = new List<Operator> ();


        public Asolver()
        {
            GenerateOperators();
        }

        public abstract void GetMove(State state);
        private void GenerateOperators()
        {
            Operators.Add(new Operator('a'));
            Operators.Add(new Operator('b'));
            Operators.Add(new Operator('c'));
            Operators.Add(new Operator('d'));
            Operators.Add(new Operator('e'));
            Operators.Add(new Operator('f'));
        }
    }
}
