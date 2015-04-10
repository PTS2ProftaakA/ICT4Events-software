﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    enum RentalType
    {
        Equipment,
        SpotRental
    }

    abstract class Reservation
    {
        protected string RFID;

        protected int rentalID;

        protected DateTime startDate;
        protected DateTime endDate;

        protected bool isPayed;

        protected RentalType type;

        public Reservation(string RFID, int rentalID, DateTime startDate, DateTime endDate, bool isPayed, RentalType type)
        {
            this.RFID = RFID;
            this.rentalID = rentalID;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isPayed = isPayed;
            this.type = type;
        }

        public string PropertyRFID
        {
            get { return RFID; }
            set { RFID = value; }
        }
        public int RentalID
        {
            get { return rentalID; }
            set { rentalID = value; }
        }
        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        public bool IsPayed
        {
            get { return isPayed; }
            set { isPayed = value; }
        }
        internal RentalType Type
        {
            get { return type; }
            set { type = value; }
        }

        //public override void getAll()
        //{
        //    //Get all reservations from the database
        //}
    }
}
