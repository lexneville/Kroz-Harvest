using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Location
    {
        // Initiate room detail variables
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
            this.LocationItems.Add(newItem);
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
            if (this.LocationItems.Count >= 1 )
            {
                Console.WriteLine("You search the room and find:");
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
            return this.LocationItems.Count;
        }

        public Items Take(string itemName)
        {
            if (this.LocationItems.Count >= 1)
            {
                foreach(Items i in LocationItems)
                {
                    if (i.ItemName.ToLower() == itemName.ToLower())
                    {
                        RemoveFromLocation(i);
                        return i;
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
