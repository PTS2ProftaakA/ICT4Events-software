using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class Location : IDatabase
    {
        private string locationName;
        private string address;
        private string phoneNumber;
        private string emailaddress;

        private int locationID;
        private int maximumParticipants;

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
        public int MaximumParticipants
        {
            get { return maximumParticipants; }
            set { maximumParticipants = value; }
        }
        #endregion

        public Location(string locationName, string address, string phoneNumber, string emailaddress, int locationID, int maximumParticipants)
        {
            this.locationName = locationName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.emailaddress = emailaddress;
            this.locationID = locationID;
            this.maximumParticipants = maximumParticipants;
        }

        public T Get<T>(string locationID, Database database)
        {
            List<string> locationColumns = new List<string>();

            locationColumns.Add("LOCATIEID");
            locationColumns.Add("LOCATIENAAM");
            locationColumns.Add("MAXIMAALDEELNEMERS");
            locationColumns.Add("PLAATS");
            locationColumns.Add("ADRES");
            locationColumns.Add("TELEFOONNUMMER");
            locationColumns.Add("EMAILADRES");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM LOCATIE WHERE LOCATIEID = " + locationID, locationColumns);

            if (dataTable[0].Count() > 1)
            {
                return (T)Convert.ChangeType((new Location(
                        Convert.ToInt32(dataTable[0][1]),
                        dataTable[1][1],
                        dataTable[4][1],
                        dataTable[5][1],
                        dataTable[6][1],
                        dataTable[3][1],
                        Convert.ToInt32(dataTable[2][1]))), typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(null, typeof(T));
            }
        }

        public void Add<T>(T location, Database database)
        {
            Location newLocation = (Location)Convert.ChangeType(location, typeof(Location));
            database.editDatabase(String.Format("INSERT INTO LOCATIE VALUES ({0}, '{1}', {2}, '{3}', '{4}', '{5}', '{6}')",
                newLocation.locationID, newLocation.LocationName, newLocation.maximumParticipants, newLocation.cityname, newLocation.address, newLocation.phoneNumber, newLocation.emailaddress));
        }

        public void Edit<T>(T location, Database database)
        {
            Location updateLocation = (Location)Convert.ChangeType(location, typeof(Location));
            database.editDatabase("UPDATE LOCATIE SET LOCATIENAAM = '" + updateLocation.locationName + "' ,MAXIMAALDEELNEMERS = " + updateLocation.maximumParticipants + " ,PLAATS = '" + updateLocation.cityname + "' ,ADRES = '" + updateLocation.address + "' ,TELEFOONNUMMER = '" + updateLocation.phoneNumber + "' ,EMAILADRES = '" + updateLocation.emailaddress + "' WHERE LOCATIEID = " + updateLocation.locationID);
        }

        public void Remove<T>(T location, Database database)
        {
            Location removeLocation = (Location)Convert.ChangeType(location, typeof(Location));
            database.editDatabase("DELETE FROM LOCATIE WHERE LOCATIEID = " + removeLocation.locationID);
        }
    }
}
