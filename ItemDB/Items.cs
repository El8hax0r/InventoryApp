using System;
using System.Collections.Generic;

namespace ItemDB
{
    public partial class Items
    {
        public int ItemId { get; set; }
        public int ItemNumber { get; set; }
        public string Description { get; set; }
        public double PricePerItem { get; set; }
        public int QuantityOnHand { get; set; }
        public double OurCostPerItem { get; set; }
        public double? TotalItemsValue { get; set; }
    }
}
