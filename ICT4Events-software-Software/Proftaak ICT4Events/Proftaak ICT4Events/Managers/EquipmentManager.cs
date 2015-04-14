using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Equipment> Search(string text)
        {
            List<Equipment> allEquipment = Equipment.getAll(database);
            List<Equipment> equipmentShown = new List<Equipment>();

            foreach(Equipment equipment in allEquipment)
            {
                if(equipment.Name.IndexOf(text) != -1)
                {
                    equipmentShown.Add(equipment);
                }
            }

            return equipmentShown;
        }

        public void CheckOut()
        {

        }
    }
}
