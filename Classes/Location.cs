using System;
using System.Collections.Generic;
using System.Text;
using static System.Environment;
using static System.Console;

namespace Kroz.Classes
{
    class Location
    {
        // Create room detail variables
        private string locationName, locationDescription;
        private bool enemyDefeated;
        private Enemy locationEnemy;


        // Each Location has exits to other locations attached, initiate their variables
        public Location north, east, south, west, up, down;

        private List<Items> locationItems = new List<Items>();

        public Location(string LocationName, string LocationDescription, bool enemyDefeated, Enemy locationEnemy)
        {
            this.locationName = LocationName;
            this.locationDescription = LocationDescription;
            this.enemyDefeated = enemyDefeated;
            this.locationEnemy = locationEnemy;
        }

        public string GetLocationName()
        {
            return this.locationName;
        }
        
        public void AddToLocation(Items item)
        {
            Items newItem = item;
            locationItems.Add(newItem);
        }
        public void RemoveFromLocation(Items item)
        {
            locationItems.Remove(item);
            WriteLine("Item taken.");
        }
        public void DescribeLocation(Location CurrentLocation)
        {
            WriteLine($"You are standing in a {locationName}, {locationDescription}");
        }

        public bool GetEnemyDefeated()
        {
            return this.enemyDefeated;
        }
        public void SetEnemyDefeated()
        {
            this.enemyDefeated = true;
        }
        public Enemy GetLocationEnemy(Location location)
        {
            return location.locationEnemy;
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
                WriteLine("There are no items in the room");
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
                            WriteLine("This object cannot be picked up");
                        }
                    }
                }
                WriteLine("That item is not in this location");
                return null;
            }
            else
            {
                WriteLine("The room is empty!");
                return null;
            }
        }
    }
}
