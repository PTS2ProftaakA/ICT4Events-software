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
        private int startDate;
        private int endDate;
        private int reportpercentage;
        
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
        public int StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public int EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        public int ReportPercentage
        {
            get { return reportpercentage; }
            set { reportpercentage = value; }
        }

        public Event(int EventID, int AmountParticipants, int StartDate, int EndDate, int ReportPercentage)
        {
            this.EventID = EventID;
            this.AmountParticipants = AmountParticipants;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.ReportPercentage = ReportPercentage;

            users = new List<User>();
            locations = new List<Location>();
        }

        public List<Event> getAll()
        {
            return null;
        }
    }
}
