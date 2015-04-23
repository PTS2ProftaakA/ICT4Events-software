using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    public class Reservation : IDatabase<Reservation>
    {
        //Fields
        private int userID;
        private int rentalID;
        private int materialID;
        private int spotNumber;

        private DateTime startDate;
        private DateTime endDate;

        private bool isPayed;

        private Spot spot;
        private Material material;

        private User user;

        //Properies
        #region properties
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
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
        public int SpotNumber
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
        public Spot ReservationSpot
        {
            get { return spot; }
            set { spot = value; }
        }
        public Material Material
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

        //Empty constructor for easy acces to the functions
        //This is an easy fix for a more complex, not tackled problem
        public Reservation()
        {

        }

        //The constructor for a spotreservation, a user is needed to complete it
        public Reservation(int userID, int rentalID, int materialID, DateTime startDate, DateTime endDate, bool isPayed, Spot spot)
        {
            this.userID = userID;
            this.rentalID = rentalID;
            this.materialID = materialID;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isPayed = isPayed;
            this.spot = spot;
            this.material = null;
        }

        //The constructor for a materialreservation, a user is needed to complete it
        public Reservation(int userID, int rentalID, int spotNumber, DateTime startDate, DateTime endDate, bool isPayed, Material material)
        {
            this.userID = userID;
            this.rentalID = rentalID;
            this.spotNumber = spotNumber;
            this.startDate = startDate;
            this.endDate = endDate;
            this.isPayed = isPayed;
            this.material = material;
            this.spot = null;
        }

        //Returns a list of all reservations
        //Depending on what type it is, a different constructor is used
        public List<Reservation> GetAll(Database database)
        {
            List<string> reservationColumns = new List<string>();
            List<Reservation> allreservations = new List<Reservation>();

            reservationColumns.Add("HUURID");
            reservationColumns.Add("GEBRUIKERID");
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
                        Convert.ToInt32(dataTable[1][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[6][i]),
                        Convert.ToDateTime(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[3][i]),
                        dataTable[5][i].ToUpper() == "Y",
                        Material.Get(dataTable[6][i], database)));
                    }
                    else
                    {
                        allreservations.Add(new Reservation(
                        Convert.ToInt32(dataTable[1][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToInt32(dataTable[7][i]),
                        Convert.ToDateTime(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[3][i]),
                        dataTable[5][i].ToUpper() == "Y",
                        Spot.GetStatic(dataTable[7][i], database)));
                    }
                }
            }

            return allreservations;
        }

        //Returns a list of all reservations of one user
        //Depending on what type it is, a different constructor is used
        public List<Reservation> GetAllFromUser(int userID, Database database)
        {
            List<string> reservationColumns = new List<string>();
            List<Reservation> allreservations = new List<Reservation>();

            reservationColumns.Add("HUURID");
            reservationColumns.Add("GEBRUIKERID");
            reservationColumns.Add("STARTDATUM");
            reservationColumns.Add("EINDDATUM");
            reservationColumns.Add("HUURTYPE");
            reservationColumns.Add("BETAALD");
            reservationColumns.Add("MATID");
            reservationColumns.Add("PLAATSNUMMER");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM RESERVERING WHERE  GEBRUIKERID = " + userID + " AND HUURTYPE = 'MATERIAAL'", reservationColumns);

            if (dataTable[0].Count() > 1)
            {
                for (int i = 1; i < dataTable[0].Count(); i++)
                {
                    if (dataTable[4][i] == "MATERIAAL")
                    {
                        allreservations.Add(new Reservation(
                        Convert.ToInt32(dataTable[1][i]),
                        Convert.ToInt32(dataTable[0][i]),
                        -1,
                        Convert.ToDateTime(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[3][i]),
                        dataTable[5][i].ToUpper() == "Y",
                        Material.GetStatic(dataTable[6][i], database)));
                    }
                }
            }

            return allreservations;
        }


        public Reservation GetSpotReservation(int userID, Database database)
        {
            List<string> reservationColumns = new List<string>();
            Reservation getReservation = null;

            reservationColumns.Add("HUURID");
            reservationColumns.Add("GEBRUIKERID");
            reservationColumns.Add("STARTDATUM");
            reservationColumns.Add("EINDDATUM");
            reservationColumns.Add("HUURTYPE");
            reservationColumns.Add("BETAALD");
            reservationColumns.Add("MATID");
            reservationColumns.Add("PLAATSNUMMER");

            List<string>[] dataTable = database.selectQuery("SELECT * FROM RESERVERING WHERE HUURTYPE = 'PLAATS' AND GEBRUIKERID = " + userID, reservationColumns);

            if (dataTable[0].Count() > 1)
            {
                getReservation = new Reservation(
                    Convert.ToInt32(dataTable[1][1]),
                    Convert.ToInt32(dataTable[0][1]),
                    Convert.ToInt32(dataTable[7][1]),
                    Convert.ToDateTime(dataTable[2][1]),
                    Convert.ToDateTime(dataTable[3][1]),
                    dataTable[5][1].ToUpper() == "Y",
                    Spot.GetStatic(dataTable[7][1], database));
            }

            return getReservation;
        }

        //A function that returns a specific reservation
        public Reservation Get(string rentalID, Database database)
        {
            List<string> reservationColumns = new List<string>();
            Reservation getReservation = null;

            reservationColumns.Add("HUURID");
            reservationColumns.Add("GEBRUIKERID");
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
                        Convert.ToInt32(dataTable[1][1]),
                        Convert.ToInt32(dataTable[0][1]),
                        Convert.ToInt32(dataTable[6][1]),
                        Convert.ToDateTime(dataTable[2][1]),
                        Convert.ToDateTime(dataTable[3][1]),
                        dataTable[5][1].ToUpper() == "Y",
                        Material.Get(dataTable[6][1], database));
                }
                else
                {
                    getReservation = new Reservation(
                        Convert.ToInt32(dataTable[1][1]),
                        Convert.ToInt32(dataTable[0][1]),
                        Convert.ToInt32(dataTable[7][1]),
                        Convert.ToDateTime(dataTable[2][1]),
                        Convert.ToDateTime(dataTable[3][1]),
                        dataTable[5][1].ToUpper() == "Y",
                        Spot.GetStatic(dataTable[7][1], database));
                }
            }

            return getReservation;
        }

        //Adds a reservation to the database
        //The bool is converted to a string that indicates a YES('Y') or NO('N')
        public void Add(Reservation newReservation, Database database)
        {
            if (newReservation.Material == null)
            {
                database.editDatabase(String.Format("INSERT INTO RESERVERING VALUES ({0}, {1}, TO_DATE('{2}', 'DD/MM/YYYY HH24:MI:SS'), TO_DATE('{3}', 'DD/MM/YYYY HH24:MI:SS'), '{4}', '{5}', null, {6})",
                    newReservation.rentalID, newReservation.userID, newReservation.startDate, newReservation.endDate, "PLAATS", newReservation.isPayed ? "Y" : "N", newReservation.spot.SpotNumber));
            }
            else
            {
                database.editDatabase(String.Format("INSERT INTO RESERVERING VALUES ({0}, {1}, TO_DATE('{2}', 'DD/MM/YYYY HH24:MI:SS'), TO_DATE('{3}', 'DD/MM/YYYY HH24:MI:SS'), '{4}', '{5}', {6}, null)",
                    newReservation.rentalID, newReservation.userID, newReservation.startDate, newReservation.endDate, "MATERIAAL", newReservation.isPayed ? "Y" : "N", newReservation.material.MaterialID));
            }
        }

        //Edits a reservation with the current value of the reservation
        //The bool is converted to a string that indicates a YES('Y') or NO('N')
        public void Edit(Reservation updateReservation, Database database)
        {
            database.editDatabase(String.Format("UPDATE RESERVERING SET STARTDATUM = TO_DATE('{0}', 'DD/MM/YYYY HH24:MI:SS'), EINDDATUM = TO_DATE('{1}', 'DD/MM/YYYY HH24:MI:SS'), BETAALD = '{2}' WHERE PLAATSNUMMER = {1}",
                updateReservation.startDate, updateReservation.endDate, updateReservation.isPayed ? "Y" : "N"));

        }

        //Removes a reservation corresponding to the input
        public void Remove(Reservation removeReservation, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM RESERVERING WHERE HUURID = {0}",
                removeReservation.rentalID));
        }

        //Returns a string that is more readable for the user
        //Depending on what tyoe it is, it will return different strings
        public override string ToString()
        {
            if(material != null)
            {
                return material.ToString() + "\t" + startDate.ToString("d") + "\t" + endDate.ToString("d");
            }
            else
            {
                return spot.ToString() + "\t" + startDate.ToString("d") + "\t" + endDate.ToString("d");
            }
        }
    }
}
