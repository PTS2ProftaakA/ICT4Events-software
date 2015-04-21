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
                Event newEvent = new Event(name, 1, maxPersons, reportPercentage, start, end, location);

                newEvent.Add(newEvent, database);
                return true;
            }
            return false;
        }


        public bool newLocation(string locatieNaam, string address, string phoneNumber, string email, string city, string max)
        {
            int outInt;

            if (locatieNaam != "" && address != "" && phoneNumber != "" && email != "" && city != "" && int.TryParse(max, out outInt))
            {
                Location location = new Location(locatieNaam, address, phoneNumber, email, city, 1, Convert.ToInt32(max));
                location.Add(location, database);
                return true;
            }

            return false;
        }
    }
}
