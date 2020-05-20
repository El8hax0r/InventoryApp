using System;
using System.Collections.Generic;
using System.Text;
using ItemDB;

namespace ItemRepository
{
    public static class DatabaseManager
    {
        private static readonly InventoryContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new InventoryContext();
        }

        // Provide an accessor to the database
        public static InventoryContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
