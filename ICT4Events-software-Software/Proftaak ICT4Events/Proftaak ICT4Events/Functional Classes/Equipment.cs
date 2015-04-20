using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    enum CategoryType
    {
        MOBIEL_APPARAAT,
        RANDAPPARATUUR,
        LAPTOP,
        COMPUTER,
        HOOFDTELEFOON        
    }

    class Equipment : Reservation
    {
        private Material material;
        
        public Material Material
        {
            get { return material; }
            set { material = value; }
        }

        public Equipment(string RFID, int rentalID, DateTime startDate, DateTime endDate, bool isPayed, RentalType type,
                 Material material)
            : base(RFID, rentalID, startDate, endDate, isPayed, type)
        {
            this.material = material;
        }

        public static List<Equipment> getAll(Database database)
        {
            List<string> equipmentColumns = new List<string>();
            List<Equipment> allEquipment = new List<Equipment>();

            equipmentColumns.Add("HUURID");
            equipmentColumns.Add("RFID");
            equipmentColumns.Add("STARTDATUM");
            equipmentColumns.Add("EINDDATUM");
            equipmentColumns.Add("HUURTYPE");
            equipmentColumns.Add("BETAALD");
            equipmentColumns.Add("MATID");
            equipmentColumns.Add("NAAM");
            equipmentColumns.Add("HOEVEELHEID");
            equipmentColumns.Add("BORG");
            equipmentColumns.Add("OMSCHRIJVING");
            equipmentColumns.Add("CATEGORIE");
            equipmentColumns.Add("FOTOPAD");
            
            //Has to be fixed with current database

            List<string>[] dataTable = database.selectQuery("SELECT r.HUURID, r.RFID, r.STARTDATUM, r.EINDDATUM, r.HUURTYPE, r.BETAALD, m.MATID, m.NAAM, m.HOEVEELHEID, m.BORG, m.OMSCHRIJVING, m.CATEGORIE, m.FOTOPAD FROM RESERVERING r, MATERIAAL m", equipmentColumns);

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
                    CategoryType categoryValue = (CategoryType)Enum.Parse(typeof(CategoryType), dataTable[11][i]);

                    allEquipment.Add(new Equipment(
                        dataTable[1][i],
                        Convert.ToInt32(dataTable[0][i]),
                        Convert.ToDateTime(dataTable[2][i]),
                        Convert.ToDateTime(dataTable[3][i]),
                        isPayed,
                        rentalValue,
                        new Material(
                            dataTable[7][i],
                            dataTable[10][i],
                            dataTable[12][i],
                            Convert.ToInt32(dataTable[6][i]),
                            Convert.ToInt32(dataTable[8][i]),
                            Convert.ToDecimal(dataTable[9][i]) / 100,
                            categoryValue)));
                }
            }

            return allEquipment;
        }

        public void Add(Equipment newEquipment, Database database)
        {
            database.editDatabase(String.Format("INSERT INTO RESERVERING VALUES ({0}, '{1}', TO_DATE('{2}', 'DD-MM-YYYY'), TO_DATE('{3}', 'DD-MM-YYYY'), '{4}', '{5}', {6}, {7})",
                newEquipment.rentalID, newEquipment.RFID, newEquipment.startDate, newEquipment.endDate, newEquipment.type, newEquipment.isPayed, newEquipment.materialID, newEquipment.spotNumber));
        }

        public void Edit(Equipment updateEquipment, Database database)
        {
            database.editDatabase(String.Format("UPDATE RESERVERING SET STARTDATUM = TO_DATE('{0}', 'DD-MM-YYYY'), EINDDATUM = TO_DATE('{1}', 'DD-MM-YYYY'), BETAALD = '{2}' WHERE PLAATSNUMMER = {1}",
                updateEquipment.startDate, updateEquipment.endDate, updateEquipment.isPayed));

        }

        public void Remove(Equipment removeEquipment, Database database)
        {
            database.editDatabase(String.Format("DELETE FROM RESERVERING WHERE HUURID = {0}",
                removeEquipment.rentalID));
        }
    }
}
