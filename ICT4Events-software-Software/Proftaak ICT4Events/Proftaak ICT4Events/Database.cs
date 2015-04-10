using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{

    public class Database
    {
        //private OracleConnection connection;
        private string query;
        private string user;
        private string password;

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

        public void Connect()
        {
            //Connect to the database
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
