using System;
using System.Collections.Generic;
using System.Text;

namespace Kroz.Classes
{
    class Setup
    {   
        public void SetupPlayer()
        {
            Console.WriteLine("New player, please enter your name.");
            string NewPlayerName = Console.ReadLine();
            Player Player = new Player(NewPlayerName);
            Console.WriteLine("Welcome " + Player.PlayerName);
        }
        public void SetupLocations()
        {
            // Create locations 

            Location Cell = new Location("Cell", "A dark gloomy room with a heavy wooden door.");
            Location GuardRoom = new Location("GuardRoom", "A Guardroom.");
            Location Room3 = new Location("Room3", "A room numbered 3.");
            Location Room4 = new Location("Room4", "A room numbered 4.");

            // Link locations

            Cell.North = GuardRoom;
            GuardRoom.South = Cell;

            GuardRoom.West = Room3;
            Room3.East = GuardRoom;

            GuardRoom.East = Room4;
            Room4.West = GuardRoom;


            // Create items

            Items Key = new Items("Key", "A large rusted key", "Door", "You have unlocked the door!", true, false);
            Items Door = new Items("Door", "A locked heavy oak door", "Key", "The door was unlocked!", false, true);
            Items Three = new Items("3", "Test item 3", null, "The door was unlocked!", true, true);
            Items Four = new Items("4", "Test item 4", null, "The door was unlocked!", true, true);


            // populate the locations with the items

            Cell.AddToLocation(Key);
            Cell.AddToLocation(Door);
            Cell.AddToLocation(Three);
            GuardRoom.AddToLocation(Four);

            // Initialise, set and describe initial location
            Location CurrentLocation;
            CurrentLocation = Cell;
            CurrentLocation.DescribeLocation(CurrentLocation);
            //currentLocation.ListLocationItems();

        }
    }
}
