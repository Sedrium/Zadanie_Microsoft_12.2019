using SimpleCalculator.Classes.Abstracts;
using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator.Classes.CalculatorTypes
{
    class CalculatorInculdingBrackets : CalculatorFactory
    {
        public override void PrepareCollectionOfSymbols()
        {
            Regex RegexInnerBrackets = new Regex(@"\([0-9+*/-]+\)");
            while (RegexInnerBrackets.IsMatch(Expression))
            {
                var innerBracket = RegexInnerBrackets.Match(Expression);
                var temporaryExpression = RegexInnerBrackets.Replace(Expression, "{0}", 1);

                var trimedInnerBracket = innerBracket.Value.TrimStart('(').TrimEnd(')');
                var expressionAsObjects = CreateCollectionOfSymbols(trimedInnerBracket);
                expressionAsObjects = StickSubtractionWithDigit(expressionAsObjects);
                var result = Solve(expressionAsObjects, Operations.MulAndDiv);
                result = Solve(result, Operations.SubAndAdd);

                Expression = string.Format(temporaryExpression, (result[0] as IDigit).Value);
            }
            expressionAsObjects = CreateCollectionOfSymbols(Expression);
            expressionAsObjects = StickSubtractionWithDigit(expressionAsObjects);
        }
        public override void ValidateData()
        {
            DevideByZero();
            UndefindedChars();
        }

        private void DevideByZero()
        {
            Regex DevideByZeroRegex = new Regex(@"([/]{1}[0]+)");
            var isDevideByZero = DevideByZeroRegex.IsMatch(Expression);
            if (isDevideByZero)
                throw new DivideByZeroException("EX1002|Devide by 0 is impossible");
        }
        private void UndefindedChars()
        {
            Regex compatibleChars = new Regex(@"^[0-9()/+*-]+$");
            var charsAreCompatible = compatibleChars.IsMatch(Expression);
            if (!charsAreCompatible)
                throw new Exception("EX1003|Unexpected chars");
        }

        private IList<IMathSymbol> StickSubtractionWithDigit(IList<IMathSymbol> expression)
        {
            int itemIndex = 0;
            while (itemIndex < expression.Count - 1)
            {
                if (Condition.IsThereSubtractionSymbolAfterOtherSymbols(expression, itemIndex))
                    StickSubtractionToDigit(expression,itemIndex);
                else if(Condition.IsFirstDigitNegative(expression,itemIndex))
                    StickSubtractionToDigit(expression,itemIndex);
                itemIndex++;
            }
            return expression;
        }

        private static void StickSubtractionToDigit(IList<IMathSymbol> expression, int itemIndex)
        {
            var FirstDigitAfterSubtractionSymbol = expression.Where((item, index) => item is IDigit && (index == itemIndex + 1 || index == itemIndex + 2)).First();
            var indexOfSubtracionBeforeFirstDigit = expression.IndexOf(FirstDigitAfterSubtractionSymbol)-1;
            expression[indexOfSubtracionBeforeFirstDigit] = new DigitSymbol(-(FirstDigitAfterSubtractionSymbol as IDigit).Value);
            expression.Remove(FirstDigitAfterSubtractionSymbol);
        }
    }
}
