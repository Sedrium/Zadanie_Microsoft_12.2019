using SimpleCalculator.Classes.Extensions;
using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator.Classes.Abstracts
{
    public abstract class CalculatorFactory
    {
        public double Result { get; protected set; }
        public string Expression { get; set; }
        protected IList<IMathSymbol> expressionAsObjects;


        public abstract void ValidateData();
        public abstract void PrepareCollectionOfSymbols();
        public void SolveWholeExpression()
        {
            var ListWihtOutMulAndDiv = Solve(expressionAsObjects, Operations.MulAndDiv);
            var SolveRestOfExpression = Solve(ListWihtOutMulAndDiv, Operations.SubAndAdd);
            Result = (SolveRestOfExpression.First() as IDigit).Value;
        }

        #region Useful Methods
        protected virtual IList<IMathSymbol> CreateCollectionOfSymbols(string expression)
        {
            var splittedExpression = SplitExpression(expression);
            return CreateListOfSymbols(splittedExpression);
        }
        protected IList<IMathSymbol> Solve(IList<IMathSymbol> mathSymbols, Operations solveSymbols = Operations.MulAndDiv)
        {
            IList<IMathSymbol> DigitAndOperators = mathSymbols;
            while (Condition.ListContainsAnySymbolEqualToSolveSymbol(DigitAndOperators, solveSymbols))
            {
                var mathsOperator = Condition.TakeFirstSymbolEqualToSolveSymbol(DigitAndOperators, solveSymbols);
                var opIndex = DigitAndOperators.IndexOf(mathsOperator);
                var previousDigit = DigitAndOperators[opIndex - 1] as IDigit;
                var nextDigit = DigitAndOperators[opIndex + 1] as IDigit;

                nextDigit.Value = (mathsOperator as IOperatorSymbol).Solve(previousDigit.Value, nextDigit.Value);
                DigitAndOperators.Remove(previousDigit as IMathSymbol);
                DigitAndOperators.Remove(mathsOperator);
            }
            return DigitAndOperators;
        }

        private IEnumerable<string> SplitExpression(string expression)
        {
            var splitExpression = Regex.Split(expression, SplitPatterns.ByDigits.GetDescription());
            var WithoutWhiteSpaces = splitExpression.Where(Condition.StringIsNotNull);
            return WithoutWhiteSpaces;
        }
        private IList<IMathSymbol> CreateListOfSymbols(IEnumerable<string> splittedExpression)
        {
            IList<IMathSymbol> expressionAsObjects = new List<IMathSymbol>();
            foreach (var stringSymbol in splittedExpression)
                expressionAsObjects.Add(CreateSpecificSymbol(stringSymbol));
            return expressionAsObjects;
        }
        protected virtual IMathSymbol CreateSpecificSymbol(string symbol)
        {
            IMathSymbol mathSymbol;
            switch (symbol)
            {
                case "+":
                    mathSymbol = new AdditionSymbol();
                    break;
                case "-":
                    mathSymbol = new SubtractionSymbol();
                    break;
                case "*":
                    mathSymbol = new MultiplicationSymbol();
                    break;
                case "/":
                    mathSymbol = new DivisionSymbol();
                    break;
                default:
                    mathSymbol = new DigitSymbol(int.Parse(symbol));
                    break;
            }
            return mathSymbol;
        }
        #endregion
    }
}
