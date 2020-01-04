using SimpleCalculator.Classes;
using SimpleCalculator.Classes.Abstracts;
using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string expressionWithBrackets = "22/((6+(-1*4-2))+(21-2))"; // 22/((6+(-1*4-2))+(21-2))  = 1,15789
            string expression = "22/6+1*4-2+21-2";                  // = 24.6(6) 
            
            Calculator simple = new Calculator(new Classes.CalculatorTypes.SimpleCalculator());
            var result = simple.SolveExpression(expression);
            Calculator bracket = new Calculator(new Classes.CalculatorTypes.CalculatorInculdingBrackets()); // this type can solve both expression. maybe SimpleCalculator is not necessary
            var result2 = bracket.SolveExpression(expressionWithBrackets);

        }
        public static double Evaluate(string expression) //  shorter for simple expression
        {
            return (double)new System.Xml.XPath.XPathDocument
            (new StringReader("<r/>")).CreateNavigator().Evaluate
            (string.Format("number({0})", new
            System.Text.RegularExpressions.Regex(@"([\+\-\*])")
            .Replace(expression, " ${1} ")
            .Replace("/", " div ")
            .Replace("%", " mod ")));
        }
    }
}