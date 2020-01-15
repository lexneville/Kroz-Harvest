using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Location
    {
        // Create room detail variables
        public string locationName, locationDescription;

        // Each Location has exits to other locations attached, initiate their variebles
        public Location north, east, south, west, uUp, down;

        private List<Items> locationItems = new List<Items>();

        public Location(string LocationName, string LocationDescription)
        {
            this.locationName = LocationName;
            this.locationDescription = LocationDescription;
        }
        
        public void AddToLocation(Items item)
        {
            Items newItem = item;
            locationItems.Add(newItem);
        }
        public void RemoveFromLocation(Items item)
        {
            locationItems.Remove(item);
            Console.WriteLine("Item taken.");
        }
        public void DescribeLocation(Location CurrentLocation)
        {
            Console.WriteLine($"You are standing in a { locationName }, { locationDescription}");
        }
        public void ListLocationItems()
        {
            if (locationItems.Count > 0)
            {
                foreach (Items item in locationItems)
                {
                    item.DisplayItem();
                }   
            }   
            else
            {
                Console.WriteLine("There are no items in the room");
            }
        }
        public int GetCount()
        {
            return locationItems.Count;
        }

        public Items Take(string itemName)
        {   
            if (locationItems.Count > 0)
            {
                foreach (Items i in locationItems)
                {
                    if (i.itemName.ToLower() == itemName.ToLower())
                    {

                        if (i.pickupable == true)
                        {
                            RemoveFromLocation(i);
                            return i;
                        }
                        else
                        {
                            Console.WriteLine("This object cannot be picked up");
                        }
                    }
                }
                Console.WriteLine("That item is not in this location");
                return null;
            }
            else
            {
                Console.WriteLine("The room is empty!");
                return null;
            }
        }
    }
}
