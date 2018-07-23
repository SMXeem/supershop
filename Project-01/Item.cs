using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_01
{
    public class Item
    {
        public int ComID { get; set; }
        public int CatID { get; set; }
        public string ItemName { get; set; }
        public int ReorderLevel { get; set; }
        public int ID { get; set; }
        public int AvilableQuantity { get; set; }
    }
}