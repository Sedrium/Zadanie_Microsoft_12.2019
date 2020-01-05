using SimpleCalculator.Interfaces;

namespace SimpleCalculator.Classes
{
    public class DigitSymbol : IMathSymbol, IDigit
    {
        public DigitSymbol(double value)
        {
            Value = value;
        }
        public double Value { get; set; }
    }
}
