using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class Spot : IDatabase<Spot>
    {
        private int spotNumber;
        private int spotTypeID;
        private int price;

        #region properties
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
        #endregion

        public Spot(int spotNumber, int spotTypeID, int price)
        {
            this.spotTypeID = spotTypeID;
            this.spotNumber = spotNumber;
            this.price = price;
        }

        public Spot Get(string spotNumber, Database database)
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

        public void Add(Spot newSpot, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO PLAATS VALUES ({0}, {1}, {2})",
                newSpot.spotNumber, newSpot.spotTypeID, newSpot.price));
        }

        public void Edit(Spot updateSpot, Database database)
        {
            database.editDatabase(String.Format("UPDATE PLAATS SET PRIJS = {0} WHERE PLAATSNUMMER = {1}",
                updateSpot.price, updateSpot.spotNumber));

        }

        public void Remove(Spot removeSpot, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM PLAATS WHERE PLAATSNUMMER = {0}",
                removeSpot.spotNumber));
        }
    }
}
