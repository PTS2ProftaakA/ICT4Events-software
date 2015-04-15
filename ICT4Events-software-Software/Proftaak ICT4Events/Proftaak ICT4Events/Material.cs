using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class Material : IDatabase
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

        public new static List<Material> getAll(Database database)
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

            //Has to be fixed with current database

            dataTable = database.selectQuery("SELECT * FROM  MATERIAAL m", materialColumns);

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

        public new static List<Material> getAll(Database database, CategoryType category)
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

            //Has to be fixed with current database

            dataTable = database.selectQuery("SELECT * FROM  MATERIAAL m WHERE CATEGORIE = " + (int)category, materialColumns);

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

        public T Get<T>(string materialID, Database database)
        {
            return (T)Convert.ChangeType(null, typeof(T));
        }

        public void Add<T>(T material, Database database)
        {

        }

        public void Edit<T>(T material, Database database)
        {

        }

        public void Remove<T>(T material, Database database)
        {

        }
    }
}
