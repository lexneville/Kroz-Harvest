using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Location
    {
        // Create room detail variables
        public string LocationName, LocationDescription;

        // Each Location has exits to other locations attached, initiate their variebles
        public Location North, East, South, West, Up, Down;

        private List<Items> LocationItems = new List<Items>();

        public Location(string LocationName, string LocationDescription)
        {
            this.LocationName = LocationName;
            this.LocationDescription = LocationDescription;
        }
        
        public void AddToLocation(Items item)
        {
            Items newItem = item;
            LocationItems.Add(newItem);
        }
        public void RemoveFromLocation(Items item)
        {
            LocationItems.Remove(item);
            Console.WriteLine("Item taken.");
        }
        public void DescribeLocation(Location currentLocation)
        {
            Console.WriteLine("You are standing in a " + LocationName + ", " + LocationDescription);
        }
        public void ListLocationItems()
        {
            if (LocationItems.Count > 0)
            {
                foreach (Items item in LocationItems)
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
            return LocationItems.Count;
        }

        public Items Take(string itemName)
        {   
            if (LocationItems.Count > 0)
            {
                foreach (Items i in LocationItems)
                {
                    if (i.ItemName.ToLower() == itemName.ToLower())
                    {

                        if (i.Pickupable == true)
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
