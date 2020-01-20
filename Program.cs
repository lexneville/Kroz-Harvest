using System;
using Kroz.Classes;

namespace Kroz
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup player and enemies

            Console.WriteLine("New player, please enter your name.");
            string NewPlayerName = Console.ReadLine();
            Player Player = new Player(NewPlayerName);
            Console.WriteLine("Welcome " + Player.GetName());
            Enemy goblin = new Enemy("Goblin", 50, 0);
            Enemy Troll = new Enemy("Troll", 150, 0);
            Enemy DarkWizard = new Enemy("Dark Wizard", 100, 100);
            Enemy Wraith = new Enemy("Wraith", 50, 150);
            Enemy currentEnemy = goblin;
            Player currentPlayer = Player;

            Random rand = new Random();

            int playerRoll, enemyRoll;
            string playerName = currentPlayer.GetName();
            string enemyName = currentEnemy.GetName();

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

            int playerHealth()
            {
                return currentPlayer.GetHealth(currentPlayer);
            };

            int enemyHealth()
            {
                return currentEnemy.GetHealth(currentEnemy);
            };

            int RollDice(int maxValue)
            {
                return rand.Next(1, maxValue);
            };

            void Potion(int healthIncrease)
            {
                currentPlayer.Heal(currentPlayer, healthIncrease);
            }

            void Encounter()
            {
                void PhysicalAttack()
                {
                    Console.WriteLine("Press a key to roll the dice and attack!");
                    Console.WriteLine("If you roll higher than the enemy rolls, your strike is successful");
                    Console.ReadKey();
                    Console.WriteLine();
                    playerRoll = RollDice(6);
                    enemyRoll = RollDice(6);

                    // string playerChoices = "";
                    void RollResult()
                    {
                        Console.WriteLine($"{playerName} has rolled {playerRoll}, the {enemyName} has rolled {enemyRoll}");
                    };

                    void HealthDisplay()
                    {
                        Console.WriteLine($"The {playerName} now has {playerHealth()} HP");
                        Console.WriteLine($"The {enemyName} now has {enemyHealth()} HP");
                    };

                    if (playerRoll > enemyRoll)
                    {
                        RollResult();
                        Console.WriteLine($"{playerName} wins the roll, your attack was successful!");
                        Console.WriteLine("Hit a key to roll a D20 for damage amount");
                        int playerDamageRoll = RollDice(20);
                        Console.WriteLine($"{enemyName}'s health has been reduced by {playerDamageRoll} HP");
                        currentEnemy.TakeHealth(currentEnemy, playerDamageRoll);
                        HealthDisplay();
                    }

                    else if (playerRoll < enemyRoll)
                    {
                        RollResult();
                        Console.WriteLine($"{enemyName} wins the roll, your attack was blocked and the {enemyName} strikes back!");
                        Console.WriteLine($"The {enemyName} rolls a D12 for damage");
                        int enemyDamageRoll = RollDice(12);
                        Console.WriteLine($"{playerName}'s health has been reduced by {enemyDamageRoll} HP");
                        currentPlayer.TakeHealth(currentPlayer, enemyDamageRoll);
                        HealthDisplay();
                    }
                    else
                    {
                        Console.WriteLine("Your weapons clash against each other!");
                    }

                }
                Console.WriteLine($"You encounter a {enemyName}");

                do // Encounter Loop
                {
                    Console.WriteLine
                        (
                        "Pick an action\n" +
                        "Strike - S\n" +
                        "Inventory - I\n" +
                        "Use - U\n" +
                        "Escape - E\n"
                        );
                    string encounterCommand = Console.ReadLine().ToLower();

                    switch (encounterCommand)
                    {
                        case "s":
                            PhysicalAttack();
                            break;
                        case "i":
                            break;
                        case "u":
                            break;
                        case "e":
                            break;
                        default:
                            Console.WriteLine("Please choose a valid command!");
                            break;

                    }

                } while (enemyHealth() > 0 && playerHealth() > 0);

            }

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