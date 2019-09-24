using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Calc
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            Thread t = new Thread(new ThreadStart(displaySplash));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();

        }
        private void displaySplash()
        {
            try
            {
                Application.Run(new Load());
            }
            catch { }
        }

        List<string> history = new List<string>();
        public List<string> graphs = new List<string>();
        string save = @"history.txt";

        //numbers
        private void zeroBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "0";
        }
        private void oneBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "1";
        }
        private void twoBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "2";
        }
        private void threeBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "3";
        }
        private void fourBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "4";
        }
        private void fiveBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "5";
        }
        private void sixBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "6";
        }
        private void sevenBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "7";
        }
        private void eightBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "8";
        }
        private void nineBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "9";
        }
        private void decimalBtn_Click(object sender, EventArgs e)
        {
            try
            {
                char lastChar = mathText.Text.ToCharArray().ElementAt(mathText.Text.Length - 1);

                if (char.IsNumber(lastChar))
                    mathText.Text = mathText.Text + ".";
                else
                    mathText.Text = mathText.Text + "0.";
            }
            catch
            {
                mathText.Text = mathText.Text + "0.";
            }
        }

        //parentheses
        private void rightBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "(";
        }
        private void leftBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + ")";
        }

        //delete
        private void clearBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = null;
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (mathText.Text != "")
            {
                //delete symbol bracket is attached to
                if ((mathText.Text.EndsWith("√(")) || (mathText.Text.EndsWith("^(")) || (mathText.Text.EndsWith("^2")))
                    mathText.Text = mathText.Text.Remove(mathText.Text.Length - 2);
                if (mathText.Text == "ERROR")
                    mathText.Text = null;
                else
                    mathText.Text = mathText.Text.Remove(mathText.Text.Length - 1);
            }
        }

        private void equalsBtn_Click(object sender, EventArgs e)
        {
            //add equation to history
            history.Add(mathText.Text);
            Regex digits = new Regex("[1-9!π]");
            Regex fact = new Regex("[!]");
            double answer = 0;
            Node math = new Node();
            if (mathText.Text.Contains("("))
            {
                string nestEq;
                int index1 = 0;
                int index2 = 0;
                //check for matching brackets
                int bracket1 = mathText.Text.Count(x => x == '(');
                int bracket2 = mathText.Text.Count(x => x == ')');
                if (bracket1 == bracket2)
                {
                    while (mathText.Text.Contains("("))
                    {
                        //find innermost brackets
                        index1 = mathText.Text.LastIndexOf("(");
                        nestEq = mathText.Text.Remove(0, index1 + 1);
                        index2 = nestEq.IndexOf(")");
                        nestEq = nestEq.Remove(index2);

                        math.read(nestEq);
                        answer = math.getAnswer();
                        if (math.getError() == false)
                        {
                            nestEq = "(" + nestEq + ")";
                            string nestAns = answer.ToString();
                            string newEq = "";
                            try
                            {
                                if (digits.IsMatch(mathText.Text[index1 - 1].ToString()))
                                {
                                    nestAns = "*" + nestAns;
                                }
                            }
                            catch
                            { }
                            try
                            {
                                if (digits.IsMatch(mathText.Text[index1 + index2 + 2].ToString()))
                                {
                                    nestAns = nestAns + "*";
                                }
                                //check if nested eq is negative and right op is !
                                if ((fact.IsMatch(mathText.Text[index1 + index2 + 2].ToString())) && (answer < 0))
                                {
                                    mathText.Text = "ERROR";
                                }
                            }
                            catch
                            { }
                            newEq = mathText.Text.Replace(nestEq, nestAns);
                            mathText.Text = newEq;
                        }
                        else
                        {
                            mathText.Text = "ERROR";
                            break;
                        }

                    }
                }
                else
                    mathText.Text = "ERROR";
            }

            math.read(mathText.Text);
            answer = math.getAnswer();
            if (math.getError() == false)
                mathText.Text = answer.ToString();
            else
                mathText.Text = "ERROR";
            history.Add(mathText.Text);
        }

        //basic operations
        private void addBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "+";
        }
        private void minusBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "-";
        }
        private void multiplyBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "*";
        }
        private void divideBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "/";
        }

        //Options (Form 2)
        private void optionsBtn_Click(object sender, EventArgs e)
        {
            Options form2 = new Options();
            form2.ShowDialog();
            if (form2.flipBox.Checked)
            {
                flipBtn.Visible = true;
            }
            else
            {
                flipBtn.Visible = false;
            }
            if (form2.powBox.Checked)
            {
                powBtn.Visible = true;
            }
            else
            {
                powBtn.Visible = false;
            }
            if (form2.squareBox.Checked)
            {
                squareBtn.Visible = true;
            }
            else
            {
                squareBtn.Visible = false;
            }
            if (form2.rootBox.Checked)
            {
                rootBtn.Visible = true;
            }
            else
            {
                rootBtn.Visible = false;
            }
            if (form2.piBox.Checked)
            {
                piBtn.Visible = true;
            }
            else
            {
                piBtn.Visible = false;
            }
            if (form2.factBox.Checked)
            {
                factBtn.Visible = true;
            }
            else
            {
                factBtn.Visible = false;
            }
        }

        //added operations
        private void squareBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "^2";
        }
        private void rootBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "√(";
        }
        private void piBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "π";
        }
        private void powBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "^(";
        }
        private void flipBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = "1/(" + mathText.Text + ")";
        }
        private void factBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + "!";
        }

        //History - Form 3
        private void historyBtn_Click(object sender, EventArgs e)
        {
            History form3 = new History();
            //display only last 100 entries of history
            //full history may still be viewed via file
            int start = 0;
            if (history.Count > 100)
                start = history.Count - 100;
            for (int i = start; i < history.Count; i++)
            {
                form3.richTextBox1.Text = form3.richTextBox1.Text + history[i] + "\n";
            }
            form3.ShowDialog();
            if (form3.clear == true)
            {
                history.Clear();
                graphs.Clear();
                mathText.Text = "";
                if (File.Exists(save))
                    File.Delete(save);
            }
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            if (File.Exists(save))
            {
                string[] file = File.ReadAllLines(save);
                byte[] data;
                foreach (string math in file)
                {
                    try
                    {
                        data = Convert.FromBase64String(math);
                        history.Add(Encoding.UTF8.GetString(data));
                    }
                    catch
                    {
                        //continue
                    }

                }
            }
        }
        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (history.Count > 0)
            {
                int start = 0;
                //prevent file bloating by only recording last 100 entries
                if (history.Count > 100)
                    start = history.Count - 100;
                StreamWriter wr = new StreamWriter(save, true);
                for (int i = start; i < history.Count; i++)
                {
                    var plainTextBytes = Encoding.UTF8.GetBytes(history[i]); //convert string into bytes
                    wr.WriteLine(Convert.ToBase64String(plainTextBytes));
                }
                wr.Close();
            }
        }

        //Graph - Form 4
        private void graphBtn_Click(object sender, EventArgs e)
        {

            Graph form4 = new Graph();

            if (graphs.Count() > 0)
            {
                foreach (string equation in graphs)
                {
                    form4.eq1Combo.Items.Add(equation);
                }
            }

            form4.ShowDialog();
        }
        private void varBtn_Click(object sender, EventArgs e)
        {
            mathText.Text = mathText.Text + varBtn.Text;
        }


        private void functionBtn_Click(object sender, EventArgs e)
        {
            //Axis information found is here because I originally intended to
            //graph both x and y functions.  I accidentally broke the x functions
            //the day of the final presentation when programming a different
            //graph feature.
            string axis = "y";
            if (mathText.Text != "")
            {
                string function = axis + " = " + mathText.Text;
                if (!graphs.Contains(function))
                {
                    graphs.Add(function);
                    history.Add(mathText.Text);
                }
            }
        }

    }

}
