using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class SpotType : IDatabase<SpotType>
    {
        //Fields
        private string spotTypeName;

        private int spotTypeID;
        private int amountOfPersons;

        private Database database;

        //Properties
        #region properties
        public string SpotTypeName
        {
            get { return spotTypeName; }
            set { spotTypeName = value; }
        }
        public int SpotTypeID
        {
            get { return spotTypeID; }
            set { spotTypeID = value; }
        }
        public int AmountOfPersons
        {
            get { return amountOfPersons; }
            set { amountOfPersons = value; }
        }
        #endregion

        //Constructor that creates a spottype, this is used by spot
        public SpotType(string spotTypeName, int spotTypeID, int amountOfPersons)
        {
            this.spotTypeName = spotTypeName;
            this.spotTypeID = spotTypeID;
            this.amountOfPersons = amountOfPersons;

            database = new Database();
        }

        //Returns all spottypes form the database
        //They are constructed as they are pulled from the database
        public static List<SpotType> GetAll(Database database)
        {
            List<string> spotTypeColumns = new List<string>();
            List<SpotType> allSpotTypes = new List<SpotType>();

            spotTypeColumns.Add("PLAATSTYPEID");
            spotTypeColumns.Add("PLAATSTYPE");
            spotTypeColumns.Add("HOEVEELHEIDPERSONEN");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM PLAATSTYPE", spotTypeColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allSpotTypes.Add(new SpotType(
                        dataTable[1][i],
                        Convert.ToInt16(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i])));
                }
            }

            return allSpotTypes;
        }

        //Returns spottype corresponding to the spottype ID
        public SpotType Get(string spotTypeID, Database database)
        {
            List<string> spotTypeColumns = new List<string>();
            SpotType getSpotType = null;

            spotTypeColumns.Add("PLAATSTYPEID");
            spotTypeColumns.Add("PLAATSTYPE");
            spotTypeColumns.Add("HOEVEELHEIDPERSONEN");

            List<string>[] dataTable = database.selectQuery("SELECT PLAATSTYPE FROM PLAATSTYPE WHERE PLAATSTYPEID = " + spotTypeID, spotTypeColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    getSpotType = new SpotType(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]));
                }
            }

            return getSpotType;
        }

        //Adds a spottype to the database
        public void Add(SpotType newSpotType, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO PLAATSTYPE VALUES ({0}, '{1}', {2})",
                newSpotType.SpotTypeID, newSpotType.spotTypeName, newSpotType.amountOfPersons));
        }

        //Edits a spottype to it's current values
        public void Edit(SpotType updateSpotType, Database database)
        {
            database.editDatabase(String.Format("UPDATE PLAATSTYPE SET PLAATSTYPE = '{0}' , HOEVEELHEIDPERSONEN = {1} WHERE PLAATSTYPEID = {2}",
                updateSpotType.spotTypeName, updateSpotType.amountOfPersons, updateSpotType.SpotTypeID));

        }

        //Spottype is removes from the database according to the spottype ID
        public void Remove(SpotType removeSpotType, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM PLAATSTYPE WHERE PLAATSTYPEID = {0}",
                removeSpotType.SpotTypeID));
        }

        //Makes a more readable for the user
        public override string ToString()
        {
            return spotTypeName;
        }
    }
}
