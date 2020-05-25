using System;
using System.Collections.Generic;
using System.Text;
using ItemDB;
using System.Linq;

namespace ItemRepository
{
    public class ItemModel //this opens the database - then abstracts to next layer
    {
        //these can all be abstracted but are explicit for readability
        public int ItemId { get; set; }
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public double PricePerItem { get; set; }
        public int QuantityOnHand { get; set; }
        public double OurCostPerItem { get; set; }
        public double TotalItemsValue { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }

    public class ItemRepository //Maps to the database table Item(s?)
    {
        public ItemModel Add(ItemModel itemModel)
        {
            var itemDb = ToDbModel(itemModel);

            DatabaseManager.Instance.Items.Add(itemDb);
            DatabaseManager.Instance.SaveChanges();

            itemModel = new ItemModel
            {
                OurCostPerItem = itemDb.OurCostPerItem,
                CreatedDate = itemDb.ItemCreatedDate,
                ItemDescription = itemDb.ItemDescription,
                ItemId = itemDb.ItemId,
                ItemNumber = itemDb.ItemNumber,
                TotalItemsValue = itemDb.TotalItemsValue,
                QuantityOnHand = itemDb.QuantityOnHand,
                PricePerItem = itemDb.PricePerItem
            };
            return itemModel;
        }

        public List<ItemModel> GetAll()
        {
            // Use .Select() to map the database items to ItemModel
            var things = DatabaseManager.Instance.Items
              .Select(t => new ItemModel
              {
                  OurCostPerItem = t.OurCostPerItem,
                  CreatedDate = t.ItemCreatedDate,
                  ItemDescription = t.ItemDescription,
                  ItemId = t.ItemId,
                  ItemNumber = t.ItemNumber,
                  TotalItemsValue = t.TotalItemsValue,
                  QuantityOnHand = t.QuantityOnHand,
                  PricePerItem = t.PricePerItem,
              }).ToList();

            return things;
        }

        public bool Update(ItemModel itemModel)
        {
            var original = DatabaseManager.Instance.Items.Find(itemModel.ItemId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(itemModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int itemId)
        {
            var things = DatabaseManager.Instance.Items //will this var need to be renamed?? it's also "items" in examples...
                                .Where(t => t.ItemId == itemId); //used to be "== ItemID or == Id"

            if (things.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Items.Remove(things.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Item ToDbModel(ItemModel itemModel)
        {
            var itemDb = new Item
            {
                OurCostPerItem = itemModel.OurCostPerItem,
                ItemCreatedDate = itemModel.CreatedDate,
                ItemDescription = itemModel.ItemDescription,
                ItemId = itemModel.ItemId,
                ItemNumber = itemModel.ItemNumber,
                TotalItemsValue = itemModel.TotalItemsValue,
                QuantityOnHand = itemModel.QuantityOnHand,
                PricePerItem = itemModel.PricePerItem,
            };

            return itemDb;
        }
    }
}
