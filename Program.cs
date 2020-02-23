using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Net.Mime;
using System.Threading;


namespace Star_Wars_Trading_Game
{
    class Program
    {
       
        

        static void Main(string[] args)
        {
            new Main_Menu().Header();

            var planets = new List<World>();
            var inventory = new List<Goods>();
            int currentWorld = 0;
            double currentTime = 18;        // Years
            double currentMoney = 500.0;    // Imperial Credits
            bool loanPaid = false;          // Loan is not paid off yet

            (int, double, double, bool) currentState = (currentWorld, currentTime, currentMoney, loanPaid);

            CreateGalaxy(planets);
            CreateInventory(inventory);

            DisplayPlanets(planets, currentState);
            currentState = MovePlanets(planets, currentState);
            
            do
            {
                //DisplayPlanets(planets, currentState);

                Console.WriteLine("\t \t \t \t \t \t \t \t Hoth \n");
                Console.WriteLine("\t \t \t \t Naboo");
                Console.WriteLine("\n \n \t \t \t \t \t \t Alderaan \n");
                Console.WriteLine("\t \t \t \t \t \t \t \t \t \t \t Tatooine \n \n");
                Console.WriteLine("Dagobah \n \n ");

                NewPrice(inventory, currentState);
                DisplayStats(planets, inventory, currentState);
                currentState = Actions(planets, inventory, currentState);

            } while (currentState.Item2 <= 83.0 || currentState.Item3 <= 2000000.0);

            // displayWorld(planets, inventory, currentState);
            EndCredits(currentState);
        }

        private static void ResetPrice(List<Goods> inventory)
        {
            inventory[0].Price = 50.0;
            inventory[1].Price = 60.0;
            inventory[2].Price = 150.0;
            inventory[3].Price = 75.0;
            inventory[4].Price = 100.0;
        }

        private static void DisplayPlanets(List<World> planets, (int, double, double, bool) currentState)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == currentState.Item1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(planets[i].Name);
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(planets[i].Name);
                }

            }
            Console.WriteLine();
        }

        private static void DisplayStats(List<World> planets, List<Goods> inventory, (int, double, double, bool) currentState)
        {
            Console.WriteLine($"You have arrived at {planets[currentState.Item1].Name}");
            Console.WriteLine($"Imperial Credits: {currentState.Item3}");
            Console.WriteLine($"Age: {currentState.Item2} \n");
            Console.WriteLine("Name : Quantity : Price:");

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{inventory[i].Name}: {inventory[i].Quantity} : {inventory[i].Price}");
            }
            Console.WriteLine();
        }

        private static void EndCredits((int, double, double, bool) currentState)
        {
            if (currentState.Item2 > 83.0 && currentState.Item4 == false)
            {
                Console.WriteLine("You have been executed for failing to pay off your loan");
            }
            else if (currentState.Item2 > 83.0 && currentState.Item4 == true)
            {
                Console.WriteLine("You have failed to reach your retirment goal and will continue to work until the day you die.");
            }
            else if (currentState.Item3 > 2000000.0)
            {
                Console.WriteLine("You have made enough money to retire on Earth, hapily ever after");
            }
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
                Console.Clear();

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
                Console.Clear();

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
                Console.Clear();

                if (inventory[temp].Quantity > 0)
                {
                    currentState.Item3 += inventory[temp].Quantity * inventory[temp].Price;
                    inventory[temp].Quantity = 0;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("You do not have any of this item in your inventory \n"); 
                }
            }
            else if (input == 3)
            {
                currentState = MovePlanets(planets, currentState);
                currentState = RandomEvent(currentState);

            }
            else if(input == 4 && currentState.Item3 > 500000.0)
            {
                currentState.Item3 -= 500000.0;
                currentState.Item4 = true;

                Console.Clear();
                Console.WriteLine("You just paid off your loan! \n");
            }
            else if (input == 4 && currentState.Item3 <= 500000.0)
            {
                Console.Clear();
                Console.WriteLine("You don't have enough Imperial Credits to do this! \n");
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

        // I want to set these once and then leave them alone... 
        private static (int, double, double, bool) NewPrice(List<Goods> inventory, (int, double, double, bool) currentState)  
        {   
            ResetPrice(inventory);

            int i;
            for (i = 0; i < 5; i++)
            {
                if (currentState.Item1 == 0)
                {
                    inventory[i].Price = inventory[i].Price;
                }
                else if (currentState.Item1 == 1)
                {
                    inventory[i].Price *= 1.5;
                }
                else if (currentState.Item1 == 2)
                {
                    inventory[i].Price *= 5;
                }
                else if (currentState.Item1 == 3)
                {
                    inventory[i].Price *= 2.5;
                }
                else if (currentState.Item1 == 4)
                {
                    inventory[i].Price *= 3;
                }
            }
            return currentState;
            
        }

        public static (int, double, double, bool) MovePlanets(List<World> planets, (int, double, double, bool) currentState)
        {
            var nextWorld = NextWorld(planets);
            
            if (nextWorld >= 0)
            {
               // Console.WriteLine($"You arrived at {planets[nextWorld].Name}.");
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
