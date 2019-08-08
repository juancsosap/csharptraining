using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfiniteProject
{
    public partial class InfiniteAdder : Form
    {
        public InfiniteAdder()
        {
            InitializeComponent();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            InfiniteInteger num1 = new InfiniteInteger(tbNum1.Text);
            tbNum1.Text = num1.number;
            InfiniteInteger num2 = new InfiniteInteger(tbNum2.Text);
            tbNum2.Text = num2.number;
            InfiniteInteger result = num1 + num2;
            tbResult.Text = result.ToString();
        }
    }
}
