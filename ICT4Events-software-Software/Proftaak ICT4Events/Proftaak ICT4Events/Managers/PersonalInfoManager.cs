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

        //Returns a specific user from the database using a function in User
        public User GetSpecificUser(int userID) 
        {
            return User.StaticGetByUserID(userID, database);
        }
    }
}
