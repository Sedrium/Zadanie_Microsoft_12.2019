using SimpleCalculator.Classes.Abstracts;
using SimpleCalculator.Classes.Extensions;
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
    public class SimpleCalculator : CalculatorFactory
    {
        public override void ValidateData()
        {
            DevideByZero();
            WrongStyleOfExpression();
            UndefindedChars();
        }

        public override void PrepareCollectionOfSymbols()
        {
            expressionAsObjects = CreateCollectionOfSymbols(Expression);
        }


        private void DevideByZero()
        {
            Regex DevideByZeroRegex = new Regex(@"([/]{1}[0]+)");
            var isDevideByZero = DevideByZeroRegex.IsMatch(Expression);
            if (isDevideByZero)
                throw new DivideByZeroException("dont devide by 0");
        }
        private void WrongStyleOfExpression()
        {
            Regex correctLookingExpression = new Regex(@"^[0-9]+([+/*-]{1}[0-9]+)+$");
            var isLookCorrect = correctLookingExpression.IsMatch(Expression);
            if (!isLookCorrect)
                throw new Exception("Wrong input expression");
        }
        private void UndefindedChars()
        {
            Regex compatibleChars = new Regex(@"^[0-9/+*-]+$");
            var charsAreCompatible = compatibleChars.IsMatch(Expression);
            if (!charsAreCompatible)
                throw new Exception("Wrong input expression");
        }
    }
}