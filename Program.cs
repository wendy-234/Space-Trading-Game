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
            var goods = new List<Goods>();
            double time = 0;
            int currentWorld = 0;


            createGalaxy(planets);
            createInventory(goods);

            do
            {
                currentWorld = MovePlanets(planets, currentWorld);

            } while (time <= 65.0);




        }

        private static int MovePlanets(List<World> planets, int currentWorld)
        {
            var nextWorld = NextWorld(planets);

            if (nextWorld >= 0)
            {
                Console.WriteLine($"You found planet {planets[nextWorld].Name}.");
            }
            else
            {
                Console.WriteLine("No planet was found");
            }
            Console.Write("The distance bewteen these planets is: ");
            Console.WriteLine(planets[nextWorld].DistanceTo(planets[currentWorld]));

            currentWorld = nextWorld;
            return currentWorld;
        }

        private static void createGalaxy(List<World> planets)
        {
            planets.Add(new World(0.0, 0.0, "Alderaan"));
            planets.Add(new World(100.0, 100.0, "Naboo"));
            planets.Add(new World(-200.0, 50.0, "Tatooine"));
            planets.Add(new World(-400.0, -50.0, "Hoth"));
            planets.Add(new World(320.0, -800.0, "Dagobah"));
        }
        private static void createInventory(List<Goods> goods )
        {
            goods.Add(new Goods(50.0, "Textiles"));
            goods.Add(new Goods(60.0, "Food"));
            goods.Add(new Goods(150.0, "Weapons"));
            goods.Add(new Goods(75.0, "Ores"));
            goods.Add(new Goods(100.0, "Energy"));
        }

        public static int NextWorld(List<World> planets)
        {
            Console.WriteLine("Which planet do you want to go to?");
            var nextPlanet = Console.ReadLine();

            return planets.FindIndex(w => w.Name == nextPlanet);
        }
    }
}
