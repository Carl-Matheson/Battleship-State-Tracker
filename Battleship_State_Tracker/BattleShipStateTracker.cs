using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship_State_Tracker
{
    /*
     * #BATTLESHIP RULES#
     * Two players
     * Each have a 10x10 board
     * During setup, players can place an arbitrary number of “battleships” on their board. 
     * The ships are 1-by-n sized, must fit entirely on the board, and must be aligned either vertically or horizontally.
     * During play, players take turn “attacking” a single position on the opponent’s board, and the opponent must respond by either reporting a “hit” on one of their battleships (if one occupies that position) or a “miss”
     * A battleship is sunk if it has been hit on all the squares it occupies
     * A player wins if all of their opponent’s battleships have been sunk. 
     * 
     * #BATTLESHIP TASK#
     * Create a board
     * Add a battleship to the board
     * Take an “attack” at a given position, and report back whether the attack resulted in a hit or a miss
     * Return whether the player has lost the game yet (i.e. all battleships are sunk)
     * 
     * #NOTE#
     * Readability
     * Maintainability
     * Testability
     * Extensibility 
     */


    class BattleShipStateTracker
    {
        private static List<string> Help = new List<string>();
        private static bool[,] Board = new bool[10, 10]; //10x10 board
        private static List<Battleship> Battleships = new List<Battleship>();
        private static List<Player> Players = new List<Player>();
        private static int counter { get; set; }

        private static bool isGameOver;

        public static void Main(string[] args)
        {
            isGameOver = false;
            InitBattleships();
            InitPlayers();
            InitHelp();
            
            Console.WriteLine("Game has been setup successfully");

            //Console.WriteLine("Type 'help' for more information on battleships...");

            //random number between 1 and length of battleships
            Random rand = new Random();
            int random = rand.Next(1, Battleships.Capacity);
            Console.WriteLine("Number of ships to be placed by each player: " + random);
            counter = 0;

            foreach (Player player in Players)
            {
                while (counter < random)
                {
                    counter++;
                    Console.WriteLine(player.name + ", please enter the name of a battleship to place...");
                    string ship = Console.ReadLine();

                    //nullable operator instead?
                    if(Battleships.FirstOrDefault(obj => obj.name.Equals(ship)) != null)
                    {
                        Battleship selectedShip = Battleships.First(obj => obj.name.Equals(ship));

                        Console.WriteLine(player.name + ", please enter two coordinate's to place a ship...");

                        //TODO: replace with tuple
                        Console.WriteLine("Position 1:");
                        Console.Write("x:");
                        int x1 = Int32.Parse(Console.ReadLine().Split(':')[0]);
                        Console.Write("y:");
                        int y1 = Int32.Parse(Console.ReadLine().Split(':')[0]);

                        Console.WriteLine("Position 2:");
                        Console.Write("x:");
                        int x2 = Int32.Parse(Console.ReadLine().Split(':')[0]);
                        Console.Write("y:");
                        int y2 = Int32.Parse(Console.ReadLine().Split(':')[0]);

                        int length = (x2 - x1) * (y2 - y1);

                        //Ship to board validation
                        //if (x > 0 && y == 1 || x == 1 & y > 0)
                        //{
                        if (length == selectedShip.width * selectedShip.height)
                        {
                            
                        }
                        else
                        {
                           Console.WriteLine("Please make sure the x and y coordinates adhere to width " + selectedShip.width + " and height " + selectedShip.height);

                        }
                        //}
                        //else
                        //{
                        //    Console.WriteLine("Ships need to be 1-n sized, either horizontal or verticle");
                        //}
                    }
                    else
                    {
                        Console.WriteLine("Ship not found, please try again...");
                        counter--;
                    }
                }
                counter = 0;
            }

            while (!isGameOver)
            {
                foreach (Player player in Players)
                {
                    Console.WriteLine(player.name + ", please select a coordinate to attack...");

                    Console.Write("x: ");
                    string x = Console.ReadLine().Split(':')[0];
                    Console.Write("y: ");
                    string y = Console.ReadLine().Split(':')[0];

                    string line = Console.ReadLine();
                }
            }
            
            //if (help.Equals("help"))
            //{
            //   Console.WriteLine(string.Join("", Help.ToArray()));
            //}

        }

        private static void SetShipToBoard(int x, int y)
        {
            for(int i = 0; Board.GetLength(0) > i; i++)
            {
                for(int j = 0; Board.GetLength(1) > j; j++)
                {
                    if(x == i && y == j)
                    {
                        Board[i, j] = true;
                    }
                }
            }
        }

        private static void InitBattleships()
        {
            Battleships.Add(new Battleship
            {
                name = "Destroyer",
                xPos = 0,
                yPos = 0,
                width = 1,
                height = 6,
                isDestroyed = false
            });


            Battleships.Add(new Battleship
            {
                name = "Cruiser",
                xPos = 0,
                yPos = 0,
                width = 5,
                height = 1,
                isDestroyed = false
            });

            Battleships.Add(new Battleship
            {
                name = "Scout",
                xPos = 0,
                yPos = 0,
                width = 1,
                height = 2,
                isDestroyed = false
            });
        }

        private static void InitPlayers()
        {
            Players.Add(new Player
            {
                battleships = Battleships,
                name = "Player One"
            });

            Players.Add(new Player
            {
                battleships = Battleships,
                name = "Player Two"
            });
        }

        private static void InitHelp()
        {
            Help.Add("Battleship information: \n");

            foreach(Battleship battleship in Battleships)
            {
                Help.Add(battleship.name + " - width: " + battleship.width + " height: " + battleship.height + "\n");
            }
        }
    }
}
