using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class Material : IDatabase<Material>
    {
        private string name;
        private string description;
        private string photoPath;

        private int materialID;
        private int amount;

        private decimal deposit;

        private CategoryType category;

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
        public decimal Deposit
        {
            get { return deposit; }
            set { deposit = value; }
        }
        private CategoryType Category
        {
            get { return category; }
            set { category = value; }
        }
        #endregion
        public Material(string name, string description, string photoPath, int materialID, int amount, decimal deposit, CategoryType category)
        {
            this.name = name;
            this.description = description;
            this.photoPath = photoPath;
            this.materialID = materialID;
            this.amount = amount;
            this.deposit = deposit;
            this.category = category;
        }

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
                    CategoryType categoryValue = (CategoryType)Enum.Parse(typeof(CategoryType), dataTable[11][i]);

                    allMaterial.Add(new Material(
                        dataTable[7][i],
                        dataTable[10][i],
                        dataTable[12][i],
                        Convert.ToInt32(dataTable[6][i]),
                        Convert.ToInt32(dataTable[8][i]),
                        Convert.ToDecimal(dataTable[9][i]) / 100,
                        categoryValue));
                }
            }

            return allMaterial;
        }

        public static List<Material> getAll(Database database, CategoryType category)
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

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MATERIAAL WHERE CATEGORIE = " + (int)category, materialColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    CategoryType categoryValue = (CategoryType)Enum.Parse(typeof(CategoryType), dataTable[5][i]);

                    allMaterial.Add(new Material(
                        dataTable[1][i],
                        dataTable[4][i],
                        dataTable[6][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[2][i]),
                        Convert.ToDecimal(dataTable[3][i]) / 100,
                        categoryValue));
                }
            }

            return allMaterial;
        }

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

            //Has to be fixed with current database

            List<string>[] dataTable = database.selectQuery("SELECT * FROM  MATERIAAL WHERE MATID = " + materialID, materialColumns);

            if (dataTable[0].Count() > 1)
            {
                CategoryType categoryValue = (CategoryType)Enum.Parse(typeof(CategoryType), dataTable[5][1]);

                getMaterial = new Material(
                    dataTable[1][1],
                    dataTable[4][1],
                    dataTable[6][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[2][1]),
                    Convert.ToDecimal(dataTable[3][1]) / 100,
                    categoryValue);
            }

            return getMaterial;
        }

        public void Add(Material newMaterial, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO MATERIAAL VALUES ({0}, '{1}', {2}, {3}, '{4}', {5}, '{6}')",
                newMaterial.materialID, newMaterial.name, newMaterial.amount, newMaterial.deposit, newMaterial.description, newMaterial.category, newMaterial.photoPath));
        }

        public void Edit(Material updateMaterial, Database database)
        {
            database.editDatabase(String.Format("UPDATE PLAATS SET NAAM = '{0}',  HOEVEELHEID = {1}, BORG = {2}, OMSCHRIJVING = '{4}', CATEGORIE = {4}, FOTOPAD = '{5}', WHERE MATID = {6}",
                updateMaterial.name, updateMaterial.amount, updateMaterial.deposit, updateMaterial.description, updateMaterial.category, updateMaterial.photoPath, updateMaterial.materialID));

        }

        public void Remove(Material removeMaterial, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM MATERIAAL WHERE MATID = '{0}'",
                removeMaterial.materialID));
        }
    }
}
