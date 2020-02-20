using System;
using System.Collections.Generic;
using System.Drawing;

namespace Star_Wars_Trading_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var planets = new List<World>();
            var inventory = new List<Goods>();
            int currentWorld = 0;
            double currentTime = 18;
            double currentMoney = 500.0;
            bool loanPaid = false;

            (int, double, double, bool) currentState = (currentWorld, currentTime, currentMoney, loanPaid);

            CreateGalaxy(planets);
            CreateInventory(inventory);

            currentState = MovePlanets(planets, currentState);

            do
            {
                // displayWorld(planets, inventory, currentState);                
                // need to add highlighting to currentState.item1

                NewPrice(inventory, currentWorld);

                currentState = Actions(planets, inventory, currentState);

                Console.WriteLine(currentState.Item3);
                Console.WriteLine(inventory[1].Quantity);

            } while (currentState.Item2 <= 83.0);
            // displayWorld(planets, inventory, currentState);
            // console.writeline("You have been executed for failing to pay off your loan");



        }

        private static (int, double, double, bool) Actions(List<World> planets, List<Goods> inventory, (int, double, double, bool) currentState)
        {
            int input;
            if (currentState.Item4 == false)
            {
                Console.WriteLine("Buy: 1 | Sell: 2 | Travel: 3 | Pay Off Loan: 4");
                input = Convert.ToInt32(Console.ReadLine());
            }
            else
            {
                do
                {
                    Console.WriteLine("Buy: 1 | Sell: 2 | Travel: 3");
                    input = Convert.ToInt32(Console.ReadLine());
                    if(input != 1 && input != 2 && input != 3)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid choice");
                    }
                } while (input != 1 && input != 2 && input != 3);
            }


            

            if (input == 1) // Buy goods
            {
                Console.WriteLine("What item do you want to Buy? (Enter 1-5)");
                int temp = Convert.ToInt32(Console.ReadLine()) - 1;


                if (currentState.Item3 >= 10 * inventory[temp].Price)
                {
                    currentState.Item3 -= 10 * inventory[temp].Price;
                    inventory[temp].Quantity += 10;
                }
                else
                {
                    Console.WriteLine("You do not have enough Imperial Credits to buy this");
                }
            }
            else if (input == 2 && currentState.Item4 == false)  // Sell goods with 10% tax
            {
                Console.WriteLine("What item do you want to sell? (Enter 1-5)");
                int temp = Convert.ToInt32(Console.ReadLine()) - 1;

                if (inventory[temp].Quantity > 0)
                {
                    currentState.Item3 += inventory[temp].Quantity * inventory[temp].Price * 0.9;
                    inventory[temp].Quantity = 0;
                }
                else
                {
                    Console.WriteLine("You do not have any of this item in your inventory");
                }
            }

            else if (input == 2 && currentState.Item4 == true)  // Sell goods with no tax
            {
                Console.WriteLine("What item do you want to sell? (Enter 1-5)");
                int temp = Convert.ToInt32(Console.ReadLine()) - 1;

                if (inventory[temp].Quantity > 0)
                {
                    currentState.Item3 += inventory[temp].Quantity * inventory[temp].Price;
                    inventory[temp].Quantity = 0;
                }
                else
                {
                    Console.WriteLine("You do not have any of this item in your inventory");
                }
            }
            else if (input == 3)
            {
                currentState = MovePlanets(planets, currentState);
                currentState = RandomEvent(currentState);

            }
            else if(input == 4)
            {
                currentState.Item4 = true;
                
            }

            return currentState;
        }

        private static (int, double, double, bool) RandomEvent((int, double, double, bool) currentState)
        {
            Random rnd = new Random();
            double chance = rnd.Next(0, 10);

            if (chance >= 8.0)
            {
                currentState.Item3 *= 0.8;
                Console.WriteLine($"You were attacked by Ravengers and they stole {(currentState.Item3 / 4)} Imperial Credits! \n" );
            }

            return currentState;
        }
        private static List<Goods> NewPrice(List<Goods> inventory, int currentWorld)
        {
            for (int i = 0; i < 5; i++)
            {
                if (currentWorld == 0)
                {
                    inventory[i].Price = inventory[i].Price;
                }
                else if (currentWorld == 1)
                {
                    inventory[i].Price = 1.5 * inventory[i].Price;
                }
                else if (currentWorld == 2)
                {
                    inventory[i].Price = 5 * inventory[i].Price;
                }
                else if (currentWorld == 3)
                {
                    inventory[i].Price = 2.5 * inventory[i].Price;
                }
                else if (currentWorld == 4)
                {
                    inventory[i].Price = 3 * inventory[i].Price;
                }
            }
            return inventory;
        }
        public static (int, double, double, bool) MovePlanets(List<World> planets, (int, double, double, bool) currentState)
        {
            var nextWorld = NextWorld(planets);
            
            if (nextWorld >= 0)
            {
                Console.WriteLine($"You arrived at {planets[nextWorld].Name}.");
            }
            else
            {
                Console.WriteLine("No planet was found");
            }
            
            double distance = (planets[nextWorld].DistanceTo(planets[currentState.Item1]));  // in light years
            double timeTraveled = (distance / 10); // warp 10  -- The result will be in years     

            currentState.Item2 += timeTraveled;
            currentState.Item1 = nextWorld;

            //Console.WriteLine($"The distance bewteen these planets is: {distance} light years");
            //Console.WriteLine($"You are now {currentState.Item2} years old");

            return currentState;
        }
        public static int NextWorld(List<World> planets)
        {
            Console.WriteLine("Which planet do you want to go to?");
            var nextPlanet = Console.ReadLine();
            Console.Clear();

            return planets.FindIndex(w => w.Name == nextPlanet);
        }
        private static void CreateGalaxy(List<World> planets)
        {
            planets.Add(new World(0.0, 0.0, "Alderaan"));
            planets.Add(new World(1.0, 10.0, "Naboo"));
            planets.Add(new World(-2.0, 25.0, "Tatooine"));
            planets.Add(new World(-4.0, -5.0, "Hoth"));
            planets.Add(new World(3.2, -8.0, "Dagobah"));
        }
        private static void CreateInventory(List<Goods> inventory )
        {
            inventory.Add(new Goods(50.0, 10, "Textiles"));
            inventory.Add(new Goods(60.0, 10, "Food"));
            inventory.Add(new Goods(150.0, 10, "Weapons"));
            inventory.Add(new Goods(75.0, 10, "Ores"));
            inventory.Add(new Goods(100.0, 10, "Energy"));
        }

    }
}
