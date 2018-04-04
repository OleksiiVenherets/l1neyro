﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class WidrofHoffMethod
    {
        private double Q { get; set; }
        public double W { get; set; }
        private double Start { get; set; }
        private double End { get; set; }
        private double Step { get; set; }

        public WidrofHoffMethod (double q, double w, double start, double end, double step)
        {
            Q = q;
            W = w;
            Start = start;
            End = end;
            Step = step;
        }

        public void Teach(int iterationCount)
        {
            var realfunction = new RealFunction();
            //for (var i = 0; i < iterationCount; i++)
            //{
                for (double x = Start; x <= (Start + End) / 2; x += Step)
                {
                //double x = Start;
                    var t = realfunction.RealFunctionResult(x);
                    FindNextW(t, x);
                    //x += Step;
                }
            //}
        }

        public List<double> Result()
        {
            var result = new List<double>();
            var realfunction = new RealFunction();
            for (double x = Start; x <= End; x += Step)
            {
                var t = realfunction.RealFunctionResult(x);
                result.Add(FunctionResult(t));
            }
            return result;
        }

        private double FunctionResult (double x)
        {
            return x * W;
        }

        private double FindDeltaW (double t, double x)
        {
            var dw = Q * x * (t - FunctionResult(x));
            return dw;
        }

        private void FindNextW (double t, double x)
        {
            var dw = FindDeltaW(t, x);
            W += dw;
        }
    }
}
