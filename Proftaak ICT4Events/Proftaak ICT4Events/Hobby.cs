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

        public Hobby(string hobbyName)
        {
            this.hobbyName = hobbyName;
        }

        public string HobbyName
        {
            get { return hobbyName; }
            set { hobbyName = value; }
        }

        //public override void GetAll()
        //{
        //    //Get all hobbies from database
        //}
    }
}
