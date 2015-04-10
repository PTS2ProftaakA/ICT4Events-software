using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class User : IDatabase
    {
        private string RFID;
        private string name;
        private string emailAdres;
        private string photo;
        private string username;
        private string password;

        private int eventID;
        private int spotNumber;

        private DateTime dateOfBirth;

        private List<Reservation> reservations;
        private List<Hobby> hobbies;

        #region properties
        public string propertyRFID
        {
            get { return RFID; }
            set { RFID = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string EmailAdres
        {
            get { return emailAdres; }
            set { emailAdres = value; }
        }
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        } 
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
        public int SpotNumber
        {
            get { return spotNumber; }
            set { spotNumber = value; }
        }  
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public List<Reservation> Reservations
        {
            get { return reservations; }
            set { reservations = value; }
        }
        public List<Hobby> Hobbies
        {
            get { return hobbies; }
            set { hobbies = value; }
        }
        #endregion

        public User(string RFID, int eventID, string emailadres, string photo, DateTime date, string username, string password, int spotNumber)
        {
            this.RFID = RFID;
            this.eventID = eventID;
            this.emailAdres = emailadres;
            this.photo = photo;
            this.dateOfBirth = date;
            this.username = username;
            this.password = password;
            this.spotNumber = spotNumber;

            reservations = new List<Reservation>();
            hobbies = new List<Hobby>();
        }

        public User GetAll()
        {
            return null;
        }

        public void Get(Type comment)
        {

        }

        public void Add(Type comment)
        {

        }

        public void Edit(Type comment)
        {

        }

        public void Remove(Type comment)
        {

        }
    }
}
