using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Items
    {
        public string ItemName, ItemDescription, ItemInteractionTarget, InteractionResult;
        public bool Pickupable;
        public Items(string ItemName, string ItemDescription, string ItemInteractionTarget, string InteractionResult, bool Pickupable)
        {
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
            this.ItemInteractionTarget = ItemInteractionTarget;
            this.InteractionResult = InteractionResult;
            this.Pickupable = Pickupable;
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
        public string GetInteractionResult()
        {
            return this.InteractionResult;
        }
        public bool GetPickupableBool()
        {
            return this.Pickupable;
        }
        //public Items GetItem(Items item) 
        //{

        //}
    }
}
