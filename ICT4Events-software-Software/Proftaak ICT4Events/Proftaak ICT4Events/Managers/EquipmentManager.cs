using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proftaak_ICT4Events
{
    class EquipmentManager
    {
        List<Equipment> ShoppingCart;

        Database database;

        public EquipmentManager()
        {
            ShoppingCart = new List<Equipment>();

            database = new Database();
        }

        public void AddToCart(Equipment equipment)
        {
            ShoppingCart.Add(equipment);
        }

        public void RemoveFromCart(Equipment equipment)
        {
            ShoppingCart.Remove(equipment);
        }

        public List<Material> Search(string text)
        {
            List<Material> allMaterial = Material.getAll(database, CategoryType.HOOFDTELEFOON);
            List<Material> materialShown = new List<Material>();

            foreach (Material material in allMaterial)
            {
                if (material.Name.IndexOf(text) != -1)
                {
                    materialShown.Add(material);
                    MessageBox.Show("" + material.Name);
                }
            }

            return allMaterial;
        }

        public void CheckOut()
        {

        }
    }
}
