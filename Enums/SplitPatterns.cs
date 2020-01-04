using System.ComponentModel;

namespace SimpleCalculator.Enums
{
    public enum SplitPatterns
    {
        [Description(@"([0-9]+)")]
        ByDigits,
        [Description(@"\([0-9+*/-]+\)")]
        ByBracket,
    }
}
