using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;

namespace AcornQuest114
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    class Game
    {
        private List<string> inventory = new List<string>();
        private bool doorOpened = false;

        public void Start()
        {
            Console.WriteLine("Welcome to Acorn Quest!");
            while (!doorOpened)
            {
                Console.WriteLine("You are in a forest. Solve riddles to find a key and a map to open the door to the acorns.");
                Console.WriteLine("Choose an action: (1) Solve a riddle (2) Check inventory (3) Try to open the door");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        SolveRiddle();
                        break;
                    case "2":
                        CheckInventory();
                        break;
                    case "3":
                        TryToOpenDoor();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        private void SolveRiddle()
        {
            Dictionary<string, string> riddles = new Dictionary<string, string>
            {
                { "I speak without a mouth and hear without ears. I have no body, but I come alive with wind. What am I?", "echo" },
                { "I come from a mine and get surrounded by wood always. Everyone uses me. What am I?", "pencil" },
                { "I have keys but no locks. I have space but no room. You can enter, but you can't go outside. What am I?", "keyboard" }
            };

            Random random = new Random();
            int index = random.Next(riddles.Count);
            KeyValuePair<string, string> riddle = new KeyValuePair<string, string>(riddles.Keys.ElementAt(index), riddles.Values.ElementAt(index));

            Console.WriteLine($"Riddle: {riddle.Key}");
            string answer = Console.ReadLine().ToLower();

            if (answer == riddle.Value)
            {
                string foundObject = index == 0 ? "key" : "map";
                Console.WriteLine($"Correct! You found a {foundObject}!");

                if (!inventory.Contains(foundObject))
                {
                    inventory.Add(foundObject);
                    Console.WriteLine($"{foundObject} added to your inventory.");
                }
                else
                {
                    Console.WriteLine($"You already have a {foundObject}.");
                }
            }
            else
            {
                Console.WriteLine("Incorrect answer. Try again.");
            }
        }

        private void CheckInventory()
        {
            Console.WriteLine("Your inventory contains:");
            foreach (var item in inventory)
            {
                Console.WriteLine(item);
            }
        }

        private void TryToOpenDoor()
        {
            if (inventory.Contains("key") && inventory.Contains("map"))
            {
                Console.WriteLine("You used the key and the map to open the door. You found the acorns! You win!");
                doorOpened = true;
            }
            else
            {
                Console.WriteLine("You need both a key and a map to open the door.");
            }
        }
    }
}


