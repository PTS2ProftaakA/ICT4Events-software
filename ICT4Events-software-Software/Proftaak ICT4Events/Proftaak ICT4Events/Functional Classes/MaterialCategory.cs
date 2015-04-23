using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class MaterialCategory : IDatabase<MaterialCategory>
    {
        //Fields
        private string materialCategoryName;

        private int materialCategoryID;

        Database database;

        //Properties
        #region Properties
        public string MaterialCategoryName
        {
            get { return materialCategoryName; }
            set { materialCategoryName = value; }
        }
        public int MaterialCategoryID
        {
            get { return materialCategoryID; }
            set { materialCategoryID = value; }
        }
        #endregion

        //A constructor that creates different categories for materials
        public MaterialCategory(string materialCategoryName, int materialCategoryID)
        {
            this.materialCategoryName = materialCategoryName;
            this.materialCategoryID = materialCategoryID;

            database = new Database();
        }

        //A function that gets all the categories from the database
        //It constructs them and returns a list
        public static List<MaterialCategory> GetAll(Database database)
        {
            List<string> materialCategoryColumns = new List<string>();
            List<MaterialCategory> allMaterialCategories = new List<MaterialCategory>();

            materialCategoryColumns.Add("MATCATID");
            materialCategoryColumns.Add("CATNAAM");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM MATERIAAL_CATEGORIE", materialCategoryColumns);

            if (dataTable[0].Count() >= 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    allMaterialCategories.Add(new MaterialCategory(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i])));
                }
            }

            return allMaterialCategories;
        }

        //A function that gets a single category from the database
        public MaterialCategory Get(string materialCategoryID, Database database)
        {
            List<string> materialCategoryColumns = new List<string>();
            MaterialCategory getMaterialCategory = null;

            materialCategoryColumns.Add("MATCATID");
            materialCategoryColumns.Add("CATNAAM");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM MATERIAAL_CATEGORIE WHERE MATCATID = " + materialCategoryID, materialCategoryColumns);

            if (dataTable[0].Count() >= 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    getMaterialCategory = new MaterialCategory(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i]));
                }
            }

            return getMaterialCategory;
        }

        //Adds a single category to the database
        public void Add(MaterialCategory newMaterialCategory, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO MATERIAAL_CATEGORIE VALUES ({0}, '{1}')",
                newMaterialCategory.MaterialCategoryID, newMaterialCategory.materialCategoryName));
        }

        //Edits a single category with the current value of the category
        public void Edit(MaterialCategory updateMaterialCategory, Database database)
        {
            database.editDatabase(String.Format("UPDATE MATERIAAL_CATEGORIE SET CATNAAM = '{0}' WHERE MATCATID = {1}",
                updateMaterialCategory.materialCategoryName, updateMaterialCategory.materialCategoryID));
        }

        //Removes a category that corresponds with the input category
        public void Remove(MaterialCategory removeMaterialCategory, Database database)
        {
           database.editDatabase(String.Format("DELETE FROM MATERIAAL_CATEGORIE WHERE MATCATID = {0} ",
               removeMaterialCategory.materialCategoryID));
        }

        public override string ToString()
        {
            return materialCategoryName;
        }
    }
}
