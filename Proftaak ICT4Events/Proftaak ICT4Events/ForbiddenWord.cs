using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class ForbiddenWord
    {
        private string word;

        private int severity;

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

        public ForbiddenWord(string word, int severity)
        {
            this.word = word;
            this.severity = severity;
        }

        public List<ForbiddenWord> GetAll()
        {
            return null;
        }
    }
}
