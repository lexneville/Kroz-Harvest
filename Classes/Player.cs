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
                Console.WriteLine("You have taken the " + item.ItemName + "! You now have " + GetCount() + " item/s in your inventory.");
            }
        }
        public void RemoveFromInventory()
        {

        }
        public void UseItem(string ItemChoice, string UseTarget)
        {
            foreach (Items i in Inventory)
            {
                if (i.ItemName.ToLower() == ItemChoice.ToLower())
                {
                    Console.WriteLine("The item is in your inventory");
                }
                else
                {
                    Console.WriteLine("The item is not in your inventory");
                }
            }
        }
        public int GetCount()
        {
            return this.Inventory.Count;
        }
    }
}
