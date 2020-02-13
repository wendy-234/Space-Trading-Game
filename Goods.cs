using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars_Trading_Game
{
    class Goods
    {
        public double price;
        public string name { get; set; }

        public Goods(double price, string name)
        {
            this.price = price;
            this.name = name;
        }


    }
}
