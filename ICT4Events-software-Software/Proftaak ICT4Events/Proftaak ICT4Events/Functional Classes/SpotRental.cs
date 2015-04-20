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
        private int amountOfPersons;

        private SpotType spotTypes;

        #region properties
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
        #endregion

        public SpotRental(string RFID, int rentalID, int materialID, DateTime startDate, DateTime endDate, bool isPayed, RentalType type,
                  int spotNumber, int amountOfPersons, SpotType spotTypes)
            : base(RFID, rentalID, materialID, spotNumber, startDate, endDate, isPayed, type)
        {
            this.spotNumber = spotNumber;
            this.amountOfPersons = amountOfPersons;
            this.spotTypes = spotTypes;
        }

        public new List<SpotRental> getAll()
        {
            return null;
        }



        public void Add(SpotRental newSpotRental, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO RESERVERING VALUES ({0}, '{1}', TO_DATE('{2}', 'DD-MM-YYYY'), TO_DATE('{3}', 'DD-MM-YYYY'), '{4}', '{5}', {6}, {7})",
                newSpotRental.rentalID, newSpotRental.RFID, newSpotRental.startDate, newSpotRental.endDate, newSpotRental.type, newSpotRental.isPayed, newSpotRental.materialID, newSpotRental.spotNumber));
        }

        public void Edit(SpotRental updateSpotRental, Database database)
        {
            database.editDatabase(String.Format("UPDATE RESERVERING SET STARTDATUM = TO_DATE('{0}', 'DD-MM-YYYY'), EINDDATUM = TO_DATE('{1}', 'DD-MM-YYYY'), BETAALD = '{2}' WHERE PLAATSNUMMER = {1}",
                updateSpotRental.startDate, updateSpotRental.endDate, updateSpotRental.isPayed));

        }

        public void Remove(SpotRental removeSpotRental, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM RESERVERING WHERE HUURID = {0}",
                removeSpotRental.rentalID));
        }
    }
}
