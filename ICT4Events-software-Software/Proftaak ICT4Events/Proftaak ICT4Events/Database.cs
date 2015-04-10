using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Windows.Forms;

namespace Proftaak_ICT4Events
{

    public class Database
    {
        //private OracleConnection connection;
        private string query;
        private string user;
        private string password;
        private OracleConnection connection;

        #region properties
        public string User
        {
            get { return user;}
            set { user = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        #endregion 

        public Database()
        {
            try
            {
                connection = new OracleConnection();


            }
            catch(OracleException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Connect()
        {
            //needs actual username and password to the database
            string user = "username";
            string pw = "password";
            connection.ConnectionString = "User Id=" + user + ";Password=" + pw + ";Data Source=" + " //localhost:1521/xe" + ";"; //orcl is de servicename (kan anders zijn, is afhankelijk van de Oracle server die geinstalleerd is. Mogelijk is ook Oracle Express: xe
            connection.Open();
            MessageBox.Show("Connectie gelukt!");
        }

        public void Close()
        {
            //Close the database
        }

        public void editDatabase()
        {
            //Make changes to the database
        }

        public void selectQuery()
        {
            //Select correct query
        }
    }
}
