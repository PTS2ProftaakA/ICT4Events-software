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

            hobbyColumns.Add("HOBBYID");
            hobbyColumns.Add("HOBBYNAAM");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM HOBBY", hobbyColumns);

            for(int i = 1; i < hobbyColumns[0].Count(); i++)
            {
                allHobbies.Add(new Hobby(dataTable[1][i]));
            }

            return allHobbies;
        }

        public void Get(Type hobby)
        {

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
