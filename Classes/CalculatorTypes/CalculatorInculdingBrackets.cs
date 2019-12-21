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
            //No time enough to implement this. similary to unit test.
        }
    }
}
