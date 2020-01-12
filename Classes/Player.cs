using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Player
    {
        public string PlayerName { get; set; }
        public int PlayerHealth { get; set; }
        private List<Items> Inventory = new List<Items>();
        public Player(string PlayerName)
        {
            this.PlayerName = PlayerName;
            this.PlayerHealth = 100;
        }
        public void AddToInventory(Items item)
        {
            if (item != null)
            { 
                this.Inventory.Add(item);
                Console.WriteLine("You now have " + GetCount() + " in the your inventory.");
            }
        }
        public void RemoveFromInventory()
        {

        }
        public void UseItem(Items item)
        {

        }
        public int GetCount()
        {
            return this.Inventory.Count;
        }
    }
}
