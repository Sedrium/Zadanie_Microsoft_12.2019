using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;

namespace SimpleCalculator.Classes
{
    internal class DivisionSymbol : IMathSymbol, IOperatorSymbol
    {
        public Operations Priority => Operations.MulAndDiv;
        public double Solve(double firstDigit, double nextDigit)
        {
            if (nextDigit == 0)
                throw new System.Exception("EX1002|Devide by 0 is impossible");
            return firstDigit / nextDigit;
        }
    }
}
