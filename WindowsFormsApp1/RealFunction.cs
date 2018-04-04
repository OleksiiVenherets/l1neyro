using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class RealFunction
    {
        public double RealFunctionResult (double x)
        {
            //return 2 *x*x*x + 0.5;
            return 3 * x * x;
        }

        public List<double> AllfunctionResult(double start, double end, double step)
        {
            var result = new List<double>();
            for (double x = start; x <= end; x += step)
                result.Add(RealFunctionResult(x));
            return result;
        }
    }
}
