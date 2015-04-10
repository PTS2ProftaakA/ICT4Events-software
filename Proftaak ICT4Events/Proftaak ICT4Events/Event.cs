using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events

{
    class Event
    {
        List<User> users;
        List<Location> locations;

        private int eventID;
        private int amountParticipants;
        private int reportPercentage;

        private DateTime startDate;
        private DateTime endDate;

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
   
        public Event(int eventID, int amountParticipants, DateTime startDate, DateTime endDate, int reportPercentage)
        {
            this.eventID = eventID;
            this.amountParticipants = amountParticipants;
            this.startDate = startDate;
            this.endDate = endDate;
            this.reportPercentage = reportPercentage;

            users = new List<User>();
            locations = new List<Location>();
        }

        public List<Event> getAll()
        {
            return null;
        }
    }
}
