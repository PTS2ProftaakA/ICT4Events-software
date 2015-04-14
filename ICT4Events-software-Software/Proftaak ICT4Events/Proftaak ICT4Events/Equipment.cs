using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    enum CategoryType
    {
        Chargers,
        Cameras,
        etc
    }

    class Equipment : Reservation
    {
        private string name;
        private string description;

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

        public Equipment(string RFID, int rentalID, DateTime startDate, DateTime endDate, bool isPayed, RentalType type,
                 string name, string description, int amount, decimal deposit, CategoryType category)
            : base(RFID, rentalID, startDate, endDate, isPayed, type)
        {
            this.name = name;
            this.description = description;
            this.amount = amount;
            this.deposit = deposit;
            this.category = category;
        }

        public new static List<Equipment> getAll(Database database)
        {
            List<string> equipmentColumns = new List<string>();
            List<Equipment> allEquipment = new List<Equipment>();

            equipmentColumns.Add("HUURID");
            equipmentColumns.Add("RFID");
            equipmentColumns.Add("STARTDATUM");
            equipmentColumns.Add("EINDDATUM");
            equipmentColumns.Add("HUURTYPE");
            equipmentColumns.Add("BETAALD");
            equipmentColumns.Add("NAAM");
            equipmentColumns.Add("HOEVEELHEID");
            equipmentColumns.Add("BORG");
            equipmentColumns.Add("OMSCHRIJVING");
     

            List<string>[] dataTable = database.selectQuery("SELECT * FROM RESERVERING", equipmentColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    bool isPayed;
                    if (dataTable[5][i].ToUpper() == "Y")
                    {
                        isPayed = true;
                    }
                    else
                    {
                        isPayed = false;
                    }

                    RentalType rentalValue = (RentalType)Enum.Parse(typeof(RentalType), dataTable[4][i]);
                    CategoryType categoryValue = (CategoryType)Enum.Parse(typeof(CategoryType), dataTable[9][i]);
                    allEquipment.Add(new Equipment(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToDateTime(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[3][i]),
                        isPayed,
                        rentalValue,
                        dataTable[6][i],
                        dataTable[9][i],
                        Convert.ToInt32(dataTable[7][i]),
                        Convert.ToDecimal(dataTable[8][i])/100,
                        categoryValue ));
                }
            }

            return allEquipment;
        }
    }
}
