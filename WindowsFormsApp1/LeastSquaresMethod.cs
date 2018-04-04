using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class LeastSquaresMethod
    {
        private List<double> Xs;
        private List<double> Ys;

        private double Start { get; set; }
        private double End { get; set; }
        private double Step { get; set; }
        private int N { get; set; }      
        private int Lenght { get; set; }
        private double SumXs { get; set; }
        private double SumYs { get; set; }
        public  double A { get; set; }
        public double B { get; set; }




        public LeastSquaresMethod(List<double> x, List<double> y, double start, double end, double step)
        {
            Xs = x;
            Ys = y;
            Start = start;
            End = end;
            Step = step;
            GetNumbers();
        }                    
        
        private void GetN()
        {
            int n = 0;
            for (double i = Start; i <= End; i += Step)
                n++;
            N = n;
        }

        private void GetLenght()
        {
            Lenght = Xs.Count();
        }

        private void GetSumXs()
        {
            SumXs = Xs.Sum();
        }

        private void GetSumYs()
        {
            SumYs = Ys.Sum();
        }

        private void GetB()
        {
            B = (SumYs - A * SumXs) / N;
        }

        private void GetA()
        {
            //A = (Lenght * SumXMultiY() - SumXs * SumYs) / (Lenght * SumPowXs() - SumXs * SumXs);
            A = (N * SumXMultiY() - SumXs * SumYs) / (N * SumPowXs() - SumXs * SumXs);
        }

        private void GetNumbers()
        {
            GetN();
            GetLenght();
            GetSumXs();
            GetSumYs();
            GetA();
            GetB();
        }

        private double SumXMultiY()
        {
            double result = 0;
            for (var i = 0; i < Xs.Count; i++)
                result += Xs[i] * Ys[i];
            return result;
        }

        private double SumPowXs ()
        {
            double result = 0;
            foreach(var x in Xs)
                result += x * x;
            return result;
        }

        public List<double> Result ()
        {
            var result = new List<double>();
            for (double x = Start; x <= End; x += Step)
            {
                var y = A * x + B;
                result.Add(y);
            }
                
            return result;
        }
    }
}
