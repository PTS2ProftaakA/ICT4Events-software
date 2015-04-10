using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class Location
    {
        private string locationName;
        private string address;
        private string phoneNumber;
        private string emailaddress;

        private int maximumParticipants;

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

        public Location(string locationName, string address, string phoneNumber, string emailaddress, int maximumParticipants)
        {
            this.locationName = locationName;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.emailaddress = emailaddress;
            this.maximumParticipants = maximumParticipants;
        }

        public List<Location> GetAll()
        {
            return null;
        }
    }
}
