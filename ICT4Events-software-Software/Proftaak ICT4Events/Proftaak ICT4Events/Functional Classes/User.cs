using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class User : IDatabase<User>
    {
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
        public string EmailAdres
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }
        public string PhoneNumer
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

        public static List<Material> getAll(Database database)
        {
            List<string> materialColumns = new List<string>();
            List<Material> allMaterial = new List<Material>();

            materialColumns.Add("GEBRUIKERID");
            materialColumns.Add("RFID");
            materialColumns.Add("EVENEMENTID");
            materialColumns.Add("RESERVEERDER");
            materialColumns.Add("NAAM");
            materialColumns.Add("EMAIL");
            materialColumns.Add("TELEFOONNUMMER");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MATERIAAL WHERE CATEGORIE = " + (int)category, materialColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    CategoryType categoryValue = (CategoryType)Enum.Parse(typeof(CategoryType), dataTable[5][i]);

                    allMaterial.Add(new Material(
                        dataTable[1][i],
                        dataTable[4][i],
                        dataTable[6][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToDecimal(dataTable[3][i]) / 100,
                        categoryValue));
                }
            }

            return allMaterial;
        }

        public Material Get(string materialID, Database database)
        {
            List<string> materialColumns = new List<string>();
            Material getMaterial = null;

            materialColumns.Add("MATID");
            materialColumns.Add("NAAM");
            materialColumns.Add("HOEVEELHEID");
            materialColumns.Add("BORG");
            materialColumns.Add("OMSCHRIJVING");
            materialColumns.Add("CATEGORIE");
            materialColumns.Add("FOTOPAD");

            //Has to be fixed with current database

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MATERIAAL WHERE MATID = " + materialID, materialColumns);

            if (dataTable[0].Count() > 1)
            {
                CategoryType categoryValue = (CategoryType)Enum.Parse(typeof(CategoryType), dataTable[5][1]);

                getMaterial = new Material(
                    dataTable[1][1],
                    dataTable[4][1],
                    dataTable[6][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToDecimal(dataTable[3][1]) / 100,
                    categoryValue);
            }

            return getMaterial;
        }

        public void Add(User newUser, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO GEBRUIKER VALUES ({0}, '{1}', {2}, '{3}', '{4}', '{5}', '{6}', '{7}', TO_DATE('{8}', 'DD-MM-YYYY'), '{9}', '{10}', {11}, '{12}', '{13}')",
                newUser.userID, newUser.RFID, newUser.reservee, newUser.name, newUser.emailAddress, newUser.phoneNumber, newUser.photoPath, newUser.dateOfBirth, newUser.username, newUser.password, newUser.spotNumber, newUser.administrator, newUser.loggedIn));
        }

        public void Edit(User updateUser, Database database)
        {
            database.editDatabase(String.Format("UPDATE GEBRUIKER SET NAAM = '{0}', EMAIL = '{1}', TELEFOONNUMMER = '{2}', FOTO = '{3}', GEBOORTEDATUM = TO_DATE('{4}', 'DD-MM-YYYY'), INGELOGD = '{5}'  WHERE GEBRUIKERID = {6}",
                updateUser.name, updateUser.emailAddress, updateUser.phoneNumber, updateUser.photoPath, updateUser.dateOfBirth, updateUser.loggedIn, updateUser.userID));

        }

        public void Remove(User removeUser, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM GEBRUIKER WHERE GEBRUIKERID = {0}",
                removeUser.userID));
        }
    }
}
