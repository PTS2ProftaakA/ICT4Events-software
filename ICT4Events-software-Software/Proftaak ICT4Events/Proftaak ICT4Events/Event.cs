using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class Event : IDatabase
    {
        private int eventID;
        private int amountParticipants;
        private int reportPercentage;

        private DateTime startDate;
        private DateTime endDate;

        List<User> users;
        Location location;

        #region properties
        public int EventID
        {
            get { return eventID; }
            set { eventID = value; }
        }
        public int AmountParticipants
        {
            get { return amountParticipants; }
            set { amountParticipants = value; }
        }
        public int ReportPercentage
        {
            get { return reportPercentage; }
            set { reportPercentage = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }
        public Location Location
        {
            get { return location; }
            set { location = value; }
        }
        #endregion

        public Event(int eventID, int amountParticipants, DateTime startDate, DateTime endDate, int reportPercentage, Location location)
        {
            this.eventID = eventID;
            this.amountParticipants = amountParticipants;
            this.startDate = startDate;
            this.endDate = endDate;
            this.reportPercentage = reportPercentage;
            this.location = location;

            users = new List<User>();
        }

        public List<Event> getAll()
        {
            return null;
        }

        public void Get(Type singleEvent)
        {

        }

        public void Add(Type singleEvent)
        {

        }

        public void Edit(Type singleEvent)
        {

        }

        public void Remove(Type singleEvent)
        {

        }
    }
}
