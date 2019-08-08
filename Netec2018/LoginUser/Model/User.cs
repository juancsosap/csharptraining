using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace LoginUser.Model
{
    class User
    {
        private String username;
        internal String Username
        {
            get => this.username;
            set => this.username = value;
        }

        private String password;
        internal String Password
        {
            set => this.password = value;
        }

        private bool authorized;
        internal bool Authorized
        {
            get => this.authorized;
        }

        public User(String username, String password)
        {
            this.username = username;
            this.password = password;
        }

        public bool authorize()
        {
            String connStr = "database=login;user id=root;password=roottoor;port=3306;server=localhost";
            MySqlConnection conn = new MySqlConnection(connStr);

            String query = "SELECT username FROM login " +
                           "WHERE username = '" + this.username + 
                           "' AND password = '" + this.password + "'";
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try { conn.Open(); }
            catch (Exception erro) { MessageBox.Show("Erro" + erro); }

            MySqlDataReader result = cmd.ExecuteReader();

            authorized = result.Read();

            return authorized;
        }

    }
}
