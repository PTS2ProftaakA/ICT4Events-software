using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class EventManager
    {
        Database database;

        public EventManager(Database database)
        {
            this.database = database;
        }
        public List<Comment> GetReactions(MediaFile file)
        {
            return Comment.GetAllFromFile(file.FilePath, database);
        }

        public List<Event> getAllEvents()
        {
            return Event.getAll(database);
        }
        public List<Location> getAllLocations()
        {
            return Location.getAll(database);
        }
        public bool editEvent(Event eventToEdit, Location location, string name, DateTime start, DateTime end, int maxPersons, int reportPercentage)
        {
            if (name != null || start <= end)
            {
                eventToEdit.EventName = name;
                eventToEdit.EventLocation = location;
                eventToEdit.StartDate = start;
                eventToEdit.EndDate = end;
                eventToEdit.AmountParticipants = maxPersons;
                eventToEdit.ReportPercentage = reportPercentage;

                eventToEdit.Edit(eventToEdit, database);

                return true;
            }
            return false;
        }
        public bool makeEvent(Location location, string name, DateTime start, DateTime end, int maxPersons, int reportPercentage)
        {
            if (name != null || start <= end)
            {
                Event nieuwEvent = new Event(name, database.nextSequenceValue("EVENTSEQUENCE"), maxPersons, reportPercentage, start, end, location);

                nieuwEvent.Edit(nieuwEvent, database);
                return true;
            }
            return false;
        }


        public void newLocation(string locatieNaam, string address, string phoneNumber, string email, string city, int max)
        {
            // ER MOET HIER NOG GECHECKED WORDEN OF VALUES KLOPPEN
            Location location = new Location(locatieNaam, address, phoneNumber, email, city, database.nextSequenceValue("PLAATSSEQUENCE"), max);
            location.Add(location, database);
        }
    }
}
