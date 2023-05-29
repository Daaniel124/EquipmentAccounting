using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentAccounting.Models
{
    public class EquipmentRepository
    {
        SQLiteConnection database;
        public EquipmentRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Equipment>();
        }
        public IEnumerable<Equipment> GetItems()
        {
            return database.Table<Equipment>().ToList();
        }
        public Equipment GetItem(int id)
        {
            return database.Get<Equipment>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Equipment>(id);
        }
        public int SaveItem(Equipment item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
