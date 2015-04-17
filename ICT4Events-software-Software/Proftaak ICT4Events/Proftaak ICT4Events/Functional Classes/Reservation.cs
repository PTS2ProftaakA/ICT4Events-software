using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    enum RentalType
    {
        PLAATS,
        MATERIAAL
    }

    abstract class Reservation : IDatabase
    {
        protected string RFID;

        protected int rentalID;

        protected DateTime startDate;
        protected DateTime endDate;

        protected bool isPayed;

        protected RentalType type;

        private User user;

        #region properties
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
        public RentalType Type
        {
            get { return type; }
            set { type = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        #endregion

        public Reservation(string RFID, int rentalID, DateTime startDate, DateTime endDate, bool isPayed, RentalType type)
        {
            this.RFID = RFID;
            this.rentalID = rentalID;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isPayed = isPayed;
            this.type = type;
        }

        public List<Reservation> getAll()
        {
            return null;
        }

        public T Get<T>(string reservationID, Database database)
        {
            return (T)Convert.ChangeType(null, typeof(T));
        }

        public void Add<T>(T reservation, Database database)
        {

        }

        public void Edit<T>(T reservation, Database database)
        {

        }

        public void Remove<T>(T reservation, Database database)
        {

        }
    }
}
