using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Items
    {
        public string ItemName, ItemDescription, ItemInteractionTarget;
        public Items(string ItemName, string ItemDescription, string ItemInteractionTarget)
        {
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
            this.ItemInteractionTarget = ItemInteractionTarget;
        }
        public void DisplayItem()
        {
            Console.WriteLine(ItemDescription);
        }
        public string GetItemName()
        {
            return this.ItemName;
        }
        public string GetItemDescription()
        {
            return this.ItemDescription;
        }
        public string GetItemInteractionTarget()
        {
            return this.ItemInteractionTarget;
        }
    }
}
