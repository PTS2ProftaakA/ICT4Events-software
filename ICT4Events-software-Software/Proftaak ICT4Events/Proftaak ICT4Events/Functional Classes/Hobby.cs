﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_ICT4Events
{
    class Hobby : IDatabase<Hobby>
    {
        private string hobbyName;

        private int hobbyID;

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

        public Hobby(string hobbyName, int hobbyID)
        {
            this.hobbyName = hobbyName;
            this.hobbyID = hobbyID;
        }

        public List<Hobby> GetAll(Database database)
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

        public List<Hobby> GetAll(string RFID, Database database)
        {
            List<string> hobbyColumns = new List<string>();
            List<Hobby> allHobbies = new List<Hobby>();

            hobbyColumns.Add("HOBBYID");
            hobbyColumns.Add("HOBBYNAAM");

            List<string>[] dataTable = database.selectQuery("SELECT HOBBYNAAM FROM HOBBY WHERE HOBBYID IN (SELECT HOBBYID FROM GEBRUIKER_HOBBY WHERE RFID = " + RFID + ")", hobbyColumns);

            for (int i = 1; i < dataTable[0].Count(); i++)
            {
                allHobbies.Add(new Hobby(
                    dataTable[0][i],
                    Convert.ToInt32(dataTable[1][i])));
            }

            return allHobbies;
        }

        public Hobby Get(string hobbyID, Database database)
        {
            return null;
        }

        public void Add(Hobby newHobby, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO HOBBY VALUES ({0}, '{1}')",
                newHobby.hobbyID, newHobby.hobbyName));
        }

        public void Edit(Hobby updateHobby, Database database)
        {
            database.editDatabase(String.Format("UPDATE HOBBY SET HOBBYNAAM = '{0}' WHERE HOBBYID = {1}",
                updateHobby.hobbyName, updateHobby.hobbyID));

        }

        public void Remove(Hobby removeHobby, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM HOBBY WHERE HOBBYID = {0}",
                removeHobby.hobbyID));
        }
    }
}
