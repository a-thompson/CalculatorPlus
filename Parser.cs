using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calc
{
    partial class Node
    {
        protected class Parser
        {
            double answer;
            bool error = false;

            public double getAnswer()
            {
                return answer;
            }
            public bool getError()
            {
                return error;
            }

            Node current;
            bool leftNum = true;
            bool rightNum = true;
            char negOp;

            Regex addSub = new Regex("[+-]", RegexOptions.RightToLeft);
            Regex negChar = new Regex("[AMDP]", RegexOptions.RightToLeft); //negatives
            Regex multDiv = new Regex("[*!/]", RegexOptions.RightToLeft); //factorial included here as it is multiplication
            Regex piChar = new Regex("[π]", RegexOptions.RightToLeft);
            Regex power = new Regex("[\\^]", RegexOptions.RightToLeft);
            Regex root = new Regex("[√]", RegexOptions.RightToLeft);
            Regex operations = new Regex("[+/*\\^]"); //operations that can't sit next to each other, start or end equation
            Regex negative = new Regex("[-]");
            Regex rootCheck = new Regex("[√]");
            Regex bracket = new Regex(@"[\(\)]+$");

            private string checkOps(string equation)
            {
                //check for error
                if ((equation.Contains("ERROR"))|(equation.Contains("x"))|(equation.Contains("y")))
                    error = true;
                //check for operations
                //make double negatives positve
                equation = equation.Replace("--", "+").Replace("//", "*");
                return equation;
            }

            private void checkChar(string equation)
            {
                var opCheck = addSub.Match(equation);
                if (!opCheck.Success)
                {
                    opCheck = negChar.Match(equation);
                    if (!opCheck.Success)
                    {
                        opCheck = multDiv.Match(equation);
                        if (!opCheck.Success)
                        {
                            opCheck = piChar.Match(equation);
                            if (!opCheck.Success)
                            {
                                opCheck = power.Match(equation);
                                if (!opCheck.Success)
                                    opCheck = root.Match(equation);
                            }
                        }
                    }
                }
                if (opCheck.Success)
                {
                    current.op = opCheck.Value;
                    current.left = new Node();
                    //check for left number
                    if (equation.Substring(0, opCheck.Index) == "")
                        leftNum = false;
                    else
                        leftNum = true;
                    current.left.read(equation.Substring(0, opCheck.Index));
                    current.right = new Node();
                    //check for right number
                    if (equation.Substring(opCheck.Index + 1) == "")
                        rightNum = false;
                    else
                        rightNum = true;
                    current.right.read(equation.Substring(opCheck.Index + 1));
                }
                else
                {
                    current.op = "n";
                    if (!double.TryParse(equation, out answer))
                        error = true;
                }
            }

            public void parse(string equation)
            {
                current = new Node();
                equation = checkOps(equation);


                for (int i = 0; i < equation.Count(); i++)
                {
                    if (error == true)
                        return;
                    try
                    {
                        bool negNum = false;
                        Parser calc = new Parser();
                        if ((operations.IsMatch(equation[i].ToString())) && (operations.IsMatch(equation[i + 1].ToString())))
                        {
                            error = true;
                        }
                        else if ((negative.IsMatch(equation[i].ToString()) && (operations.IsMatch(equation[i + 1].ToString()))))
                        {
                            error = true;
                        }
                        else if ((rootCheck.IsMatch(equation[i].ToString()) && ((operations.IsMatch(equation[i + 2].ToString())) | (negative.IsMatch(equation[i + 1].ToString()) | (negChar.IsMatch(equation[i + 1].ToString()))))))
                        {
                            error = true;
                        }
                        //check for negative rather than subtraction
                        else if (((bracket.IsMatch(equation[i].ToString())) | (operations.IsMatch(equation[i].ToString()))) && (negative.IsMatch(equation[i + 1].ToString())))
                        {
                            negNum = true;
                            string operation = equation[i].ToString();
                            if (operation == "+")
                                negOp = 'A'; //add
                            else if (operation == "*")
                                negOp = 'M'; //multiply
                            else if (operation == "/")
                                negOp = 'D'; //divide
                            else if (operation == "^")
                                negOp = 'P'; //power
                            else
                            {
                                error = true;
                            }
                        }
                        try
                        {
                            if (equation[i].ToString() == "")
                            {
                                negNum = true;
                                negOp = 'A'; //add
                            }
                        }
                        catch
                        {
                            negNum = true;
                            negOp = 'A'; //add
                        }
                        if (negNum == true)
                        {
                            StringBuilder str = new StringBuilder(equation);
                            str[i] = negOp;
                            string temp = str.ToString();
                            equation = temp.Remove(i + 1, 1);
                        }
                    }
                    catch
                    {
                    }
                }

                checkChar(equation);

            }


            public double calculate()
            {
                switch (current.op)
                {
                    case "n":
                        break;
                    case "+":
                        if ((leftNum == false) | (rightNum == false))
                            error = true;
                        else
                            answer = current.left.getAnswer() + current.right.getAnswer();
                        break;
                    case "-":
                        if (rightNum == false)
                            error = true;
                        else
                            answer = current.left.getAnswer() - current.right.getAnswer();
                        break;
                    case "A":
                        answer = current.left.getAnswer() + (-1) * current.right.getAnswer();
                        break;
                    case "M":
                        answer = current.left.getAnswer() * (-1) * current.right.getAnswer();
                        break;
                    case "D":
                        answer = current.left.getAnswer() / ((-1) * current.right.getAnswer());
                        break;
                    case "P":
                        answer = 1;
                        for (int i = 0; i < current.right.getAnswer(); i++)
                        {
                            answer = answer * current.left.getAnswer();
                        }
                        answer = 1 / answer;
                        break;
                    case "*":
                        if ((leftNum == false) | (rightNum == false))
                            error = true;
                        else
                            answer = current.left.getAnswer() * current.right.getAnswer();
                        break;
                    case "!":
                        try
                        {
                            if (leftNum == true)
                            {
                                int number = 1;
                                if (int.TryParse(current.left.getAnswer().ToString(), out int integer))
                                {
                                    if (current.left.getAnswer() == 0)
                                    {
                                        answer = 1;
                                    }
                                    else
                                    {
                                        for (int i = integer; i > 0; i--)
                                        {
                                            number = number * i;
                                        }
                                        answer = number;
                                        if (rightNum == true)
                                        {
                                            answer = answer * current.right.getAnswer();
                                        }
                                    }
                                }
                                else
                                    error = true;
                            }
                            else
                                error = true;
                        }
                        catch
                        {
                            error = true;
                        }
                        break;
                    case "π":
                        double pi = Math.PI;
                        if ((leftNum == false) && (rightNum == false))
                            answer = pi;
                        else if (leftNum == false)
                            answer = pi * current.right.getAnswer();
                        else if (rightNum == false)
                            answer = current.left.getAnswer() * pi;
                        else
                            answer = current.left.getAnswer() * pi * current.right.getAnswer();
                        break;
                    case "/":
                        if ((leftNum == false) | (rightNum == false))
                            error = true;
                        else
                            answer = current.left.getAnswer() / current.right.getAnswer();
                        break;
                    case "^":
                        if ((leftNum == false) | (rightNum == false))
                            error = true;
                        else
                        {
                            answer = Math.Pow(current.left.getAnswer(), current.right.getAnswer());
                        }
                        break;
                    case "√":
                        if (rightNum == false)
                            error = true;
                        answer = Math.Sqrt(current.right.getAnswer());
                        if (leftNum == true)
                            answer = current.left.getAnswer() * answer;
                        break;
                    default:
                        error = true;
                        break;
                }

                return answer;
            }
        }
    }
}

