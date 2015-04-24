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

        //Uses the getAll function in Spot to return all spots in the database
        public List<Spot> GetAllspots()
        {
            return Spot.getAll(database);
        }

        //Do the same, but only with the available spots
        public List<Spot> GetAllAvailableSpots()
        {
            return Spot.getAllAvailable(database);
        }

        //A function used in SpotType to return all spot types
        //An example of such a value is "bungalow"
        public List<SpotType> GetAllSpotTypes()
        {
            return SpotType.GetAll(database);
        }

        //Uses a function in spot to find all spots of a certain type
        public List<Spot> SearchAllSpots(SpotType spottype)
        {
            return Spot.SearchAll(spottype, database);
        }

        //Do the same, but only with the available spots
        public List<Spot> SearchAllAvailableSpots(SpotType spottype)
        {
            return Spot.SearchAllAvailable(spottype, database);
        }

        //Uses a function in User to create a basic user
        //Gives an exception when this fails
        public void AddUser(User user)
        {
            user.Add(user,database);
        }
    }
}