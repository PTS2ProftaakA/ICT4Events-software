using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_ICT4Events
{
    class Hobby : IDatabase
    {
        private string hobbyName;

        Database database;

        #region properties
        public string HobbyName
        {
            get { return hobbyName; }
            set { hobbyName = value; }
        }
        #endregion

        public Hobby(string hobbyName)
        {
            this.hobbyName = hobbyName;

            database = new Database();
        }

        public List<Hobby> GetAll()
        {
            List<string> hobbyColumns = new List<string>();
            List<Hobby> allHobbies = new List<Hobby>();

            hobbyColumns.Add("HOBBYNAAM");

            List<string>[] dataTable = database.selectQuery("SELECT HOBBYNAAM FROM HOBBY", hobbyColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allHobbies.Add(new Hobby(dataTable[0][i]));
                }
            }

            return allHobbies;
        }

        public List<Hobby> GetAll(string RFID)
        {
            List<string> hobbyColumns = new List<string>();
            List<Hobby> allHobbies = new List<Hobby>();

            hobbyColumns.Add("HOBBYNAAM");

            List<string>[] dataTable = database.selectQuery("SELECT HOBBYNAAM FROM HOBBY WHERE HOBBYID IN (SELECT HOBBYID FROM GEBRUIKER_HOBBY WHERE RFID = " + RFID + ")", hobbyColumns);

            for (int i = 1; i < dataTable[0].Count(); i++)
            {
                allHobbies.Add(new Hobby(dataTable[0][i]));
            }

            return allHobbies;
        }

        public Type Get(string hobbyName)
        {
            return null;
        }

        public void Add(Type hobby)
        {

        }

        public void Edit(Type hobby)
        {

        }

        public void Remove(Type hobby)
        {

        }
    }
}
