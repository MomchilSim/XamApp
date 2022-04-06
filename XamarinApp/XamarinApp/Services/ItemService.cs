using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;
using System.Threading.Tasks;
using Xamarin.Essentials;
using XamarinApp.Models;
using Plugin.Media.Abstractions;

namespace XamarinApp.Services
{
    public static class ItemService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            //creats Database if it doesnt exist
            if (db != null)
                return; 

            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "Mydata.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Item>();
        }
        //adds item to database
        public static async Task AddItem(string Name, string Description, string LongDescription, string Quantity, string TypeOfQuantity, MediaFile image)
        {
            await Init();
            var item = new Item
            {
                Name = Name,
                LongDescription = LongDescription,
                Description = Description,
                Quantity = Quantity,
                TypeOfQuantity = TypeOfQuantity,
                Image = image
            };
            await db.InsertAsync(item);

        }
        //removes item from database
        public static async Task RemoveItem(int id)
        {
            await Init();
            await db.DeleteAsync<Item>(id);

        }
        public static async Task EditItem(Item item, int Num)
        {
            await Init();
            Item Temp = item;   
            
            
            switch (Num)
            {
              case 1: Temp.Name = await App.Current.MainPage.DisplayPromptAsync("Name of Item", "Name"); break;
              case 2: Temp.Description = await App.Current.MainPage.DisplayPromptAsync("Description of Item", "Descrription"); break;
              case 3: Temp.Quantity = await App.Current.MainPage.DisplayPromptAsync("Quanitity of Item", "Quantity"); break;
              case 4: Temp.TypeOfQuantity = await App.Current.MainPage.DisplayPromptAsync("Type of quantity of Item", "Type"); break;
            }
            Temp.Id = item.Id;
            await db.DeleteAsync(item);
            await db.InsertAsync(Temp);
       
        }
        //gets all the Items from Db
       public static async Task<IEnumerable<Item>> GetItems()
        {
            await Init();
            var item = await db.Table<Item>().ToListAsync();
            return item;

        }
    }
}
