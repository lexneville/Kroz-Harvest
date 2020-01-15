using System;
using Kroz.Classes;

namespace Kroz
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup player

            Console.WriteLine("New player, please enter your name.");
            string NewPlayerName = Console.ReadLine();
            Player Player = new Player(NewPlayerName);
            Console.WriteLine("Welcome " + Player.PlayerName);

            // Create locations 

            Location Cell = new Location("Cell", "A dark gloomy room with a heavy wooden door.");
            Location GuardRoom = new Location("GuardRoom", "A Guardroom.");
            Location Room3 = new Location("Room3", "A room numbered 3.");
            Location Room4 = new Location("Room4", "A room numbered 4.");

            // Link locations

            Cell.north = GuardRoom;
            GuardRoom.south = Cell;

            GuardRoom.west = Room3;
            Room3.east = GuardRoom;

            GuardRoom.east = Room4;
            Room4.west = GuardRoom;


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




            while (true)
            { 
                Console.WriteLine("What would you like to do?\n" +
                    "L = Look\n" +
                    "T = Take\n" +
                    "U = Use\n" +
                    "M = Move");
                string command = Console.ReadLine();
                
                switch (command)
                {
                    case "Look":
                    case "look":
                    case "L":
                    case "l":
                        {
                            Console.WriteLine("You search the room and find:");
                            CurrentLocation.ListLocationItems();
                            break;
                        }
                    case "Take":
                    case "take":
                    case "T":
                    case "t":
                        {   if (CurrentLocation.GetCount() >= 1)
                            {
                                Console.WriteLine("Which item would you like to pick up?");
                                string itemChoice = Console.ReadLine().ToLower();
                                Player.AddToInventory(CurrentLocation.Take(itemChoice));
                                break;
                            }
                            else
                            {
                                Console.WriteLine("This room is empty of items!");
                                break;
                            }
                        }
                    case "Use":
                    case "use":
                    case "U":
                    case "u":
                        {   
                            if (Player.GetCount() > 0)
                            {   
                                Player.UseItem();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Your inventory is empty!");
                                break;
                            }
                        }
                    case "Move":
                    case "move":
                    case "M":
                    case "m":
                        {
                            Console.WriteLine("Which direction would you like to go?");
                            Console.WriteLine("Exits: {0}{1}{2}{3}",
                                CurrentLocation.north == null ? "" : "North ",
                                CurrentLocation.east == null ? "" : "East ",
                                CurrentLocation.south == null ? "" : "South ",
                                CurrentLocation.west == null ? "" : "West");
                            string TravelDirection = Console.ReadLine();
                            switch (TravelDirection)
                            {
                                case "North":
                                case "north":
                                case "N":
                                case "n":
                                    if (CurrentLocation.north != null)
                                        CurrentLocation = CurrentLocation.north;
                                    break;

                                case "East":
                                case "east":
                                case "E":
                                case "e":
                                    if (CurrentLocation.east != null)
                                        CurrentLocation = CurrentLocation.east;
                                    break;

                                case "South":
                                case "south":
                                case "S":
                                case "s":
                                    if (CurrentLocation.south != null)
                                        CurrentLocation = CurrentLocation.south;
                                    break;

                                case "West":
                                case "west":
                                case "W":
                                case "w":
                                    if (CurrentLocation.west != null)
                                        CurrentLocation = CurrentLocation.west;
                                    break;

                                case "Up":
                                case "up":
                                case "U":
                                case "u":
                                    if (CurrentLocation.uUp != null)
                                        CurrentLocation = CurrentLocation.uUp;
                                    break;

                                case "Down":
                                case "down":
                                case "D":
                                case "d":
                                    if (CurrentLocation.down != null)
                                        CurrentLocation = CurrentLocation.down;
                                    break;

                                default:
                                    Console.WriteLine("Please choose a valid direction!");
                                    break;
                            }
                            CurrentLocation.DescribeLocation(CurrentLocation);
                            break;
                        }
                    default:
                        Console.WriteLine("Please choose a valid action!");
                        break;
                }    
            }
        }
    }
}