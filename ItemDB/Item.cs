using System;

namespace ItemDB
{
    public partial class Item
    {
        //public int ItemId { get; set; }
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public double PricePerItem { get; set; }
        public int QuantityOnHand { get; set; }
        public double OurCostPerItem { get; set; }
        public double TotalItemsValue { get; set; }

        //not sure if the following is correct?
        public DateTime ItemCreatedDate { get; set; }
    }
}
