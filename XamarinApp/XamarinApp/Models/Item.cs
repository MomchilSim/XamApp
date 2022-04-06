using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Media.Abstractions;
using SQLite;
namespace XamarinApp.Models
{
    public class Item
    {
       
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LongDescription { get; set; }
        public MediaFile Image { get; set; }
        public string Quantity { get; set; }
        public string TypeOfQuantity { get; set; }
    }
}

