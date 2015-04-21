using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class Material : IDatabase<Material>
    {
        //Fields
        private string name;
        private string description;
        private string photoPath;

        private int materialID;
        private int amount;

        private decimal deposit;

        private MaterialCategory materialCategoryName;

        //Properties
        #region properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string PhotoPath
        {
            get { return photoPath; }
            set { photoPath = value; }
        }
        public int Amount
        {
            get { return amount; }
            set { amount = value; }
        }
        public int MaterialID
        {
            get { return materialID; }
            set { materialID = value; }
        }
        public decimal Deposit
        {
            get { return deposit; }
            set { deposit = value; }
        }
        public MaterialCategory MaterialCategoryName
        {
            get { return materialCategoryName; }
            set { materialCategoryName = value; }
        }
        #endregion

        //Constructer to make a material, it contains a category that is defined in another class
        public Material(string name, string description, string photoPath, int materialID, int amount, decimal deposit, MaterialCategory materialCategoryName)
        {
            this.name = name;
            this.description = description;
            this.photoPath = photoPath;
            this.materialID = materialID;
            this.amount = amount;
            this.deposit = deposit;
            this.materialCategoryName = materialCategoryName;
        }

        //A function that returns a list of all materials
        //It uses the data from the database to construct multiple materials
        public static List<Material> getAll(Database database)
        {
            List<string> materialColumns = new List<string>();
            List<Material> allMaterial = new List<Material>();
            List<string>[] dataTable;

            materialColumns.Add("MATID");
            materialColumns.Add("NAAM");
            materialColumns.Add("HOEVEELHEID");
            materialColumns.Add("BORG");
            materialColumns.Add("OMSCHRIJVING");
            materialColumns.Add("CATEGORIE");
            materialColumns.Add("FOTOPAD");

            dataTable = database.selectQuery("SELECT * FROM  MATERIAAL", materialColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    MaterialCategory thisMaterialCategory = null;

                    foreach (MaterialCategory materialCategory in MaterialCategory.GetAll(database))
                    {
                        if (materialCategory.MaterialCategoryID == Convert.ToInt32(dataTable[5][i]))
                        {
                            thisMaterialCategory = materialCategory;
                        }
                    }

                    allMaterial.Add(new Material(
                        dataTable[1][i],
                        dataTable[4][i],
                        dataTable[6][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToDecimal(dataTable[3][i]) / 100,
                        thisMaterialCategory));
                }
            }

            return allMaterial;
        }

        //A function that returns a list of all materials where the category matches the input
        //It uses the data from the database to construct multiple materials
        public static List<Material> getAll(MaterialCategory category, Database database)
        {
            List<string> materialColumns = new List<string>();
            List<Material> allMaterial = new List<Material>();

            materialColumns.Add("MATID");
            materialColumns.Add("NAAM");
            materialColumns.Add("HOEVEELHEID");
            materialColumns.Add("BORG");
            materialColumns.Add("OMSCHRIJVING");
            materialColumns.Add("CATEGORIE");
            materialColumns.Add("FOTOPAD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MATERIAAL WHERE CATEGORIE = " + category.MaterialCategoryID, materialColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    MaterialCategory thisMaterialCategory = null;

                    foreach (MaterialCategory materialCategory in MaterialCategory.GetAll(database))
                    {
                        if (materialCategory.MaterialCategoryID == Convert.ToInt32(dataTable[5][i]))
                        {
                            thisMaterialCategory = materialCategory;
                        }
                    }

                    allMaterial.Add(new Material(
                        dataTable[1][i],
                        dataTable[4][i],
                        dataTable[6][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToDecimal(dataTable[3][i]) / 100,
                        thisMaterialCategory));
                }
            }

            return allMaterial;
        }

        //Returns a material that matches the materialID
        public Material Get(string materialID, Database database)
        {
            List<string> materialColumns = new List<string>();
            Material getMaterial = null;

            materialColumns.Add("MATID");
            materialColumns.Add("NAAM");
            materialColumns.Add("HOEVEELHEID");
            materialColumns.Add("BORG");
            materialColumns.Add("OMSCHRIJVING");
            materialColumns.Add("CATEGORIE");
            materialColumns.Add("FOTOPAD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MATERIAAL WHERE MATID = " + materialID, materialColumns);

            if (dataTable[0].Count() > 1)
            {
                MaterialCategory thisMaterialCategory = null;

                foreach (MaterialCategory materialCategory in MaterialCategory.GetAll(database))
                {
                    if (materialCategory.MaterialCategoryID == Convert.ToInt32(dataTable[5][1]))
                    {
                        thisMaterialCategory = materialCategory;
                    }
                }
                getMaterial = new Material(
                    dataTable[1][1],
                    dataTable[4][1],
                    dataTable[6][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToDecimal(dataTable[3][1]) / 100,
                    thisMaterialCategory);
            }

            return getMaterial;
        }

        //Returns a material that matches the materialID which is more accesible
        public static Material GetStatic(string materialID, Database database)
        {
            List<string> materialColumns = new List<string>();
            Material getMaterial = null;

            materialColumns.Add("MATID");
            materialColumns.Add("NAAM");
            materialColumns.Add("HOEVEELHEID");
            materialColumns.Add("BORG");
            materialColumns.Add("OMSCHRIJVING");
            materialColumns.Add("CATEGORIE");
            materialColumns.Add("FOTOPAD");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MATERIAAL WHERE MATID = " + materialID, materialColumns);

            if (dataTable[0].Count() > 1)
            {
                MaterialCategory thisMaterialCategory = null;

                foreach (MaterialCategory materialCategory in MaterialCategory.GetAll(database))
                {
                    if (materialCategory.MaterialCategoryID == Convert.ToInt32(dataTable[5][1]))
                    {
                        thisMaterialCategory = materialCategory;
                    }
                }
                getMaterial = new Material(
                    dataTable[1][1],
                    dataTable[4][1],
                    dataTable[6][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToDecimal(dataTable[3][1]) / 100,
                    thisMaterialCategory);
            }

            return getMaterial;
        }

        //Adds a single material to the database
        public void Add(Material newMaterial, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO MATERIAAL VALUES ({0}, '{1}', {2}, {3}, '{4}', {5}, '{6}')",
                newMaterial.materialID, newMaterial.name, newMaterial.amount, newMaterial.deposit * 100, newMaterial.description, newMaterial.materialCategoryName.MaterialCategoryID, newMaterial.photoPath));
        }

        //Edits a material in the database to its current values
        public void Edit(Material updateMaterial, Database database)
        {
            database.editDatabase(String.Format("UPDATE MATERIAAL SET NAAM = '{0}',  HOEVEELHEID = {1}, BORG = {2}, OMSCHRIJVING = '{3}', CATEGORIE = {4}, FOTOPAD = '{5}' WHERE MATID = {6}",
                updateMaterial.name, updateMaterial.amount, updateMaterial.deposit * 100, updateMaterial.description, updateMaterial.materialCategoryName.MaterialCategoryID, updateMaterial.photoPath, updateMaterial.materialID));

        }

        //Removes a material from the database with a specific materialID
        public void Remove(Material removeMaterial, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM MATERIAAL WHERE MATID = '{0}'",
                removeMaterial.materialID));
        }

        //returns a more convenient string that is more readable
        public override string ToString()
        {
            return name;
        }
    }
}
