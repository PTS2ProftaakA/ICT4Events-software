using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class Location : IDatabase<Location>
    {
        //Fields
        private string locationName;
        private string address;
        private string phoneNumber;
        private string emailaddress;
        private string cityName;

        private int locationID;
        private int maximumParticipants;

        //Properties
        #region properties
        public string LocationName
        {
            get { return locationName; }
            set { locationName = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Emailaddress
        {
            get { return emailaddress; }
            set { emailaddress = value; }
        }
        public int LocationID
        {
            get { return locationID; }
            set { locationID = value; }
        }
        public int MaximumParticipants
        {
            get { return maximumParticipants; }
            set { maximumParticipants = value; }
        }
        #endregion

        //Constructor that creates location, it is used to host an event
        public Location(string locationName, string address, string phoneNumber, string emailaddress, string cityName, int locationID, int maximumParticipants)
        {
            this.locationName = locationName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.emailaddress = emailaddress;
            this.cityName = cityName;
            this.locationID = locationID;
            this.maximumParticipants = maximumParticipants;
        }

        //A function that returns a list of all locations
        //This is used to give the user a wide range of possible locations
        public static List<Location> getAll(Database database)
        {
            List<string> locationColumns = new List<string>();
            List<Location> allLocation = new List<Location>();

            locationColumns.Add("LOCATIEID");
            locationColumns.Add("LOCATIENAAM");
            locationColumns.Add("MAXIMAALDEELNEMERS");
            locationColumns.Add("PLAATS");
            locationColumns.Add("ADRES");
            locationColumns.Add("TELEFOONNUMMER");
            locationColumns.Add("EMAILADRES");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM LOCATIE", locationColumns);

            if (dataTable[0].Count() >= 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allLocation.Add(new Location(
                        dataTable[1][i],
                        dataTable[4][i],
                        dataTable[5][i],
                        dataTable[6][i],
                        dataTable[3][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i])));
                }
            }

            return allLocation;
        }

        //returns a single Location that corresponds with the locationID
        public Location Get(string locationID, Database database)
        {
            List<string> locationColumns = new List<string>();
            Location getLocation = null;

            locationColumns.Add("LOCATIEID");
            locationColumns.Add("LOCATIENAAM");
            locationColumns.Add("MAXIMAALDEELNEMERS");
            locationColumns.Add("PLAATS");
            locationColumns.Add("ADRES");
            locationColumns.Add("TELEFOONNUMMER");
            locationColumns.Add("EMAILADRES");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM LOCATIE WHERE LOCATIEID = " + locationID, locationColumns);

            if (dataTable[0].Count() >= 1)
            {
                getLocation = new Location(
                        dataTable[1][1],
                        dataTable[4][1],
                        dataTable[5][1],
                        dataTable[6][1],
                        dataTable[3][1],
                        Convert.ToInt32(dataTable[0][1]),
                        Convert.ToInt32(dataTable[2][1]));
            }

            return getLocation;
        }

        //Returns a single location that corresponds with a locationID
        //This function is more accessible for classes
        public static Location StaticGet(string locationID, Database database)
        {
            List<string> locationColumns = new List<string>();
            Location getLocation = null;

            locationColumns.Add("LOCATIEID");
            locationColumns.Add("LOCATIENAAM");
            locationColumns.Add("MAXIMAALDEELNEMERS");
            locationColumns.Add("PLAATS");
            locationColumns.Add("ADRES");
            locationColumns.Add("TELEFOONNUMMER");
            locationColumns.Add("EMAILADRES");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM LOCATIE WHERE LOCATIEID = " + locationID, locationColumns);

            if (dataTable[0].Count() >= 1)
            {
                getLocation = new Location(
                        dataTable[1][1],
                        dataTable[4][1],
                        dataTable[5][1],
                        dataTable[6][1],
                        dataTable[3][1],
                        Convert.ToInt32(dataTable[0][1]),
                        Convert.ToInt32(dataTable[2][1]));
            }

            return getLocation;
        }

        //Adds a single location to the database
        public void Add(Location newLocation, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO LOCATIE VALUES ({0}, '{1}', {2}, '{3}', '{4}', '{5}', '{6}')",
                newLocation.locationID, newLocation.LocationName, newLocation.maximumParticipants, newLocation.cityName, newLocation.address, newLocation.phoneNumber, newLocation.emailaddress));
        }

        //Edits a location with the current values of the location
        public void Edit(Location updateLocation, Database database)
        {
            database.editDatabase(String.Format("UPDATE LOCATIE SET LOCATIENAAM = '{1}', MAXIMAALDEELNEMERS = {2}, PLAATS = '{3}', ADRES = '{4}', TELEFOONNUMMER = '{5}', EMAILADRES = '{6}' WHERE LOCATIEID = {7}",
                updateLocation.locationName, updateLocation.maximumParticipants, updateLocation.cityName, updateLocation.address, updateLocation.phoneNumber, updateLocation.emailaddress, updateLocation.locationID));
        }

        //Removes a single location corresponding to the input location
        public void Remove(Location removeLocation, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM LOCATIE WHERE LOCATIEID = {0}",
                removeLocation.locationID));
        }

        //Returns a more presentable and readable string to define the location
        public override string ToString()
        {
            return locationName;
        }
    }
}
