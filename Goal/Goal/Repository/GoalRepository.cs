using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Goal.Repository
{
    public class GoalRepository
    {
        SQLiteConnection database;
        static object locker = new object();

        public GoalRepository(string filename)
        {
            try
            {
                string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath(filename);
                database = new SQLiteConnection(databasePath);
                database.CreateTable<Model.Goal>();
            }
            catch (Exception)
            {
                database = new SQLiteConnection(filename);
                database.CreateTable<Model.Goal>();
            }
        }

        public IEnumerable<Model.Goal> GetItems()
        {
            return database.Table<Model.Goal>().ToList();
        }

        public Model.Goal GetItem(int id)
        {
            return database.Get<Model.Goal>(id);
        }

        public int DeleteItem(int id)
        {
            return database.Delete<Model.Goal>(id);
        }

        public int SaveItem(Model.Goal item)
        {
            return database.Insert(item);
        }

        public int UpdateItem(Model.Goal goal)
        {
            return database.Update(goal);
        }
    }
}
