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

        public Equipment[] getAll()
        {
            return null;
        }
    }
}
