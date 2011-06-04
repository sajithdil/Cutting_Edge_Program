using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib.Inventorys
{
    /// <summary>
    /// The class is used  keep track of inventory items
    /// </summary>
    public class Inventory
    {
        private List<InventoryItem> list;

        public Inventory()
        {
            list = new List<InventoryItem>();
        }

        public List<InventoryItem> List
        {
            get
            {
                return list;
            }
            set
            {
                list = value;
            }
        }

        /// <summary>
        /// The function is used to find an inventory item
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public InventoryItem get(String name)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).Name == name)
                {
                    return list.ElementAt(i);
                }
            }

            Log.getInstance().log("@Inventory attempt to access an inventory item "+ name+" which does not exist ");

            return null;
        }

        /// <summary>
        /// The function is used to add an item to the list
        /// </summary>
        /// <param name="item"></param>
        public void add(InventoryItem item)
        {
            list.Add(item);
        }
    }
}
