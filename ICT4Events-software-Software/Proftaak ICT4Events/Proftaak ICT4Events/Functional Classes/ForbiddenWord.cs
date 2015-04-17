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

        public ForbiddenWord(string word, int severity)
        {
            this.word = word;
            this.severity = severity;
        }

        public List<ForbiddenWord> GetAll()
        {
            return null;
        }

        public T Get<T>(string forbiddenWordID, Database database)
        {
            return (T)Convert.ChangeType(null, typeof(T));
        }

        public void Add<T>(T forbiddenWord, Database database)
        {

        }

        public void Edit<T>(T forbiddenWord, Database database)
        {

        }

        public void Remove<T>(T forbiddenWord, Database database)
        {

        }
    }
}
