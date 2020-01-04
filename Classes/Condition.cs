using SimpleCalculator.Enums;
using SimpleCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Classes
{
    public static class Condition
    {
        public static IMathSymbol TakeFirstSymbolEqualToSolveSymbol(IList<IMathSymbol> blackboard, Operations solveSymbols)
        {
            return blackboard.FirstOrDefault(p => p is IOperatorSymbol && solveSymbols == (p as IOperatorSymbol).Priority);
        }
        public static bool ListContainsAnySymbolEqualToSolveSymbol(IList<IMathSymbol> ListOfSymbols, Operations stage)
        {
            return ListOfSymbols.FirstOrDefault(p => p is IOperatorSymbol && stage == (p as IOperatorSymbol).Priority) != null;
        }
        public static bool StringIsNotNull(string input)
        {
            bool isStringNull = false;
            if (string.IsNullOrEmpty(input))
                isStringNull = true;
            return !isStringNull;
        }
    }
}
