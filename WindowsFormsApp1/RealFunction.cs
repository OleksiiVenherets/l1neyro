using System.Collections.Generic;

namespace WindowsFormsApp1
{
    class RealFunction
    {
        public double RealFunctionResult (double x)
        {
            return 5 * x * x;
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
