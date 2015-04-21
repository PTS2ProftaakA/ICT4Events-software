using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class MapManager
    {
        Database database;

        public MapManager(Database database)
        {
            this.database = database;
        }

        public List<Spot> GetAllspots()
        {
            return Spot.getAll(database);
        }

        public List<SpotType> GetAllSpotTypes()
        {
            return SpotType.GetAll(database);
        }

        public List<Spot> SearchAllSpots(SpotType spottype)
        {
            return Spot.SearchAll(spottype, database);
        }

        public bool AddBasicUser(string RFID, string reservee, string name, string emailaddress, string username, string password, bool administrator, bool loggedIn, int useriD, int spotnumber)
        {
            User user = new User(RFID, reservee, name, emailaddress, username, password, administrator, loggedIn, useriD, spotnumber);
            try
            {
                user.AddBasicUser(user,database);
                return true;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}