using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Items
    {
        public string ItemName, ItemDescription, ItemInteractionTarget, InteractionResult;
        public bool Pickupable;
        public bool Locked;
        public Items(string ItemName, string ItemDescription, string ItemInteractionTarget, string InteractionResult, bool Pickupable, bool Locked)
        {
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
            this.ItemInteractionTarget = ItemInteractionTarget;
            this.InteractionResult = InteractionResult;
            this.Pickupable = Pickupable;
            this.Locked = Locked;
        }
        public void DisplayItem()
        {
            Console.WriteLine(ItemDescription);
        }
        public string GetItemName()
        {
            return ItemName;
        }
        public string GetItemDescription()
        {
            return ItemDescription;
        }
        public string GetItemInteractionTarget()
        {
            return ItemInteractionTarget;
        }
        public string GetInteractionResult()
        {
            return InteractionResult;
        }
        public bool GetPickupableBool()
        {
            return Pickupable;
        }
    }
}
