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
        public int Id { get; set; }
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

            DatabaseManager.Instance.Item.Add(itemDb);
            DatabaseManager.Instance.SaveChanges();

            itemModel = new ItemModel
            {
                OurCostPerItem = itemDb.OurCostPerItem,
                CreatedDate = itemDb.ItemCreatedDate, //not sure what to do with this
                ItemDescription = itemDb.ItemDescription, //this should be "Description = "
                Id = itemDb.ItemId,
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
            var items = DatabaseManager.Instance.Item
              .Select(t => new ItemModel
              {
                  OurCostPerItem = t.OurCostPerItem,
                  //CreatedDate = t.ItemCreatedDate, //not sure what to do with this?
                  ItemDescription = t.ItemDescription,
                  Id = t.ItemId,
                  ItemNumber = t.ItemNumber,
                  TotalItemsValue = t.TotalItemsValue,
                  QuantityOnHand = t.QuantityOnHand,
                  PricePerItem = t.PricePerItem,
              }).ToList();

            return items;
        }

        public bool Update(ItemModel itemModel)
        {
            var original = DatabaseManager.Instance.Item.Find(itemModel.Id);

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
            var items = DatabaseManager.Instance.Item                   //will this var need to be renamed?? it's also "items" in examples...
                                .Where(t => t.ItemId == itemId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Item.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Item ToDbModel(ItemModel itemModel)
        {
            var itemDb = new Item
            {
                OurCostPerItem = itemModel.OurCostPerItem, //doc says these should all be "itemModel."
                ItemCreatedDate = itemModel.CreatedDate,
                ItemDescription = itemModel.ItemDescription,
                ItemId = itemModel.Id,
                ItemNumber = itemModel.ItemNumber,
                TotalItemsValue = itemModel.TotalItemsValue,
                QuantityOnHand = itemModel.QuantityOnHand,
                PricePerItem = itemModel.PricePerItem,
            };

            return itemDb;
        }
    }
}
