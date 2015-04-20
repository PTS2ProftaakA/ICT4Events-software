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

        public List<Material> getAllMaterial(MaterialCategory materialCategory)
        {
            return Material.getAll(materialCategory, database);
        }
    }
}
