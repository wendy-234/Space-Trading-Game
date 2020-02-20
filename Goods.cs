using System;
using System.Collections.Generic;
using System.Text;

namespace Star_Wars_Trading_Game
{

    class GoodsPrice
    {
        public double Price {get; set; }
        public int Quantity {get; set; }
        public string Name  {get; set; }

        public Goods(double price, int quantity, string name)
        {
            this.Price = price;
            this.Quantity = quantity;
            this.Name = name;
        }


    }
}
