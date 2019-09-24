using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    partial class Node
    {
        public Node()
        {
            parser = new Parser();
        }


        Parser parser;
        public void read(string str)
        {
            parser.parse(str);
        }
        public double getAnswer()
        {
            parser.calculate();
            return parser.getAnswer();
        }
        public bool getError()
        {
            return parser.getError();
        }


        Node left;
        Node right;
        string op;

    }
}
