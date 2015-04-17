using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class Spot : IDatabase
    {
        private int spotNumber;
        private int spotTypeID;
        private int price;

        public int SpotNumber
        {
            get { return spotNumber; }
            set { spotNumber = value; }
        }
        public int SpotTypeID
        {
            get { return spotTypeID; }
            set { spotTypeID = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Spot(int spotNumber, int spotTypeID, int price)
        {
            this.spotTypeID = spotTypeID;
            this.spotNumber = spotNumber;
            this.price = price;
        }

        public T Get<T>(string spotNumber, Database database)
        {
            List<string> spotColumns = new List<string>();

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM PLAATS WHERE PLAATSNUMMER = " + spotNumber, spotColumns);

            if (dataTable[0].Count() > 1)
            {
                return (T)Convert.ChangeType(new Spot(
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[1][1]),
                    Convert.ToInt32(dataTable[2][1])), typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(null, typeof(T));
            }
        }

        public void Add<T>(T spot, Database database)
        {
            Spot newSpot = (Spot)Convert.ChangeType(spot, typeof(Spot));
            database.editDatabase(String.Format("INSERT INTO PLAATS VALUES ({0}, '{1}', {2})",
                newSpot.spotNumber, newSpot.spotTypeID, newSpot.price));
        }

        public void Edit<T>(T spot, Database database)
        {
            Spot updateSpot = (Spot)Convert.ChangeType(spot, typeof(Spot));
            database.editDatabase(String.Format("UPDATE PLAATS SET PRIJS = '{0}' WHERE PLAATSNUMMER = '{1}'",
                updateSpot.price, updateSpot.spotNumber));

        }

        public void Remove<T>(T spot, Database database)
        {
            Spot removeSpot = (Spot)Convert.ChangeType(spot, typeof(Spot));
            database.editDatabase(String.Format("DELETE FROM PLAATS WHERE PLAATSNUMMER = '{0}'",
                removeSpot.spotNumber));
        }
    }
}
