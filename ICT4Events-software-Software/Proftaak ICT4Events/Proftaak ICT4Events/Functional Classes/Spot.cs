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

        public static List<Spot> getAll(Database database)
        {
            List<string> spotColumns = new List<string>();
            List<Spot> allSpot = new List<Spot>();

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  RATING", spotColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allSpot.Add(new Spot(
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[1][i]),
                        Convert.ToInt32(dataTable[2][i])
                        ));
                }
            }

            return allSpot;
        }

        public Spot Get(string spotNumber, Database database)
        {
            List<string> spotColumns = new List<string>();
            Spot getSpot = null;

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM PLAATS WHERE PLAATSNUMMER = " + spotNumber, spotColumns);

            if (dataTable[0].Count() > 1)
            {
                getSpot = new Spot(
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[1][1]),
                    Convert.ToInt32(dataTable[2][1]));
            }

            return getSpot;
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
