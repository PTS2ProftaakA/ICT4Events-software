using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class PersonalInfoManager
    {
        Database database;

        public PersonalInfoManager(Database database)
        {
            this.database = database;
        }

        public User GetSpecificUser(string RFID) 
        {
            return null;
        }

        public void SaveUser(User user) 
        {

        }
    }
}
