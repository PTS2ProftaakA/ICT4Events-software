using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class Spot : IDatabase<Spot>
    {
        //Fields
        private int spotNumber;
        private int price;

        private SpotType spotSpotType;

        //Properties
        #region properties
        public int SpotNumber
        {
            get { return spotNumber; }
            set { spotNumber = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public SpotType SpotSpotType
        {
            get { return spotSpotType; }
            set { spotSpotType = value; }
        }
        #endregion

        //Constructor to make a spot
        public Spot(int spotNumber, int price, SpotType spotSpotType)
        {
            this.spotNumber = spotNumber;
            this.price = price;
            this.spotSpotType = spotSpotType;
        }

        //A function that returns all the spots
        public static List<Spot> getAll(Database database)
        {
            List<string> spotColumns = new List<string>();
            List<Spot> allSpot = new List<Spot>();

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  PLAATS", spotColumns);

            if (dataTable[0].Count() >= 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    SpotType thisSpotType = null;

                    foreach (SpotType spotType in SpotType.GetAll(database))
                    {
                        if (spotType.SpotTypeID == Convert.ToInt32(dataTable[1][i]))
                        {
                            thisSpotType = spotType;
                        }
                    }

                    allSpot.Add(new Spot(
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        thisSpotType));
                }
            }

            return allSpot;
        }

        //A function that returns all the available spots
        public static List<Spot> getAllAvailable(Database database)
        {
            List<string> spotColumns = new List<string>();
            List<Spot> allSpot = new List<Spot>();

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM PLAATS WHERE PLAATSNUMMER NOT IN (SELECT P.PLAATSNUMMER FROM GEBRUIKER AD, GEBRUIKER G, RESERVERING R, PLAATS P WHERE P.PLAATSNUMMER = R.PLAATSNUMMER AND R.GEBRUIKERID = AD.GEBRUIKERID AND G.RESERVEERDER = AD.GEBRUIKERID);", spotColumns);

            if (dataTable[0].Count() >= 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    SpotType thisSpotType = null;

                    foreach (SpotType spotType in SpotType.GetAll(database))
                    {
                        if (spotType.SpotTypeID == Convert.ToInt32(dataTable[1][i]))
                        {
                            thisSpotType = spotType;
                        }
                    }

                    allSpot.Add(new Spot(
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        thisSpotType));
                }
            }

            return allSpot;
        }

        //A function that finds all the spots of a single type like 'bungalow'
        public static List<Spot> SearchAll(SpotType spotype, Database database)
        {
            List<string> spotColumns = new List<string>();
            List<Spot> allSpot = new List<Spot>();

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");
            List<string>[] dataTable = null;
            if (spotype != null)
            {
                dataTable = database.selectQuery("SELECT * FROM  PLAATS WHERE PLAATSTYPEID = " + spotype.SpotTypeID, spotColumns);    
            }
            else
            {
                dataTable = database.selectQuery("SELECT * FROM  PLAATS ", spotColumns);
            }

            if (dataTable[0].Count() >= 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    SpotType thisSpotType = null;

                    foreach (SpotType spotType in SpotType.GetAll(database))
                    {
                        if (spotType.SpotTypeID == Convert.ToInt32(dataTable[1][i]))
                        {
                            thisSpotType = spotType;
                        }
                    }

                    allSpot.Add(new Spot(
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        thisSpotType));
                }
            }
            return allSpot;
        }

        //Do the same, but only with the available spots
        public static List<Spot> SearchAllAvailable(SpotType spotype, Database database)
        {
            List<string> spotColumns = new List<string>();
            List<Spot> allSpot = new List<Spot>();

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");
            List<string>[] dataTable = null;
            if (spotype != null)
            {
                dataTable = database.selectQuery("SELECT * FROM PLAATS WHERE PLAATSNUMMER NOT IN (SELECT P.PLAATSNUMMER FROM GEBRUIKER AD, GEBRUIKER G, RESERVERING R, PLAATS P WHERE P.PLAATSNUMMER = R.PLAATSNUMMER AND R.GEBRUIKERID = AD.GEBRUIKERID AND G.RESERVEERDER = AD.GEBRUIKERID) AND PLAATSTYPEID = " + spotype.SpotTypeID + " ORDER BY PLAATSNUMMER", spotColumns);
            }
            else
            {
                dataTable = database.selectQuery("SELECT * FROM  PLAATS ", spotColumns);
            }

            if (dataTable[0].Count() >= 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    SpotType thisSpotType = null;

                    foreach (SpotType spotType in SpotType.GetAll(database))
                    {
                        if (spotType.SpotTypeID == Convert.ToInt32(dataTable[1][i]))
                        {
                            thisSpotType = spotType;
                        }
                    }

                    allSpot.Add(new Spot(
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        thisSpotType));
                }
            } 
            return allSpot;
        }
        //Returns a specific spot that corresponds to the ID of the spot
        public Spot Get(string spotNumber, Database database)
        {
            List<string> spotColumns = new List<string>();
            Spot getSpot = null;

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM PLAATS WHERE PLAATSNUMMER = " + spotNumber, spotColumns);

            if (dataTable[0].Count() >= 1)
            {
                SpotType thisSpotType = null;

                foreach (SpotType spotType in SpotType.GetAll(database))
                {
                    if (spotType.SpotTypeID == Convert.ToInt32(dataTable[1][1]))
                    {
                        thisSpotType = spotType;
                    }
                }

                getSpot = new Spot(
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    thisSpotType);
            }

            return getSpot;
        }

        //Returns a specific spot that corresponds to the ID of the spot
        //Because this function is static it can be more easily used
        public Spot GetStatic(string spotNumber, Database database)
        {
            List<string> spotColumns = new List<string>();
            Spot getSpot = null;

            spotColumns.Add("PLAATSNUMMER");
            spotColumns.Add("PLAATSTYPEID");
            spotColumns.Add("PRIJS");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM PLAATS WHERE PLAATSNUMMER = " + spotNumber, spotColumns);

            if (dataTable[0].Count() >= 1)
            {
                SpotType thisSpotType = null;

                foreach (SpotType spotType in SpotType.GetAll(database))
                {
                    if (spotType.SpotTypeID == Convert.ToInt32(dataTable[1][1]))
                    {
                        thisSpotType = spotType;
                    }
                }

                getSpot = new Spot(
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    thisSpotType);
            }

            return getSpot;
        }

        //Adds a spot to the database
        public void Add(Spot newSpot, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO PLAATS VALUES ({0}, {1}, {2})",
                newSpot.spotNumber, newSpot.spotSpotType.SpotTypeID, newSpot.price));
        }

        //Edits the value of a spot in the database to it's current values
        public void Edit(Spot updateSpot, Database database)
        {
            database.editDatabase(String.Format("UPDATE PLAATS SET PRIJS = {0} WHERE PLAATSNUMMER = {1}",
                updateSpot.price, updateSpot.spotNumber));

        }

        //Removes a spot that corresponds with the input
        public void Remove(Spot removeSpot, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM PLAATS WHERE PLAATSNUMMER = {0}",
                removeSpot.spotNumber));
        }

        public override string ToString()
        {
            return spotSpotType.SpotTypeName + " - " + spotSpotType.AmountOfPersons;
        }
    }
}
