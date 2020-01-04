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
                var result = Solve(expressionAsObjects, Operations.MulAndDiv);
                result = Solve(result, Operations.SubAndAdd);

                Expression = string.Format(temporaryExpression, (result[0] as IDigit).Value);
            }
            expressionAsObjects = CreateCollectionOfSymbols(Expression);
        }
        public override void ValidateData()
        {
        }

        private IList<IMathSymbol> SymbolsFollowingEachOtherProblemSolve(IList<IMathSymbol> expression)
        {
            int index = 0;
            bool loop = true;
            while (index < expression.Count - 1)
            {
                if ((expression[index] is DivisionSymbol || expression[index] is MultiplicationSymbol || expression[index] is AdditionSymbol)  && expression[index + 1] is SubtractionSymbol)
                {
                    expression.RemoveAt(index + 1);
                    expression[index + 1] = new DigitSymbol(-(expression[index + 1] as DigitSymbol).Value);
                }
                else if(expression[index] is SubtractionSymbol && expression[index + 1] is DigitSymbol && index == 0)
                {
                    expression.RemoveAt(index);
                    expression[index] = new DigitSymbol(-(expression[index] as DigitSymbol).Value);
                }
                index++;
            }
            return expression;

        }
    }
}
