using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class Event : IDatabase<Event>
    {
        private string eventName;

        private int eventID;
        private int amountParticipants;
        private int reportPercentage;

        private DateTime startDate;
        private DateTime endDate;

        List<User> users;
        Location location;

        #region properties
        public string EventName
        {
            get { return eventName; }
            set { eventName = value; }
        }
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

        public Event(string eventName, int eventID, int amountParticipants, DateTime startDate, DateTime endDate, int reportPercentage, Location location)
        {
            this.eventName = eventName;
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

        public Event Get(string eventID, Database database)
        {
            return null;
        }

        public void Add(Event newEvent, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO EVENEMENT VALUES ({0}, '{1}', '{2}', {3}, TO_DATE('{4}', 'DD-MM-YYYY'), TO_DATE('{5}', 'DD-MM-YYYY'), {6})",
                newEvent.eventID, newEvent.eventName, newEvent.location, newEvent.amountParticipants, newEvent.startDate, newEvent.endDate, newEvent.reportPercentage));
        }

        public void Edit(Event updateEvent, Database database)
        {
            database.editDatabase(String.Format("UPDATE EVENEMENT SET EVENEMENTNAAM = '{0}', LOCATIENAAM = '{1}', AANTALDEELNEMERS = {2}, STARTDATUM = TO_DATE('{3}', 'DD-MM-YYYY'), EINDDATUM = TO_DATE('{4}', 'DD-MM-YYYY'), RAPPORTEERPERCENTAGE = {5} WHERE EVENTID = {6}",
                updateEvent.eventName, updateEvent.location, updateEvent.amountParticipants, updateEvent.startDate, updateEvent.endDate, updateEvent.reportPercentage, updateEvent.eventID));

        }

        public void Remove(Event removeEvent, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM EVENEMENT WHERE EVENEMENTID = {0}",
                removeEvent.eventID));
        }
    }
}
