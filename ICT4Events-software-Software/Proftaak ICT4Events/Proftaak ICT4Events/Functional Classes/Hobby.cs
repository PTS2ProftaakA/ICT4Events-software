using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_ICT4Events
{
    public class Hobby : IDatabase<Hobby>
    {
        //Fields
        private string hobbyName;

        private int hobbyID;

        //Properties
        #region properties
        public string HobbyName
        {
            get { return hobbyName; }
            set { hobbyName = value; }
        }
        public int HobbyID
        {
            get { return hobbyID; }
            set { hobbyID = value; }
        }
        #endregion

        //Constructor to create a single hobby
        public Hobby(string hobbyName, int hobbyID)
        {
            this.hobbyName = hobbyName;
            this.hobbyID = hobbyID;
        }

        //A function that returns all the data from hobbies
        //Furthermore it creates hobbies from the retrieved data
        public static List<Hobby> GetAll(Database database)
        {
            List<string> hobbyColumns = new List<string>();
            List<Hobby> allHobbies = new List<Hobby>();

            hobbyColumns.Add("HOBBYID");
            hobbyColumns.Add("HOBBYNAAM");

            List<string>[] dataTable = database.selectQuery("SELECT HOBBYNAAM FROM HOBBY", hobbyColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allHobbies.Add(new Hobby(
                       dataTable[0][i],
                       Convert.ToInt32(dataTable[1][i])));
                }
            }

            return allHobbies;
        }

        //A function that returns a single Hobby from the database
        public Hobby Get(string hobbyID, Database database)
        {
            List<string> hobbyColumns = new List<string>();
            Hobby getHobby = null;

            hobbyColumns.Add("HOBBYID");
            hobbyColumns.Add("HOBBYNAAM");

            List<string>[] dataTable = database.selectQuery("SELECT HOBBYNAAM FROM HOBBY WHERE HOBBYID = " + hobbyID, hobbyColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    getHobby = new Hobby(
                       dataTable[0][i],
                       Convert.ToInt32(dataTable[1][i]));
                }
            }

            return getHobby;
        }

        //Adds a single hobby to the database
        public void Add(Hobby newHobby, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO HOBBY VALUES ({0}, '{1}')",
                newHobby.hobbyID, newHobby.hobbyName));
        }

        //Edits a hobby in the database using it's current values
        public void Edit(Hobby updateHobby, Database database)
        {
            database.editDatabase(String.Format("UPDATE HOBBY SET HOBBYNAAM = '{0}' WHERE HOBBYID = {1}",
                updateHobby.hobbyName, updateHobby.hobbyID));

        }

        //Removes a hobby from the database using the hobby's ID
        public void Remove(Hobby removeHobby, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM HOBBY WHERE HOBBYID = {0}",
                removeHobby.hobbyID));
        }
    }
}
