using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_01
{
    public class StockOut
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string companyName { get; set; }
        public int Quantity { get; set; }
        public string StockOutCategory { get; set; }
        public string Date { get; set; }
    }
}