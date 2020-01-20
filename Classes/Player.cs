using System;
using System.Collections.Generic;
using static System.Console;

namespace Kroz.Classes
{
    class Player
    {
        private string name { get; set; }
        private int health { get; set; }
        private int mana { get; set; }

        private List<Items> Inventory = new List<Items>();
        public Player(string name)
        {
            this.name = name;
            health = 100;
            mana = 100;
        }
        public void AddToInventory(Items item)
        {
            if (item != null)
            { 
                Inventory.Add(item);
                WriteLine($"You have taken the {item.itemName}! You now have {GetCount()} item/s in your inventory.");
            }
        }
        public void RemoveFromInventory()
        {

        }
        public void UseItem()
        {
            WriteLine("Which item would you like to use?");
            string ItemChoice = ReadLine().ToLower();

            foreach (Items i in Inventory)
            {
                if (i.itemName.ToLower() == ItemChoice.ToLower())
                {
                    WriteLine($"What would you like to use the { ItemChoice } with?");
                    string UseTarget = ReadLine().ToLower();

                    if (i.itemName.ToLower() == ItemChoice.ToLower())
                    {
                        WriteLine("test1" + i.itemInteractionTarget);
                        if (i.itemInteractionTarget.ToLower() == UseTarget)
                        {
                            WriteLine($"Interaction success! {i.interactionResult}");
                        }
                        else
                        {
                            WriteLine("Those items are not compatible");
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }

            WriteLine("That item is not in your inventory");
        }
        public int GetCount()
        {
            return Inventory.Count;
        }
        public string GetName()
        {
            return name;
        }
        public int GetHealth(Player player)
        {
            return health;
        }
        public void TakeHealth(Player player, int healthChange)
        {

            health -= healthChange;
        }

        public void Heal(Player player, int healthChange)
        {
            health += healthChange;
        }
    }
}
