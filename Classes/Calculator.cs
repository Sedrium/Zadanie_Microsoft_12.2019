using SimpleCalculator.Classes.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Classes
{
    public class Calculator 
    {
        private CalculatorFactory calculator;
     
        public Calculator(CalculatorFactory calculator)
        {
            this.calculator = calculator;
        }

        public double SolveExpression(string expression)
        {
            calculator.Expression = expression;
            calculator.ValidateData();
            calculator.PrepareCollectionOfSymbols();
            calculator.SolveWholeExpression();
            return calculator.Result;
        }

    }
}
