using BillApp.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BillApp
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void btAddItem_Click(object sender, EventArgs e)
        {
            IList<String> files = Utils.LoadPaths("PDF files | *.pdf");

            if (files != null)
            {
                foreach (String file in files)
                {
                    Boolean valid = true;
                    foreach (TreeNode node in tvList.Nodes)
                    {
                        if (node.Text.Equals(file))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (valid)
                    {
                        tvList.Nodes.Add(file);
                    }
                }
            }
        }

        private void btDelItem_Click(object sender, EventArgs e)
        {
            IList<TreeNode> checkedNodes = new List<TreeNode>();

            foreach (TreeNode node in tvList.Nodes)
            {
                if (node.Checked)
                {
                    checkedNodes.Add(node);
                }
            }

            if (checkedNodes.Count > 0)
            {
                foreach (TreeNode node in checkedNodes)
                {
                    tvList.Nodes.Remove(node);
                }
            }
            else
            {
                MessageBox.Show("Nothing to do. Please select any file to delete.", "Bill App Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btBillPath_Click(object sender, EventArgs e)
        {
            tbBillPath.Text = Utils.LoadPath("PDF files | *.pdf");
        }

        private void btOutputFolder_Click(object sender, EventArgs e)
        {
            tbOutputFolder.Text = Utils.LoadFolder();
        }

        private void btGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFormValid())
                {
                    sbInfo.Text = "Loading Bill";
                    String lang = rbES.Checked ? "es" :
                                  rbEN.Checked ? "en" : "es";
                    Bill bill = new Bill(tbBillPath.Text, lang);

                    List<OrderList> orders = new List<OrderList>();
                    int ordersCount = tvList.Nodes.Count;
                    int count = 0;
                    foreach (TreeNode order in tvList.Nodes)
                    {
                        sbInfo.Text = "Loading Orders (" + ++count + " of " + ordersCount + ")";
                        orders.Add(new OrderList(order.Text));
                    }

                    String path = Utils.GetOutputFileName(tbOutputFolder.Text, tbOutputFileName.Text);
                    BillOutputItem.ExportOutput(bill, orders, path, this);

                    sbInfo.Text = "";
                    MessageBox.Show("Export Complete", "Bill App Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Please fill all the fields.", "Bill App Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                //MessageBox.Show("Invalid File Format.", "Bill App Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        public void StatusUpdate(String msg) => sbInfo.Text = msg;

        private bool IsFormValid()
        {
            bool valid = true;
            valid = valid && (tvList.Nodes.Count > 0);
            valid = valid && (!tbBillPath.Text.Equals(""));
            valid = valid && (!tbOutputFolder.Text.Equals(""));
            valid = valid && (!tbOutputFileName.Text.Equals(""));
            return valid;
        }
    }
}
