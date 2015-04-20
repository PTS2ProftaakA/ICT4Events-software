using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class ProductTypeManager
    {
        Database database;

        public ProductTypeManager(Database database)
        {
            this.database = database;
        }

        public List<string> getMediaTypes(Database database)
        {
            List<string> mediaTypeColumn = new List<string>();
            List<string> allMediaTypes = new List<string>();

            mediaTypeColumn.Add("TYPE");

            List<string> dataTable = database.selectQuery("SELECT TYPE FROM MEDIATYPE", mediaTypeColumn)[0];

            for(int i = 1; i < dataTable.Count(); i++)
            {
                allMediaTypes.Add(dataTable[i]);
            }

            return allMediaTypes;
        }

        public List<string> getSpotTypes(Database database)
        {
            List<string> spotTypeColumn = new List<string>();
            List<string> allSpotTypes = new List<string>();

            spotTypeColumn.Add("PLAATSTYPE");

            List<string> dataTable = database.selectQuery("SELECT PLAATSTYPE FROM PLAATSTYPE", spotTypeColumn)[0];

            for (int i = 1; i < dataTable.Count(); i++)
            {
                allSpotTypes.Add(dataTable[i]);
            }

            return allSpotTypes;
        }

        public List<string> getMaterialTypes(Database database)
        {
            List<string> materialTypeColumn = new List<string>();
            List<string> allMaterialTypes = new List<string>();

            materialTypeColumn.Add("CATNAAM");

            List<string> dataTable = database.selectQuery("SELECT CATNAAM FROM MATERIAAL_CATEGORIE", materialTypeColumn)[0];

            for (int i = 1; i < dataTable.Count(); i++)
            {
                allMaterialTypes.Add(dataTable[i]);
            }

            return allMaterialTypes;
        }
    }
}
