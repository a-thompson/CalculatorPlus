using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        public bool clear = false;

        private void clearBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
            clear = true;
        }
    }
}
