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
        Location eventLocation;

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
        public Location EventLocation
        {
            get { return eventLocation; }
            set { eventLocation = value; }
        }
        #endregion

        public Event(string eventName, int eventID, int amountParticipants, int reportPercentage, DateTime startDate, DateTime endDate, Location eventLocation)
        {
            this.eventName = eventName;
            this.eventID = eventID;
            this.amountParticipants = amountParticipants;
            this.startDate = startDate;
            this.endDate = endDate;
            this.reportPercentage = reportPercentage;
            this.eventLocation = eventLocation;

            users = new List<User>();
        }

        public static List<Event> getAll(Database database)
        {
            List<string> eventColumns = new List<string>();
            List<Event> allEvents = new List<Event>();

            eventColumns.Add("EVENEMENTID");
            eventColumns.Add("EVENEMENTNAAM");
            eventColumns.Add("LOCATIENAAM");
            eventColumns.Add("AANTALDEELNEMERS");
            eventColumns.Add("STARTDATUM");
            eventColumns.Add("EINDDATUM");
            eventColumns.Add("RAPPORTEERPERCENTAGE");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM EVENEMENT", eventColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allEvents.Add(new Event(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[3][i]),
                        Convert.ToInt32(dataTable[6][i]),
                        Convert.ToDateTime(dataTable[4][i]),
                        Convert.ToDateTime(dataTable[5][i]),
                        Location.StaticGet(dataTable[2][i], database)));
                }
            }

            return allEvents;
        }

        public Event Get(string eventID, Database database)
        {
            List<string> eventColumns = new List<string>();
            Event getEvent = null;

            eventColumns.Add("EVENEMENTID");
            eventColumns.Add("EVENEMENTNAAM");
            eventColumns.Add("LOCATIENAAM");
            eventColumns.Add("AANTALDEELNEMERS");
            eventColumns.Add("STARTDATUM");
            eventColumns.Add("EINDDATUM");
            eventColumns.Add("RAPPORTEERPERCENTAGE");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM EVENEMENT WHERE EVENEMENTID = " + eventID, eventColumns);

            if (dataTable[0].Count() > 1)
            {
                getEvent = new Event(
                    dataTable[1][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[3][1]),
                    Convert.ToInt32(dataTable[6][1]),
                    Convert.ToDateTime(dataTable[4][1]),
                    Convert.ToDateTime(dataTable[5][1]),
                    eventLocation.Get(dataTable[2][1], database));
            }

            return getEvent;
        }

        public void Add(Event newEvent, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO EVENEMENT VALUES ({0}, '{1}', '{2}', {3}, TO_DATE('{4}', 'DD-MM-YYYY'), TO_DATE('{5}', 'DD-MM-YYYY'), {6})",
                newEvent.eventID, newEvent.eventName, newEvent.eventLocation, newEvent.amountParticipants, newEvent.startDate, newEvent.endDate, newEvent.reportPercentage));
        }

        public void Edit(Event updateEvent, Database database)
        {
            database.editDatabase(String.Format("UPDATE EVENEMENT SET EVENEMENTNAAM = '{0}', LOCATIENAAM = '{1}', AANTALDEELNEMERS = {2}, STARTDATUM = TO_DATE('{3}', 'DD-MM-YYYY'), EINDDATUM = TO_DATE('{4}', 'DD-MM-YYYY'), RAPPORTEERPERCENTAGE = {5} WHERE EVENTID = {6}",
                updateEvent.eventName, updateEvent.eventLocation, updateEvent.amountParticipants, updateEvent.startDate, updateEvent.endDate, updateEvent.reportPercentage, updateEvent.eventID));

        }

        public void Remove(Event removeEvent, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM EVENEMENT WHERE EVENEMENTID = {0}",
                removeEvent.eventID));
        }
    }
}
