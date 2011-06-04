using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGameLib
{
    /// <summary>
    /// The class is used to describe an inventory item
    /// </summary>
    public class InventoryItem
    {
        private String name;
        private String type;
        private String imageAlias;

        public InventoryItem()
        {
            name = "";
            type = "";
            imageAlias = "";
        }

        public String Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public String ImageAlias
        {
            get
            {
                return imageAlias;
            }
            set
            {
                imageAlias = value;
            }
        }
    }
}
