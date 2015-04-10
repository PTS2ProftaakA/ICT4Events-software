using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class User
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
        
        public List<Reservation> Reservations;

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

            Reservations = new List<Reservation>();
        }

        public User GetAll()
        {
            return null;
        }
    }
}
