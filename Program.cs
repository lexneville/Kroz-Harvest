using System;
using Kroz.Classes;
using static System.Environment;
using static System.Console;
using System.Collections.Generic;


namespace Kroz
{
    class Program
    {
        static void Main(string[] args)
        {

            //using static Environment
            // Setup player and enemies

            WriteLine("New player, please enter your name.");
            string NewPlayerName = ReadLine();
            var Player = new Player(NewPlayerName);
            Clear();
            WriteLine("Welcome " + Player.GetName());



            var Goblin = new Enemy("Goblin", 50, 0);
            var Troll = new Enemy("Troll", 150, 0);
            var DarkWizard = new Enemy("Dark Wizard", 100, 100);
            var Wraith = new Enemy("Wraith", 150, 150);
            var currentEnemy = Goblin;
            var currentPlayer = Player;

            Random rand = new Random();

            int playerRoll, enemyRoll;

            // Create locations 



            Location Cell = new Location("Cell", "A dark gloomy room with a heavy wooden door.", true, null);
            Location GuardRoom = new Location("GuardRoom", "A Guardroom.", true, null);
            Location Room3 = new Location("Room3", "A room numbered 3.", false, Wraith);
            Location Room4 = new Location("Room4", "A room numbered 4.", false, Goblin);

            // Set closed exits


            // Link locations

            Cell.north = GuardRoom;
            GuardRoom.south = Cell;

            GuardRoom.west = Room3;
            Room3.east = GuardRoom;

            GuardRoom.east = Room4;
            Room4.west = GuardRoom;

            //var locationStore = new Dictionary<string, Location>
            //{
            //    {"Cell", Cell},
            //    {"GuardRoom", Cell},
            //    // todo: complete this
            //};

            //Cell.AddNorthRoom("GuardRoom");

            //locationStore.TryGetValue("Cell" , out var location)
            //    {
            //    location.north = 
            //}



            // Create items

            Items Key = new Items("Key", "A large rusted key", "Door", "You have unlocked the door!", true);
            Items Three = new Items("3", "Test item 3", null, "The door was unlocked!", true);
            Items Four = new Items("4", "Test item 4", null, "The door was unlocked!", true);


            // populate the locations with the items

            Cell.AddToLocation(Key);
            Cell.AddToLocation(Three);
            GuardRoom.AddToLocation(Four);

            // Initialise, set and describe initial location
            Location currentLocation;
            currentLocation = Cell;
            Location previousLocation = currentLocation;
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

                    playerRoll = RollDice(6);
                    enemyRoll = RollDice(6);

                    // string playerChoices = "";
                    void RollResult()
                    {
                        WriteLine($"{currentPlayer.GetName()} has rolled {playerRoll}, the {currentLocation.GetLocationEnemy(currentLocation).GetName()} has rolled {enemyRoll}");
                    };

                    void HealthDisplay()
                    {
                        WriteLine($"The {currentPlayer.GetName()} now has {playerHealth()} HP");
                        WriteLine($"The {currentLocation.GetLocationEnemy(currentLocation).GetName()} now has {enemyHealth()} HP");
                    };

                    Clear();

                    if (playerRoll > enemyRoll)
                    {
                        WriteLine
                            (
                            " ██╗██╗██╗    ██╗  ██╗██╗████████╗    ██╗██╗██╗" + NewLine +
                            " ██║██║██║    ██║  ██║██║╚══██╔══╝    ██║██║██║" + NewLine +
                            " ██║██║██║    ███████║██║   ██║       ██║██║██║" + NewLine +
                            " ╚═╝╚═╝╚═╝    ██╔══██║██║   ██║       ╚═╝╚═╝╚═╝" + NewLine +
                            " ██╗██╗██╗    ██║  ██║██║   ██║       ██╗██╗██╗" + NewLine +
                            " ╚═╝╚═╝╚═╝    ╚═╝  ╚═╝╚═╝   ╚═╝       ╚═╝╚═╝╚═╝ "
                            );
                        RollResult();
                        WriteLine($"{currentPlayer.GetName()} wins the roll, your attack was successful!");
                        WriteLine("Hit a key to roll a D20 for damage amount");
                        int playerDamageRoll = RollDice(20);
                        WriteLine($"{currentLocation.GetLocationEnemy(currentLocation).GetName()}'s health has been reduced by {playerDamageRoll} HP");
                        currentEnemy.TakeHealth(currentEnemy, playerDamageRoll);
                        HealthDisplay();
                    }

                    else if (playerRoll < enemyRoll)
                    {
                        WriteLine
                            (
                            " ██╗██╗██╗    ███╗   ███╗██╗███████╗███████╗    ██╗██╗██╗" + NewLine +
                            " ██║██║██║    ████╗ ████║██║██╔════╝██╔════╝    ██║██║██║" + NewLine +
                            " ██║██║██║    ██╔████╔██║██║███████╗███████╗    ██║██║██║" + NewLine +
                            " ╚═╝╚═╝╚═╝    ██║╚██╔╝██║██║╚════██║╚════██║    ╚═╝╚═╝╚═╝" + NewLine +
                            " ██╗██╗██╗    ██║ ╚═╝ ██║██║███████║███████║    ██╗██╗██╗" + NewLine +
                            " ╚═╝╚═╝╚═╝    ╚═╝     ╚═╝╚═╝╚══════╝╚══════╝    ╚═╝╚═╝╚═╝"
                            );
                        RollResult();
                        WriteLine($"{currentLocation.GetLocationEnemy(currentLocation).GetName()} wins the roll, your attack was blocked and the {currentLocation.GetLocationEnemy(currentLocation).GetName()} strikes back!");
                        WriteLine($"The {currentLocation.GetLocationEnemy(currentLocation).GetName()} rolls a D12 for damage");
                        int enemyDamageRoll = RollDice(12);
                        WriteLine($"{currentPlayer.GetName()}'s health has been reduced by {enemyDamageRoll} HP");
                        currentPlayer.TakeHealth(currentPlayer, enemyDamageRoll);
                        HealthDisplay();
                    }

                    else
                    {
                        WriteLine("Your weapons clash against each other!");
                    }

                }
                WriteLine($"You encounter a {currentLocation.GetLocationEnemy(currentLocation).GetName()}");

                do // Encounter Loop
                {
                    if (playerHealth() > 0)
                    {
                        WriteLine
                            (
                            "Pick an action!" + NewLine +
                            "| Strike - S | Inventory - I | Use - U | Escape - E |"
                            );
                        string encounterCommand = ReadLine().ToLower();

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
                                currentLocation = previousLocation;
                                WriteLine("You run back to the {0} like a yellow bellied coward!", currentLocation.GetLocationName()); ;
                                GameLoop();
                                break;

                            default:
                                WriteLine("Please choose a valid command!");
                                break;
                        }
                    } else if (playerHealth() >= 0)
                    {
                        WriteLine("You are dead");
                    }
                } while (enemyHealth() > 0 && playerHealth() >= 0);

            }

            // Game loop
            void GameLoop()
            {
                while (true)
                {
                    if (!currentLocation.GetEnemyDefeated())
                    {
                        currentEnemy = currentLocation.GetLocationEnemy(currentLocation);
                        WriteLine(currentEnemy.GetName());
                        WriteLine(currentLocation.GetLocationEnemy(currentLocation).GetName());
                        Encounter();
                        currentLocation.SetEnemyDefeated();
                    }

                    currentLocation.DescribeLocation(currentLocation);
                    WriteLine
                        (
                            "What would you like to do?" + NewLine +
                            "|| L - Look || M - Move || T - Take || U - Use ||"
                        );
                    string command = ReadLine();

                    switch (command)
                    {
                        case "Look":
                        case "look":
                        case "L":
                        case "l":
                            {
                                Clear();
                                WriteLine("You search the room and find:");
                                currentLocation.ListLocationItems();
                                break;
                            }
                        case "Take":
                        case "take":
                        case "T":
                        case "t":
                            { if (currentLocation.GetCount() >= 1)
                                {
                                    Clear();
                                    WriteLine("Which item would you like to pick up?");
                                    currentLocation.ListLocationItems();
                                    string itemChoice = ReadLine().ToLower();
                                    Player.AddToInventory(currentLocation.Take(itemChoice));
                                    break;
                                }
                                else
                                {
                                    WriteLine("This room is empty of items!");
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
                                    WriteLine("Your inventory is empty!");
                                    break;
                                }
                            }
                        case "Move":
                        case "move":
                        case "M":
                        case "m":
                            {
                                Clear();
                                WriteLine("Which direction would you like to go?");
                                WriteLine("Exits: |{0}{1}{2}{3}|",
                                    currentLocation.north == null ? "" : "| North |",
                                    currentLocation.east == null ? "" : "| East |",
                                    currentLocation.south == null ? "" : "| South |",
                                    currentLocation.west == null ? "" : "| West |");
                                string TravelDirection = ReadLine();
                                switch (TravelDirection)
                                {
                                    case "North":
                                    case "north":
                                    case "N":
                                    case "n":
                                        if (currentLocation.north != null)
                                        {
                                            previousLocation = currentLocation;
                                            currentLocation = currentLocation.north;
                                        }
                                        break;

                                    case "East":
                                    case "east":
                                    case "E":
                                    case "e":
                                        if (currentLocation.east != null)
                                        {
                                            previousLocation = currentLocation;
                                            currentLocation = currentLocation.east;
                                        }
                                        break;

                                    case "South":
                                    case "south":
                                    case "S":
                                    case "s":
                                        if (currentLocation.south != null)
                                        {
                                            previousLocation = currentLocation;
                                            currentLocation = currentLocation.south;
                                        }
                                        break;

                                    case "West":
                                    case "west":
                                    case "W":
                                    case "w":
                                        if (currentLocation.west != null)
                                        {
                                            previousLocation = currentLocation;
                                            currentLocation = currentLocation.west;
                                        }
                                        break;

                                    case "Up":
                                    case "up":
                                    case "U":
                                    case "u":
                                        if (currentLocation.up != null)
                                        {
                                            previousLocation = currentLocation;
                                            currentLocation = currentLocation.up;
                                        }

                                        break;

                                    case "Down":
                                    case "down":
                                    case "D":
                                    case "d":
                                        if (currentLocation.down != null)
                                        {
                                            previousLocation = currentLocation;
                                            currentLocation = currentLocation.down;
                                        }
                                        break;


                                    default:
                                        WriteLine("Please choose a valid direction!");
                                        break;
                                }
                                Clear();
                                
                                break;
                            }
                        default:
                            Clear();
                            WriteLine("Please choose a valid action!");
                            currentLocation.DescribeLocation(currentLocation);
                            break;
                    }
                }

            }
            GameLoop();
        }
    }
}