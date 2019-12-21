using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;

namespace SimpleCalculator.Classes
{
    internal class SubtractionSymbol : IMathSymbol, IOperatorSymbol
    {
        public Operations Priority => Operations.SubAndAdd;
        public double Solve(double firstDigit, double nextDigit)
        {
            return firstDigit - nextDigit;
        }
    }
}
