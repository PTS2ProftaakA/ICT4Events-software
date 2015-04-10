using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class Hobby
    {
        private string hobbyName;

        public string HobbyName
        {
            get { return hobbyName; }
            set { hobbyName = value; }
        }

        public Hobby(string hobbyName)
        {
            this.hobbyName = hobbyName;
        }

        public List<Hobby> GetAll()
        {
            return null;
        }
    }
}
