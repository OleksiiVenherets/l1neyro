using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            int iteration = Convert.ToInt32(textBox6.Text);

            var realFunction = new RealFunction();

            var XsList = Getxs(start, end, step);
            var realFunctionList = realFunction.AllfunctionResult(start, end, step);

            var leastSquareMethod = new LeastSquaresMethod(XsList, realFunctionList, start, end, step);

            var LSMList = leastSquareMethod.Result();
            var a = leastSquareMethod.A;
            var b = leastSquareMethod.B;

            var widrofHoffMethod = new WidrofHoffMethod(q, w, start, end, step);
            widrofHoffMethod.Teach(iteration);
            var W = widrofHoffMethod.W;
            var WHMList = widrofHoffMethod.Result();

            foreach (var y in realFunctionList)
                dataGridView1.Rows.Add(y);

            foreach (var y in LSMList)
                dataGridView2.Rows.Add(y);

            foreach (var y in WHMList)
                dataGridView3.Rows.Add(y);

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
