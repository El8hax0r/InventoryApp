﻿using System;

namespace ItemApp.Models
{
    public class ItemModel
    {
        //public int ItemId { get; set; }
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public double PricePerItem { get; set; }
        public int QuantityOnHand { get; set; }
        public double OurCostPerItem { get; set; }
        public double TotalItemsValue { get; set; }
        public DateTime CreatedDate { get; set; }

        public ItemRepository.ItemModel ToRepositoryModel()
        {
            var repositoryModel = new ItemRepository.ItemModel
            {
                OurCostPerItem = OurCostPerItem,
                CreatedDate = CreatedDate,
                ItemDescription = ItemDescription,
                //ItemId = ItemId,
                ItemNumber = ItemNumber,
                TotalItemsValue = TotalItemsValue,
                QuantityOnHand = QuantityOnHand,
                PricePerItem = PricePerItem
            };

            return repositoryModel;
        }

        public static ItemModel ToModel(ItemRepository.ItemModel respositoryModel)
        {
            var itemModel = new ItemModel
            {
                OurCostPerItem = respositoryModel.OurCostPerItem,
                CreatedDate = respositoryModel.CreatedDate,
                ItemDescription = respositoryModel.ItemDescription,
                //ItemId = respositoryModel.ItemId,
                ItemNumber = respositoryModel.ItemNumber,
                TotalItemsValue = respositoryModel.TotalItemsValue,
                QuantityOnHand = respositoryModel.QuantityOnHand,
                PricePerItem = respositoryModel.PricePerItem
            };

            return itemModel;
        }
    }
}
