using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Transactions;
using Star_Wars_Trading_Game;

public class Main_Menu
{

    

    public void Run()
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        bool run = true;
        List<(string, int)> tradingGame = new List<(string, int)>();

        Planet currentPlanet = Galaxy.Alderan;

        Console.Clear();
        //Display header first
        Header();
        Console.Write("\nPress any key to continue...");
        _ = Console.ReadKey();

        while (run)
        {
            Console.Clear();
            currentPlanet.Display();

            //Displays planet names
            Listofplanets(tradingGame);
            
            //Main menu
            Menu(tradingGame);


            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    currentPlanet = Galaxy.Alderan;
                    break;
                case ConsoleKey.D2:
                    currentPlanet = Galaxy.Naboo;
                    break;
                case ConsoleKey.D3:
                    currentPlanet = Galaxy.Tatooine;
                    break;
                case ConsoleKey.D4:
                    currentPlanet = Galaxy.Hoth;
                    break;
                case ConsoleKey.D5:
                    currentPlanet = Galaxy.Dagobah;
                    break;
            }
        }


        void Header()
        {
            Console.WriteLine(
                "######################################################################################\n");
            Console.WriteLine("\t\t\t\t\tWELCOME TO  \n ");
            Console.WriteLine(@" 
           ______   __   __   ____
          |__  __| |  | |  | |  __|
            | |    |  |_|  | |  |_ 
            | |    |   _   | |   _|   ____   _____   ___    _____   __  __   __  __ 
            | |    |  | |  | |  |_   / ___| | ___ |  | |   | ___ | |  ||  | |  ||  |
            |_|    |__| |__| |____| | |  __ | |_| |  | |   | |_| | |  \/  | |  \/  |
                                    | | |_ ||  _  |  | |   |  _  |  \    /   \    / 
                                    | |___||| | | |  | |__ | | | |  / /\ \    |  |  
             ______  _____  _____   |______||_| |_|  |____||_| |_| |__||__|   |__|  
            |    __|| ___ ||  __ \
            |   |__ | |_| || |_|  |
            |    _| |  _  ||  _  /     ______  _____  _____   
            |   |   | | | || | | |    |    __|| ___ ||  __  \ 
            |___|   |_| |_||_| |_|    |   |__ | |_| || |_|  | 
                                      |    _| |  _  ||  _  /  
                                      |   |   | | | || | | |  
                                      |___|   |_| |_||_| |_|   
                   _____  ___        ___  _____  __  __       
                  | ___ ||   |      |   || ___ ||  ||  |
                  | |_| ||   | ____ |   || |_| ||  \/  |
                  |  _  |\   \ |  | /   /|  _  | \    / 
                  | | | | \   \/  \/   / | | | |  |  |  
                  |_| |_|  \____/\____/  |_| |_|  |__|");



        }

        void Listofplanets(List<(string, int)> trading)
        {
            Console.WriteLine(
                "#######################################################################################\n\n");
            Console.WriteLine("Key Map: \n\n" +
                              " 1 Alderan\n" +
                              " 2 Naboo \n" +
                              " 3 Tatooine\n" +
                              " 4 Hoth\n" +
                              " 5 Dagobah\n");

        }
        void Menu(List<(string, int)> trading, ConsoleKey action = 0, int page = 1)
        {

            Console.WriteLine("Current Age: ");

            Console.WriteLine(
                "\n\nChoose from the following: Press 1 - To buy, 2 - To sell ");
            Console.WriteLine(
                "#######################################################################################\n\n");
        }



    }


}
