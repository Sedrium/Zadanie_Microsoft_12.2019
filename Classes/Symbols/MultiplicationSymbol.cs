using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;

namespace SimpleCalculator.Classes
{
    public class MultiplicationSymbol : IMathSymbol, IOperatorSymbol
    {
        public Operations Priority => Operations.MulAndDiv;
        public double Solve(double firstDigit, double nextDigit)
        {
            return firstDigit * nextDigit;
        }
    }
}
