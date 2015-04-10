using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    enum SpotType
    {
        Blokhut,
        StaCaravan,
        etc
    }

    class SpotRental : Reservation
    {
        private int spotNumber;
        private int amountOfPersons;

        private SpotType spotTypes;

        public SpotRental(string RFID, int rentalID, DateTime startDate, DateTime endDate, bool isPayed, RentalType type,
                          int spotNumber, int amountOfPersons, SpotType spotTypes)
            :base(RFID, rentalID, startDate, endDate, isPayed, type)
        {
            this.spotNumber = spotNumber;
            this.amountOfPersons = amountOfPersons;
            this.spotTypes = spotTypes;
        }

        public int SpotNumber
        {
            get { return spotNumber; }
            set { spotNumber = value; }
        }
        public int AmountOfPersons
        {
            get { return amountOfPersons; }
            set { amountOfPersons = value; }
        }
        private SpotType SpotTypes
        {
            get { return spotTypes; }
            set { spotTypes = value; }
        }

        //public override void getAll()
        //{
        //    //Get all spot rentals from the database
        //}
    }
}
