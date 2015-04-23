using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class ForbiddenWord : IDatabase<ForbiddenWord>
    {
        //Fields
        private string word;
        
        private int severity;
        private int wordID;

        //Properties
        #region properties
        public string Word
        {
            get { return word; }
            set { word = value; }
        }
        public int Severity
        {
            get { return severity; }
            set { severity = value; }
        }
        #endregion

        //Constructor to make a single forbidden word
        public ForbiddenWord(string word, int severity, int wordID)
        {
            this.word = word;
            this.severity = severity;
            this.wordID = wordID;
        }

        //A function that gets data of all forbidden words in the database
        //It is used to make objects that represent these words
        public static List<ForbiddenWord> GetAll(Database database)
        {
            List<string> forbiddenWordColumns = new List<string>();
            List<ForbiddenWord> allForbiddenWords = new List<ForbiddenWord>();

            forbiddenWordColumns.Add("WOORDID");
            forbiddenWordColumns.Add("WOORD");
            forbiddenWordColumns.Add("HEVIGHEID");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM VERBODENWOORD", forbiddenWordColumns);


            if (dataTable[0].Count() > 0)
            {
                for (int i = 0; i < dataTable[0].Count(); i++)
                {
                    allForbiddenWords.Add(new ForbiddenWord(
                        dataTable[1][i], 
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToInt32(dataTable[0][i])));
                }
            }

            return allForbiddenWords;
        }

        public static List<string> GetAllStrings(Database database)
        {
            List<string> forbiddenWordColumns = new List<string>(),
                    allForbiddenWords = new List<string>();

            forbiddenWordColumns.Add("WOORD");

            List<string>[] dataTable = database.selectQuery("SELECT WOORD FROM VERBODENWOORD", forbiddenWordColumns);

            if (dataTable[0].Count() > 0)
            {
                for (int i = 0; i < dataTable[0].Count(); i++)
                {
                    allForbiddenWords.Add(dataTable[0][i]);
                }
            }

            return allForbiddenWords;
        }

        //A function that returns a single forbidden word
        public ForbiddenWord Get(string forbiddenWordID, Database database)
        {
            List<string> forbiddenWordColumns = new List<string>();
            ForbiddenWord getForbiddenWord = null;

            forbiddenWordColumns.Add("WOORDID");
            forbiddenWordColumns.Add("WOORD");
            forbiddenWordColumns.Add("HEVIGHEID");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM VERBODENWOORD WHERE WOORD = '" + forbiddenWordID + "'", forbiddenWordColumns);

            if (dataTable[0].Count() > 1)
            {
                getForbiddenWord = new ForbiddenWord(
                    dataTable[2][1], 
                    Convert.ToInt32(dataTable[0][1]), 
                    Convert.ToInt32(dataTable[1][1]));
            }

            return getForbiddenWord;
        }

        //The database adds a single forbidden word
        public void Add(ForbiddenWord newForbiddenWord, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO FORBIDDENWORD VALUES ({0}, '{1}', {2})",
                newForbiddenWord.wordID, newForbiddenWord.word, newForbiddenWord.severity));
        }

        //The database edits a forbidden word with it's current values
        public void Edit(ForbiddenWord updateForbiddenWord, Database database)
        {
            database.editDatabase(String.Format("UPDATE VERBODENWOORD SET WOORD = '{0}', HEVIGHEID = {1} WHERE WOORDID = '{2}'",
                updateForbiddenWord.word, updateForbiddenWord.severity, updateForbiddenWord.wordID));
        }

        //The database removes a single forbidden word based on its ID
        public void Remove(ForbiddenWord removeForbiddenWord, Database database)
        {
            database.editDatabase("DELETE FROM VERBODENWOORD WHERE WOORDID = " + removeForbiddenWord.wordID);
        }
    }
}
