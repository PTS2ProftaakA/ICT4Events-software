using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class Reservation : IDatabase<Reservation>
    {
        protected string RFID;

        private int rentalID;
        private int materialID;
        private int spotNumber;

        private DateTime startDate;
        private DateTime endDate;

        private bool isPayed;

        private Spot spot;
        private Material material;

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
        public int MaterialID
        {
            get { return materialID; }
            set { materialID = value; }
        }
        protected int SpotNumber
        {
            get { return spotNumber; }
            set { spotNumber = value; }
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
        protected Spot Spot
        {
            get { return spot; }
            set { spot = value; }
        }
        protected Material Material
        {
            get { return material; }
            set { material = value; }
        }
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        #endregion

        public Reservation(string RFID, int rentalID, int materialID, int spotNumber, DateTime startDate, DateTime endDate, bool isPayed, Spot spot)
        {
            this.RFID = RFID;
            this.rentalID = rentalID;
            this.materialID = materialID;
            this.spotNumber = spotNumber;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isPayed = isPayed;
            this.spot = spot;
        }

        public Reservation(string RFID, int rentalID, int materialID, int spotNumber, DateTime startDate, DateTime endDate, bool isPayed, Material material)
        {
            this.RFID = RFID;
            this.rentalID = rentalID;
            this.materialID = materialID;
            this.spotNumber = spotNumber;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isPayed = isPayed;
            this.material = material;
        }

        public List<Reservation> GetAll(Database database)
        {
            List<string> reservationColumns = new List<string>();
            List<Reservation> allreservations = new List<Reservation>();

            reservationColumns.Add("HUURID");
            reservationColumns.Add("RFID");
            reservationColumns.Add("STARTDATUM");
            reservationColumns.Add("EINDDATUM");
            reservationColumns.Add("HUURTYPE");
            reservationColumns.Add("BETAALD");
            reservationColumns.Add("MATID");
            reservationColumns.Add("PLAATSNUMMER");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM RESERVERING WHERE HUURID = " + rentalID, reservationColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    if (dataTable[4][i] == "MATERIAAL")
                    {
                        allreservations.Add(new Reservation(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[6][i]),
                        Convert.ToInt32(dataTable[7][i]),
                        Convert.ToDateTime(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[3][i]),
                        dataTable[5][i].ToUpper() == "Y",
                        Material.Get(dataTable[6][i], database)));
                    }
                    else
                    {
                        allreservations.Add(new Reservation(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[6][i]),
                        Convert.ToInt32(dataTable[7][i]),
                        Convert.ToDateTime(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[3][i]),
                        dataTable[5][i].ToUpper() == "Y",
                        Spot.Get(dataTable[7][i], database)));
                    }
                }
            }

            return allreservations;
        }

        public Reservation Get(string rentalID, Database database)
        {
            List<string> reservationColumns = new List<string>();
            Reservation getReservation = null;

            reservationColumns.Add("HUURID");
            reservationColumns.Add("RFID");
            reservationColumns.Add("STARTDATUM");
            reservationColumns.Add("EINDDATUM");
            reservationColumns.Add("HUURTYPE");
            reservationColumns.Add("BETAALD");
            reservationColumns.Add("MATID");
            reservationColumns.Add("PLAATSNUMMER");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM RESERVERING WHERE HUURID = " + rentalID, reservationColumns);

            if (dataTable[0].Count() > 1)
            {
                if(dataTable[4][1] == "MATERIAAL")
                {
                    getReservation = new Reservation(
                    dataTable[1][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[6][1]),
                    Convert.ToInt32(dataTable[7][1]),
                    Convert.ToDateTime(dataTable[2][1]),
                    Convert.ToDateTime(dataTable[3][1]),
                    dataTable[5][1].ToUpper() == "Y",
                    Material.Get(dataTable[6][1], database));
                }
                else
                {
                    getReservation = new Reservation(
                    dataTable[1][1],
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[6][1]),
                    Convert.ToInt32(dataTable[7][1]),
                    Convert.ToDateTime(dataTable[2][1]),
                    Convert.ToDateTime(dataTable[3][1]),
                    dataTable[5][1].ToUpper() == "Y",
                    Spot.Get(dataTable[7][1], database));
                }
            }

            return getReservation;
        }

        public void Add(Reservation newSpotReservation, Database database)
        {
            string rentalType;

            if (newSpotReservation.Material == null)
            {
                rentalType = "PLAATS";
            }
            else
            {
                rentalType = "MATERIAAL";
            }
            database.editDatabase(String.Format("INSERT INTO RESERVERING VALUES ({0}, '{1}', TO_DATE('{2}', 'DD-MM-YYYY'), TO_DATE('{3}', 'DD-MM-YYYY'), '{4}', '{5}', {6}, {7})",
                newSpotReservation.rentalID, newSpotReservation.RFID, newSpotReservation.startDate, newSpotReservation.endDate, rentalType, newSpotReservation.isPayed, newSpotReservation.materialID, newSpotReservation.spotNumber));
        }

        public void Edit(Reservation updateReservation, Database database)
        {
            database.editDatabase(String.Format("UPDATE RESERVERING SET STARTDATUM = TO_DATE('{0}', 'DD-MM-YYYY'), EINDDATUM = TO_DATE('{1}', 'DD-MM-YYYY'), BETAALD = '{2}' WHERE PLAATSNUMMER = {1}",
                updateReservation.startDate, updateReservation.endDate, updateReservation.isPayed));

        }

        public void Remove(Reservation removeReservation, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM RESERVERING WHERE HUURID = {0}",
                removeReservation.rentalID));
        }
    }
}
