using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;

namespace SimpleCalculator.Classes
{
    internal class DivisionSymbol : IMathSymbol, IOperatorSymbol
    {
        public Operations Priority => Operations.MulAndDiv;
        public double Solve(double firstDigit, double nextDigit)
        {
            return firstDigit / nextDigit;
        }
    }
}
