using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double start = Convert.ToDouble(textBox1.Text);
            double end = Convert.ToDouble(textBox2.Text);
            double step = Convert.ToDouble(textBox3.Text);
            double q = Convert.ToDouble(textBox4.Text);
            double w = Convert.ToDouble(textBox5.Text);
            
            var realFunction = new RealFunction();

            var XsList = Getxs(start, end, step);
            var realFunctionList = realFunction.AllfunctionResult(start, end, step);

            var leastSquareMethod = new LeastSquaresMethod(XsList, realFunctionList, start, end, step);

            var LSMList = leastSquareMethod.Result();
            var a = leastSquareMethod.A;
            var b = leastSquareMethod.B;

            var widrofHoffMethod = new WidrofHoffMethod(q, w, start, end, step);
            widrofHoffMethod.Teach();
            var W = widrofHoffMethod.W;
            var WHMList = widrofHoffMethod.Result();

            foreach (var y in realFunctionList)
                dataGridView1.Rows.Add(y);

            foreach (var y in LSMList)
                dataGridView2.Rows.Add(y);

            foreach (var y in WHMList)
                dataGridView3.Rows.Add(y);

            

            chart1.ChartAreas[0].AxisX.Minimum = start;
            chart1.ChartAreas[0].AxisX.Maximum = end;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = step;

            chart1.Series.Add("Original function");
            chart1.Series.Add("Less square method");
            chart1.Series.Add("Widroff Hoff Method");

            chart1.Series[0].ChartType = SeriesChartType.Spline;
            chart1.Series[1].ChartType = SeriesChartType.Spline;
            chart1.Series[2].ChartType = SeriesChartType.Spline;
            chart1.Series[0].BorderWidth = 4;
            chart1.Series[1].BorderWidth = 4;
            chart1.Series[2].BorderWidth = 4;

            chart1.Series[0].Points.DataBindXY(XsList, realFunctionList);
            chart1.Series[1].Points.DataBindXY(XsList, LSMList);
            chart1.Series[2].Points.DataBindXY(XsList, WHMList);                                  
        }

        private List<double> Getxs(double start, double end, double step)
        {
            var result = new List<double>();
            for (double x = start; x <= end; x += step)
                result.Add(x);
            return result;
        }
    }
}
