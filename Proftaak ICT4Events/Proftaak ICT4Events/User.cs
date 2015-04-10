using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class User
    {
        private string rFID;
        private int eventID;
        private string name;
        private string emailAdres;
        private string photo;
        private DateTime dateOfBirth;
        private string username;
        private string password;
        private int spotNumber;
        public List<Reservation> Reservations;
        public string RFID
        {
            get { return rFID; }
            set { rFID = value; }
        }
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
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
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
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
        public int SpotNumber
        {
            get { return spotNumber; }
            set { spotNumber = value; }
        }     
        public User(string RFID, int EventID, string Emailadres, string Photo, DateTime Date, string Username, string Password, int SpotNumber)
        {
            this.rFID = RFID;
            this.EventID = EventID;
            this.EmailAdres = Emailadres;
            this.Photo = Photo;
            this.DateOfBirth = Date;
            this.Username = Username;
            this.Password = Password;
            this.SpotNumber = SpotNumber;
            Reservations = new List<Reservation>();
        }

        public User GetAll()
        {
            return this;
        }
    }
}
