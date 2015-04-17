using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class ForbiddenWord : IDatabase
    {
        private string word;
        
        private int severity;
        private int wordID;

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

        public ForbiddenWord(string word, int severity, int wordID)
        {
            this.word = word;
            this.severity = severity;
            this.wordID = wordID;
        }

        public List<ForbiddenWord> GetAll(Database database)
        {
            List<string> forbiddenWordColumns = new List<string>();
            List<ForbiddenWord> allForbiddenWords = new List<ForbiddenWord>();

            forbiddenWordColumns.Add("WOORDID");
            forbiddenWordColumns.Add("WOORD");
            forbiddenWordColumns.Add("HEVIGHEID");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM VERBODENWOORD", forbiddenWordColumns);


            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allForbiddenWords.Add(new ForbiddenWord(dataTable[2][1], Convert.ToInt32(dataTable[0][1]), Convert.ToInt32(dataTable[1][1])));
                }
            }

            return allForbiddenWords;
        }

        public T Get<T>(string forbiddenWordID, Database database)
        {
            List<string> forbiddenWordColumns = new List<string>();

            forbiddenWordColumns.Add("WOORDID");
            forbiddenWordColumns.Add("WOORD");
            forbiddenWordColumns.Add("HEVIGHEID");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM VERBODENWOORD WHERE WOORD = '" + forbiddenWordID + "'", forbiddenWordColumns);

            if (dataTable[0].Count() > 1)
            {
                return (T)Convert.ChangeType(new ForbiddenWord(dataTable[2][1], Convert.ToInt32(dataTable[0][1]), Convert.ToInt32(dataTable[1][1])), typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(null, typeof(T));
            }
        }

        public void Add<T>(T forbiddenWord, Database database)
        {
            ForbiddenWord newForbiddenWord = (ForbiddenWord)Convert.ChangeType(forbiddenWord, typeof(ForbiddenWord));
            database.editDatabase(String.Format("INSERT INTO FORBIDDENWORD VALUES ({0}, '{1}', {2})",
                newForbiddenWord.wordID, newForbiddenWord.word, newForbiddenWord.severity));
        }

        public void Edit<T>(T forbiddenWord, Database database)
        {
            ForbiddenWord updateForbiddenWord = (ForbiddenWord)Convert.ChangeType(forbiddenWord, typeof(ForbiddenWord));
            database.editDatabase("UPDATE VERBODENWOORD SET WOORD = '" + updateForbiddenWord.word + "', HEVIGHEID =  " + updateForbiddenWord.severity + " WHERE WOORDID = '" + updateForbiddenWord.WordId + "'");
        }

        public void Remove<T>(T forbiddenWord, Database database)
        {
            ForbiddenWord removeForbiddenWord = (ForbiddenWord)Convert.ChangeType(forbiddenWord, typeof(ForbiddenWord));
            database.editDatabase("DELETE FROM VERBODENWOORD WHERE WOORDID = " + removeForbiddenWord.wordID);
        }
    }
}
