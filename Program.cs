using System;
using Kroz.Classes;

namespace Kroz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("New player, please enter your name.");
            string NewPlayerName = Console.ReadLine();
            Player Player = new Player(NewPlayerName);
            Console.WriteLine("Welcome " + Player.PlayerName);

            Location Cell = new Location("Cell", "A dark gloomy room with a heavy wooden door." );
            //Console.WriteLine("Room " + EscapeRoom.LocationName + " has been created");
            Location GuardRoom = new Location("GuardRoom", "A warden's office with various rubber and leather weird bondage type stuff on the walls.");

            // Link Locations
            Cell.North = GuardRoom;
            GuardRoom.South = Cell;


            // Create items

            Items Key = new Items("Key", "A large rusted key", "Door");
            Items Door = new Items("Door", "A locked oak door", "Key");

            //Console.WriteLine("Item " + Key.ItemName + " has been created");


            // populate the locations with the items

            Cell.AddToLocation(Key);
            Cell.AddToLocation(Door);


            //Console.WriteLine("Your current location contains " + currentLocation.GetCount() + " items."); 

            // Initialise, set and describe initial location
            Location currentLocation; 
            currentLocation = Cell;
            currentLocation.DescribeLocation(currentLocation);

            while (true)
            { 
                Console.WriteLine("What would you like to do?");
                string command = Console.ReadLine();
                
                if (command == "Look")
                {
                    currentLocation.ListLocationItems();
                }   
                else if (command == "Take")
                {
                    Console.WriteLine("Which item would you like to pick up?");
                    string itemChoice = Console.ReadLine();
                    Player.AddToInventory(currentLocation.Take(itemChoice));
                }  
                else if (command == "Use")
                {
                    Console.WriteLine("Which item would you like to use?");
                    string ItemInUse = Console.ReadLine();
                    Console.WriteLine("What would you like to use the " + ItemInUse + " with?");
                    string ItemUseTarget = Console.ReadLine();
                }
                else if (command == "Move")
                {
                    Console.WriteLine("Which direction would you like to go?");
                    string TravelDirection = Console.ReadLine();
                }
            }
        }
    }
}