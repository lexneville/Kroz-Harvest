﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Items
    {
        public string itemName, itemDescription, itemInteractionTarget, interactionResult;
        public bool pickupable;

        public Items(string itemName, string itemDescription, string itemInteractionTarget, string interactionResult, bool pickupable)
        {
            this.itemName = itemName;
            this.itemDescription = itemDescription;
            this.itemInteractionTarget = itemInteractionTarget;
            this.interactionResult = interactionResult;
            this.pickupable = pickupable;
        }
        public void DisplayItem()
        {
            Console.WriteLine(itemDescription);
        }
        public string GetItemName()
        {
            return itemName;
        }
        public string GetItemDescription(Items item)
        {
            return item.itemDescription;
        }
        public string GetItemInteractionTarget()
        {
            return itemInteractionTarget;
        }
        public string GetInteractionResult()
        {
            return interactionResult;
        }
        public bool GetPickupableBool()
        {
            return pickupable;
        }

    }
}
