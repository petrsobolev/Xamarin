using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Goal.Repository
{
    public class TaskRepository
    {
        SQLiteConnection database;  
        public TaskRepository(string filename)
        {
            try
            {
                string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
                database = new SQLiteConnection(databasePath);
                database.CreateTable<Model.Task>();
            }
            catch (Exception)
            {   
                database = new SQLiteConnection(filename);
                database.CreateTable<Model.Task>();
            }
        }

        public IEnumerable<Model.Task> GetItems()
        {
            return database.Table<Model.Task>().ToList();
        }

        public Model.Task GetItem(int id)
        {
            return database.Get<Model.Task>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Model.Task>(id);
        }

        public int SaveItem(Model.Task item)
        {
            return database.Insert(item);
        }

        public int UpdateItem(Model.Task item)
        {
            return database.Update(item);
        }
    }
}
