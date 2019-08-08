using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginUser.Controller
{
    class FormController
    {
        internal static void init(fmLogin src)
        {
            src.btLogin.Click += new System.EventHandler(btLogin_Click);
        }

        private static void btLogin_Click(object sender, EventArgs e)
        {
            fmLogin src = ((fmLogin) ((Button)sender).Parent);
            Model.User user = new Model.User(src.tbUsername.Text, src.tbPassword.Text);
            MessageBox.Show("Authorized: " + user.authorize());
        }

    }
}
