using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class User : IDatabase<User>
    {
        //Fields
        private string RFID;
        private string reservee;
        private string name;
        private string emailAddress;
        private string phoneNumber;
        private string photoPath;
        private string username;
        private string password;

        private int userID;
        private int eventID;
        private int spotNumber;

        private bool administrator;
        private bool loggedIn;

        private DateTime dateOfBirth;

        private List<Reservation> reservations;
        private List<Hobby> hobbies;

        //properties
        #region properties
        public string propertyRFID
        {
            get { return RFID; }
            set { RFID = value; }
        }
        public string Reservee
        {
            get { return reservee; }
            set { reservee = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string PhotoPath
        {
            get { return photoPath; }
            set { photoPath = value; }
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
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public int SpotNumber
        {
            get { return spotNumber; }
            set { spotNumber = value; }
        }
        public bool Administrator
        {
            get { return administrator; }
            set { administrator = value; }
        }
        public bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
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

        //Constructor that creates a user as part of an event
        public User(string RFID, string reservee, string name, string emailAddress, string phoneNumber, string photoPath, string username, string password, int userID, int eventID, int spotNumber, bool administrator, bool loggedIn, DateTime dateOfBirth)
        {
            this.RFID = RFID;
            this.reservee = reservee;
            this.name = name;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.photoPath = photoPath;
            this.username = username;
            this.password = password;
            this.userID = userID;
            this.eventID = eventID;
            this.spotNumber = spotNumber;
            this.administrator = administrator;
            this.loggedIn = loggedIn;
            this.dateOfBirth = dateOfBirth;

            reservations = new List<Reservation>();
            hobbies = new List<Hobby>();
        }

        //Creates a user with fewer properties for implementation purposes
        public User(string RFID, string reservee, string name, string emailAddress, string username, string password, bool administrator, bool loggedIn, int userID, int spotNumber)
        {
            this.RFID = RFID;
            this.reservee = reservee;
            this.name = name;
            this.emailAddress = emailAddress;
            this.username = username;
            this.password = password;
            this.administrator = administrator;
            this.loggedIn = loggedIn;
            this.userID = userID;
            this.spotNumber = spotNumber;

            string test = administrator ? "Y" : "N";
        }

        //Gets all the users from the database using the more complete constructor
        public static List<User> getAll(Database database)
        {
            List<string> userColumns = new List<string>();
            List<User> allUsers = new List<User>();

            userColumns.Add("GEBRUIKERID");
            userColumns.Add("RFID");
            userColumns.Add("EVENEMENTID");
            userColumns.Add("RESERVEERDER");
            userColumns.Add("NAAM");
            userColumns.Add("EMAIL");
            userColumns.Add("TELEFOONNUMMER");
            userColumns.Add("FOTO");
            userColumns.Add("GEBOORTEDATUM");
            userColumns.Add("INLOGNAAM");
            userColumns.Add("WACHTWOORD");
            userColumns.Add("PLAATSNUMMER");
            userColumns.Add("ADMINISTRATOR");
            userColumns.Add("INGELOGD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  GEBRUIKER", userColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allUsers.Add(new User(
                        dataTable[1][i],
                        dataTable[3][i],
                        dataTable[4][i],
                        dataTable[5][i],
                        dataTable[6][i],
                        dataTable[7][i],
                        dataTable[9][i],
                        dataTable[10][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToInt32(dataTable[11][i]),
                        dataTable[12][i].ToUpper() == "Y",
                        dataTable[13][i].ToUpper() == "Y",
                        Convert.ToDateTime(dataTable[8][i])
                        ));
                }
            }

            return allUsers;
        }

        //Gets all the users from the database that are logged in
        public static List<User> getAllLoggedIn(Database database)
        {
            List<string> userColumns = new List<string>();
            List<User> allUsers = new List<User>();

            userColumns.Add("GEBRUIKERID");
            userColumns.Add("RFID");
            userColumns.Add("EVENEMENTID");
            userColumns.Add("RESERVEERDER");
            userColumns.Add("NAAM");
            userColumns.Add("EMAIL");
            userColumns.Add("TELEFOONNUMMER");
            userColumns.Add("FOTO");
            userColumns.Add("GEBOORTEDATUM");
            userColumns.Add("INLOGNAAM");
            userColumns.Add("WACHTWOORD");
            userColumns.Add("PLAATSNUMMER");
            userColumns.Add("ADMINISTRATOR");
            userColumns.Add("INGELOGD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  GEBRUIKER WHERE INGELOGD = 'Y'", userColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allUsers.Add(new User(
                        dataTable[1][i],
                        dataTable[3][i],
                        dataTable[4][i],
                        dataTable[5][i],
                        dataTable[6][i],
                        dataTable[7][i],
                        dataTable[9][i],
                        dataTable[10][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToInt32(dataTable[11][i]),
                        dataTable[12][i].ToUpper() == "Y",
                        dataTable[13][i].ToUpper() == "Y",
                        Convert.ToDateTime(dataTable[8][i])
                        ));
                }
            }

            return allUsers;
        }

        //Returns a single user from the database that corresponds with the ID input
        public User Get(string userID, Database database)
        {
            List<string> userColumns = new List<string>();
            User getUser = null;

            userColumns.Add("GEBRUIKERID");
            userColumns.Add("RFID");
            userColumns.Add("EVENEMENTID");
            userColumns.Add("RESERVEERDER");
            userColumns.Add("NAAM");
            userColumns.Add("EMAIL");
            userColumns.Add("TELEFOONNUMMER");
            userColumns.Add("FOTO");
            userColumns.Add("GEBOORTEDATUM");
            userColumns.Add("INLOGNAAM");
            userColumns.Add("WACHTWOORD");
            userColumns.Add("PLAATSNUMMER");
            userColumns.Add("ADMINISTRATOR");
            userColumns.Add("INGELOGD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  GEBRUIKER WHERE GEBRUIKERID = " + userID, userColumns);

            if (dataTable[0].Count() > 1)
            {
                    getUser = new User(
                        dataTable[1][1],
                        dataTable[3][1],
                        dataTable[4][1],
                        dataTable[5][1],
                        dataTable[6][1],
                        dataTable[7][1],
                        dataTable[9][1],
                        dataTable[10][1],
                        Convert.ToInt32(dataTable[0][1]),
                        Convert.ToInt32(dataTable[2][1]),
                        Convert.ToInt32(dataTable[11][1]),
                        dataTable[12][1].ToUpper() == "Y",
                        dataTable[13][1].ToUpper() == "Y",
                        Convert.ToDateTime(dataTable[8][1])
                        );
            }

            return getUser;
        }

        //Returns a single user from the database that corresponds with the ID input
        //This get function is more accesible because of the static property
        public static User StaticGetByRFID(string RFID, Database database)
        {
            List<string> userColumns = new List<string>();
            User getUser = null;

            userColumns.Add("GEBRUIKERID");
            userColumns.Add("RFID");
            userColumns.Add("EVENEMENTID");
            userColumns.Add("RESERVEERDER");
            userColumns.Add("NAAM");
            userColumns.Add("EMAIL");
            userColumns.Add("TELEFOONNUMMER");
            userColumns.Add("FOTO");
            userColumns.Add("GEBOORTEDATUM");
            userColumns.Add("INLOGNAAM");
            userColumns.Add("WACHTWOORD");
            userColumns.Add("PLAATSNUMMER");
            userColumns.Add("ADMINISTRATOR");
            userColumns.Add("INGELOGD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  GEBRUIKER WHERE RFID = '" + RFID + "'", userColumns);

            if (dataTable[0].Count() > 1)
            {
                getUser = new User(
                    dataTable[1][1],
                    dataTable[3][1],
                    dataTable[4][1],
                    dataTable[5][1],
                    dataTable[6][1],
                    dataTable[7][1],
                    dataTable[9][1],
                    dataTable[10][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToInt32(dataTable[11][1]),
                    dataTable[12][1].ToUpper() == "Y",
                    dataTable[13][1].ToUpper() == "Y",
                    Convert.ToDateTime(dataTable[8][1])
                    );
            }
            return getUser;
        }

        public static User StaticGetByUserID(int userID, Database database)
        {
            List<string> userColumns = new List<string>();
            User getUser = null;

            userColumns.Add("GEBRUIKERID");
            userColumns.Add("RFID");
            userColumns.Add("EVENEMENTID");
            userColumns.Add("RESERVEERDER");
            userColumns.Add("NAAM");
            userColumns.Add("EMAIL");
            userColumns.Add("TELEFOONNUMMER");
            userColumns.Add("FOTO");
            userColumns.Add("GEBOORTEDATUM");
            userColumns.Add("INLOGNAAM");
            userColumns.Add("WACHTWOORD");
            userColumns.Add("PLAATSNUMMER");
            userColumns.Add("ADMINISTRATOR");
            userColumns.Add("INGELOGD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  GEBRUIKER WHERE GEBRUIKERID = " + userID, userColumns);

            if (dataTable[0].Count() > 1)
            {
                getUser = new User(
                    dataTable[1][1],
                    dataTable[3][1],
                    dataTable[4][1],
                    dataTable[5][1],
                    dataTable[6][1],
                    dataTable[7][1],
                    dataTable[9][1],
                    dataTable[10][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToInt32(dataTable[11][1]),
                    dataTable[12][1].ToUpper() == "Y",
                    dataTable[13][1].ToUpper() == "Y",
                    Convert.ToDateTime(dataTable[8][1])
                    );
            }
            return getUser;
        }

        //Returns a single user from the database that corresponds with the username and password
        //This get function is more accesible because of the static property
        public static User StaticGet(string username, string password, Database database)
        {
            List<string> userColumns = new List<string>();
            User getUser = null;

            userColumns.Add("GEBRUIKERID");
            userColumns.Add("RFID");
            userColumns.Add("EVENEMENTID");
            userColumns.Add("RESERVEERDER");
            userColumns.Add("NAAM");
            userColumns.Add("EMAIL");
            userColumns.Add("TELEFOONNUMMER");
            userColumns.Add("FOTO");
            userColumns.Add("GEBOORTEDATUM");
            userColumns.Add("INLOGNAAM");
            userColumns.Add("WACHTWOORD");
            userColumns.Add("PLAATSNUMMER");
            userColumns.Add("ADMINISTRATOR");
            userColumns.Add("INGELOGD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  GEBRUIKER WHERE INLOGNAAM = '" + username + "' AND WACHTWOORD = '" + password + "'", userColumns);

            if (dataTable[0].Count() > 1)
            {
                getUser = new User(
                    dataTable[1][1],
                    dataTable[3][1],
                    dataTable[4][1],
                    dataTable[5][1],
                    dataTable[6][1],
                    dataTable[7][1],
                    dataTable[9][1],
                    dataTable[10][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToInt32(dataTable[11][1]),
                    dataTable[12][1].ToUpper() == "Y",
                    dataTable[13][1].ToUpper() == "Y",
                    Convert.ToDateTime(dataTable[8][1])
                    );
            }
            return getUser;
        }

        //Switches the status of the user to logged in or not
        public void SetLogIn(string status, int userID, Database database)
        {
            database.editDatabase("UPDATE GEBRUIKER SET INGELOGD = '" + status + "' WHERE GEBRUIKERID = " + userID);
        }

        //Adds a user to the database
        public void Add(User newUser, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO GEBRUIKER VALUES ({0}, '{1}', {2}, '{3}', '{4}', '{5}', '{6}', '{7}', TO_DATE('{8}', 'DD/MM/YYYY HH24:MI:SS', '{9}', '{10}', {11}, '{12}', '{13}')",
                newUser.userID, newUser.RFID, newUser.reservee, newUser.name, newUser.emailAddress, newUser.phoneNumber, newUser.photoPath, newUser.dateOfBirth, newUser.username, newUser.password, newUser.spotNumber, newUser.administrator, newUser.loggedIn ? "Y" : "N"));
        }

        //Adds a more basic user to the database
        public void AddBasicUser(User newUser, Database database)
        {
            String s = String.Format("INSERT INTO GEBRUIKER(RFID, RESERVEERDER, NAAM, EMAIL, INLOGNAAM, WACHTWOORD, ADMINISTRATOR, INGELOGD, GEBRUIKERID,PLAATSNUMMER ) VALUES ('{0}', {1}, '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', GEBRUIKERSEQUENCE.nextval, {8})",
               newUser.RFID, newUser.reservee, newUser.name, newUser.emailAddress, newUser.username, newUser.password, newUser.administrator ? "Y" : "N", newUser.loggedIn ? "Y" : "N", newUser.spotNumber);

            database.editDatabase(s);
        }

        //Edits the input user to it's current values
        public void Edit(User updateUser, Database database)
        {
            database.editDatabase(String.Format("UPDATE GEBRUIKER SET NAAM = '{0}', EMAIL = '{1}', TELEFOONNUMMER = '{2}', FOTO = '{3}', GEBOORTEDATUM = TO_DATE('{4}', 'DD/MM/YYYY HH24:MI:SS'), INGELOGD = '{5}', INLOGNAAM = '{6}'  WHERE GEBRUIKERID = {7}",
                updateUser.name, updateUser.emailAddress, updateUser.phoneNumber, updateUser.photoPath, updateUser.dateOfBirth, updateUser.loggedIn ? "Y" : "N", updateUser.username, updateUser.userID));

        }

        //Removes the input user from the database
        public void Remove(User removeUser, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM GEBRUIKER WHERE GEBRUIKERID = {0}",
                removeUser.userID));
        }

        public override string ToString()
        {
            return userID + "\t" + username;
        }
    }
}
