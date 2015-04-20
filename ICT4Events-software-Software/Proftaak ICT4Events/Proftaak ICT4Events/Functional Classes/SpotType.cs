using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class SpotType : IDatabase<SpotType>
    {
        private string spotTypeName;

        private int spotTypeID;
        private int amountOfPersons;

        private Database database;

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

        public SpotType(string spotTypeName, int spotTypeID, int amountOfPersons)
        {
            this.spotTypeName = spotTypeName;
            this.spotTypeID = spotTypeID;
            this.amountOfPersons = amountOfPersons;

            database = new Database();
        }

        public List<SpotType> GetAll()
        {
            List<string> spotTypeColumns = new List<string>();
            List<SpotType> allSpotTypes = new List<SpotType>();

            spotTypeColumns.Add("PLAATSTYPEID");
            spotTypeColumns.Add("PLAATSTYPE");
            spotTypeColumns.Add("HOEVEELHEIDPERSONEN");

            List<string>[] dataTable = database.selectQuery("SELECT plaatstype FROM PLAATSTYPE", spotTypeColumns);

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

        public void Add(SpotType newSpotType, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO PLAATSTYPE VALUES ({0}, '{1}', {2})",
                newSpotType.SpotTypeID, newSpotType.spotTypeName, newSpotType.amountOfPersons));
        }

        public void Edit(SpotType updateSpotType, Database database)
        {
            database.editDatabase(String.Format("UPDATE PLAATSTYPE SET PLAATSTYPE = '{0}' , HOEVEELHEIDPERSONEN = {1} WHERE PLAATSTYPEID = {2}",
                updateSpotType.spotTypeName, updateSpotType.amountOfPersons, updateSpotType.SpotTypeID));

        }

        public void Remove(SpotType removeSpotType, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM PLAATSTYPE WHERE PLAATSTYPEID = {0}",
                removeSpotType.SpotTypeID));
        }
    }
}
