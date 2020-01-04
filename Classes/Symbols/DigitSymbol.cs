using SimpleCalculator.Interfaces;

namespace SimpleCalculator.Classes
{
    internal class DigitSymbol : IMathSymbol, IDigit
    {
        public DigitSymbol(double value)
        {
            Value = value;
        }
        public double Value { get; set; }
    }
}
