using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calc
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        List<double> xPoint = new List<double>();
        List<double> yPoint = new List<double>();

        private void findPoints(string function)
        {
            string axis = function[1].ToString();

            MainMenu form1 = new MainMenu();
            try
            {
                var newChart = new Series(function);
                chart1.Series.Add(newChart);
                newChart.ChartType = SeriesChartType.Line;
                chart1.Series[function].BorderWidth = 2;
            }
            catch { }


            string varDouble, varFix, var, testVal, equation, nestEq, nestAns, newEq;
            Regex digits = new Regex("[1-9πxy]");
            Regex fact = new Regex("[!]");
            double answer;
            bool error;
            int index1, index2;
            for (double i = -10; i <= 10; i = i + 0.25)
            {
                varDouble = "xx";
                varFix = "x*x";
                var = "x";
                if (axis == "x")
                {
                    var = "y";
                    varDouble = "yy";
                    varFix = "y*y";
                }
                testVal = "(" + i.ToString() + ")";
                equation = function.Substring(4, function.Length - 4);
                equation = equation.Replace(varDouble, varFix).Replace(var, testVal);
                answer = 0;
                Node math = new Node();
                error = false;
                if (equation.Contains("("))
                {
                    index1 = 0;
                    index2 = 0;
                    while (equation.Contains("("))
                    {
                        //find innermost brackets
                        index1 = equation.LastIndexOf("(");
                        nestEq = equation.Remove(0, index1 + 1);
                        index2 = nestEq.IndexOf(")");
                        nestEq = nestEq.Remove(index2);
                        math.read(nestEq);
                        answer = math.getAnswer();
                        if (math.getError() == false)
                        {
                            
                            nestEq = "(" + nestEq + ")";
                            nestAns = answer.ToString();
                            newEq = "";
                            try
                            {
                                if (digits.IsMatch(equation[index1 - 1].ToString()))
                                {
                                    nestAns = "*" + nestAns;
                                }
                            }
                            catch
                            { }
                            try
                            {
                                if (digits.IsMatch(equation[index1 + index2 + 2].ToString()))
                                {
                                    nestAns = nestAns + "*";
                                }
                                if ((fact.IsMatch(equation[index1 + index2 + 2].ToString())) && (answer < 0))
                                {
                                    error = true;
                                }
                            }
                            catch
                            { }
                            newEq = equation.Replace(nestEq, nestAns);
                            equation = newEq;
                        }

                    }
                }
                math.read(equation);
                answer = math.getAnswer();
                if (math.getError() == false)
                {
                    if (!double.IsInfinity(answer))
                    {
                        try
                        {
                            //check if nested eq is negative and right op is !
                            if (error == false)
                            {
                                if (axis == "x")
                                {
                                    xPoint.Add(answer);
                                    yPoint.Add(i);
                                    chart1.Series[function].Points.AddXY(answer, i);
                                }
                                else
                                {
                                    xPoint.Add(i);
                                    yPoint.Add(answer);
                                    chart1.Series[function].Points.AddXY(i, answer);
                                }
                            }
                        }
                        catch { }
                    }
                    else
                    {
                        try
                        {
                            if (axis == "x")
                            {
                                if (yPoint[yPoint.Count() - 1] < (yPoint[yPoint.Count() - 2]))
                                {
                                    chart1.Series[function].Points.AddXY(-100, i);
                                    chart1.Series[function].Points.AddXY(100, i);
                                }
                                else
                                {
                                    chart1.Series[function].Points.AddXY(100, i);
                                    chart1.Series[function].Points.AddXY(-100, i);
                                }
                            }
                            else
                            {
                                if (yPoint[yPoint.Count() - 1] < (yPoint[yPoint.Count() - 2]))
                                {
                                    chart1.Series[function].Points.AddXY(i, -100);
                                    chart1.Series[function].Points.AddXY(i, 100);
                                }
                                else
                                {
                                    chart1.Series[function].Points.AddXY(i, 100);
                                    chart1.Series[function].Points.AddXY(i, -100);
                                }
                            }
                        }
                        catch
                        {
                            if (axis == "x")
                            {
                                chart1.Series[function].Points.AddXY(-100, i);
                                chart1.Series[function].Points.AddXY(100, i);
                            }
                            else
                            {
                                chart1.Series[function].Points.AddXY(i, 100);
                                chart1.Series[function].Points.AddXY(i, -100);
                            }
                        }
                    }
                }
                
            }
        }

        private void graphBtn_Click(object sender, EventArgs e)
        {
            double xInterval = 1;
            double xDiff = 1;
            double yInterval = 1;
            double yDiff = 1;
            try
            {
                findPoints(eq1Combo.Text);
                if ((xPoint.Min() < 0) && (xPoint.Max() > 0))
                {
                    xDiff = xPoint.Max() - xPoint.Min();
                }
                else
                {
                    xDiff = xPoint.Max() + xPoint.Min();
                    if (xDiff < 0)
                    {
                        xDiff = xDiff * (-1);
                    }
                }
                if ((yPoint.Min() < 0) && (yPoint.Max() > 0))
                {
                    yDiff = yPoint.Max() - yPoint.Min();
                }
                else
                {
                    yDiff = yPoint.Max() + yPoint.Min();
                    if (yDiff < 0)
                    {
                        yDiff = yDiff * (-1);
                    }
                }
            }
            catch { }
            
            var chart = chart1.ChartAreas[0];
            xInterval = Math.Round(xDiff / 20);
            yInterval = Math.Round(yDiff / 20);
            if (xInterval == 0)
                xInterval = 1;
            else if (xInterval > 10)
                xInterval = 10;
            if (yInterval == 0)
                yInterval = 1;
            else if (yInterval > 10)
                yInterval = 10;
            if ((yDiff > 20) && (yDiff <= 200))
            {
                chart1.ChartAreas[0].AxisY.Maximum = yPoint.Max();
                chart1.ChartAreas[0].AxisY.Minimum = yPoint.Min();
            }
            else if (yDiff <= 20)
            {
                chart1.ChartAreas[0].AxisY.Maximum = 10;
                chart1.ChartAreas[0].AxisY.Minimum = -10;
            }
            else
            {
                chart1.ChartAreas[0].AxisY.Maximum = 100;
                chart1.ChartAreas[0].AxisY.Minimum = -100;
            }
            if ((xDiff > 20) && (xDiff <= 200))
            {
                chart1.ChartAreas[0].AxisX.Maximum = Math.Round(xPoint.Max());
                chart1.ChartAreas[0].AxisX.Minimum = Math.Round(xPoint.Min());
            }
            else if (xDiff <= 20)
            {
                chart1.ChartAreas[0].AxisX.Maximum = 10;
                chart1.ChartAreas[0].AxisX.Minimum = -10;
            }
            else
            {
                chart1.ChartAreas[0].AxisX.Maximum = 100;
                chart1.ChartAreas[0].AxisX.Minimum = -100;
            }
            chart.AxisY.Interval = yInterval;
            chart.AxisX.Interval = xInterval;

            chart.AxisX.Crossing = 0;
            chart.AxisX.LineWidth = 3;
            chart.AxisY.Crossing = 0;
            chart.AxisY.LineWidth = 3;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
                series.Points.Clear();
            xPoint.Clear();
            yPoint.Clear();
        }
    }

}
