using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proftaak_ICT4Events
{
    class MaterialManager
    {
        Database database;

        public MaterialManager(Database database)
        {
            this.database = database;
        }

        public List<MaterialCategory> getAllCategories()
        {
            return MaterialCategory.GetAll(database);
        }

        public List<Material> getAllMaterialFromCategory(MaterialCategory materialCategory)
        {
            return Material.getAll(materialCategory, database);
        }
        public List<Reservation> getAllMaterialFromUser(User user)
        {
            Reservation reservation = new Reservation();
            return reservation.GetAllFromUser(user.propertyRFID, database);
        }
    }
}
