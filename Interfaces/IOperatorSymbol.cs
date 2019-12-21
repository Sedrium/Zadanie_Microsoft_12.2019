using SimpleCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Interfaces
{
    interface IOperatorSymbol
    {
        Operations Priority { get; }
        double Solve(double firstDigit, double nextDigit);
    }
}
