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
            get; set;
        }
        public int AmountParticipants{ get; set;}
        public int StartDate{ get; set;}
        public int EndDate{ get; set;}
        public int ReportPercentage{ get; set;}

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
    }
}
