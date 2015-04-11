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
        private string user = "DBS2Proftaak";
        private string password = "qwert12345";
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
            //If there is a correct combination between username and password a connection will be established.
            try 
            {
                connection.ConnectionString = "User Id=" + user + ";Password=" + password + ";Data Source=" + " //localhost:1521/xe" + ";"; //orcl is de servicename (kan anders zijn, is afhankelijk van de Oracle server die geinstalleerd is. Mogelijk is ook Oracle Express: xe
                connection.Open();
                MessageBox.Show("Connected to : " + user);

                using (OracleCommand oracleCommand = new OracleCommand("SELECT * FROM HOBBY"))
                {
                    using (oracleCommand.Connection = connection)
                    {

                        oracleCommand.Parameters.Add(":port_id", 1521);
                        OracleDataReader Reader = oracleCommand.ExecuteReader();

                        while(Reader.Read())
                        {
                            MessageBox.Show(Convert.ToString(Reader["HobbyNaam"]));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("The combination of username and password is incorrect");
            }
        }

        public void Close()
        {
            //Closes connection even if it is not open.
            connection.Close();
        }

        public void editDatabase()
        {
            //Make changes to the database
        }

        public void selectQuery()
        {

        }
    }
}
