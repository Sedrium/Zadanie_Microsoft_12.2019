using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;

namespace SimpleCalculator.Classes
{
    internal class AdditionSymbol : IMathSymbol, IOperatorSymbol
    {
        public Operations Priority => Operations.SubAndAdd;
        public double Solve(double firstDigit, double nextDigit)
        {
            return firstDigit + nextDigit;
        }
    }
}
