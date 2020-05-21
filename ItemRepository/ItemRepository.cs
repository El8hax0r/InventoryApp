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
        public string ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public string PricePerItem { get; set; }
        public string QuantityOnHand { get; set; }
        public int OurCostPerItem { get; set; }
        public string TotalItemsValue { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }

    public class ItemRepository //Maps to the database table Item(s?)
    {
        public ItemModel Add(ItemModel ItemModel)
        {
            var itemDb = ToDbModel(ItemModel);

            DatabaseManager.Instance.Items.Add(itemDb);
            DatabaseManager.Instance.SaveChanges();

            ItemModel = new ItemModel
            {
                OurCostPerItem = (int)itemDb.OurCostPerItem,
                //CreatedDate = itemDb.ItemCreatedDate, not sure what to do with this
                ItemDescription =itemDb.Description,
                Id = itemDb.ItemId,
                ItemNumber = itemDb.ItemNumber.ToString(),
                TotalItemsValue = itemDb.TotalItemsValue.ToString(),
                QuantityOnHand = itemDb.QuantityOnHand.ToString(),
                PricePerItem = itemDb.PricePerItem.ToString()
            };
            return ItemModel;
        }

        public List<ItemModel> GetAll()
        {
            // Use .Select() to map the database items to ItemModel
            var items = DatabaseManager.Instance.Items
              .Select(t => new ItemModel
              {
                  OurCostPerItem = (int)t.OurCostPerItem,
                  //CreatedDate = t.CreatedDate, not sure what to do with this?
                  ItemDescription = t.Description,
                  Id = t.ItemId,
                  ItemNumber = t.ItemNumber.ToString(),
                  TotalItemsValue = t.TotalItemsValue.ToString(),
                  QuantityOnHand = t.QuantityOnHand.ToString(),
                  PricePerItem = t.PricePerItem.ToString(),
              }).ToList();

            return items;
        }

        public bool Update(ItemModel ItemModel)
        {
            var original = DatabaseManager.Instance.Items.Find(ItemModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(ItemModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int itemId)
        {
            var items = DatabaseManager.Instance.Items
                                .Where(t => t.ItemId == itemId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Items.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Item ToDbModel(ItemModel ItemModel)
        {
            var contactDb = new Item
            {
                OurCostPerItem = ItemModel.OurCostPerItem,
                //ContactCreatedDate = ItemModel.CreatedDate, not sure what to do with this
                Description = ItemModel.ItemDescription,
                ItemId = ItemModel.Id,
                ItemNumber = Convert.ToInt32(ItemModel.ItemNumber),
                TotalItemsValue = Convert.ToDouble(ItemModel.TotalItemsValue),
                QuantityOnHand = Convert.ToInt32(ItemModel.QuantityOnHand),
                PricePerItem = Convert.ToDouble(ItemModel.PricePerItem),
            };

            return contactDb;
        }
    }
}
