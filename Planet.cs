using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Star_Wars_Trading_Game
{
    class Planet
    {
        public string planetName;
        public string planetImage;

        public void Display()
        {
            Console.WriteLine(planetName);
            Console.WriteLine(planetImage);
        }
    }
    
}
