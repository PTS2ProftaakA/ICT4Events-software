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

        //Gets all material categories using a function in MaterialCategory
        //An example of such an category is mobile phones
        public List<MaterialCategory> getAllCategories()
        {
            return MaterialCategory.GetAll(database);
        }

        //Returns all the material of a certain type using a function in Material
        public List<Material> getAllMaterialFromCategory(MaterialCategory materialCategory)
        {
            return Material.getAll(materialCategory, database);
        }

        //Returns all the reservations of a single user using a function in Reservation
        public List<Reservation> getAllMaterialFromUser(User user)
        {
            Reservation reservation = new Reservation();
            return reservation.GetAllFromUser(user.UserID, database);
        }

        //Returns all the materials from the database using a function in Material
        public List<Material> getAll()
        {
            return Material.getAll(database);
        }
    }
}
