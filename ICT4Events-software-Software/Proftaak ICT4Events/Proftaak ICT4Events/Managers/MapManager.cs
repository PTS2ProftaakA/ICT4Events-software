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
    }
}