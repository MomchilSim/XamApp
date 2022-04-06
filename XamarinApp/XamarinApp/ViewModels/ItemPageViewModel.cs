using System;
using System.Linq; 
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmHelpers.Commands;
using MvvmHelpers;
using XamarinApp.Models;
using System.Threading.Tasks;
using XamarinApp.Services;
using Xamarin.Forms;

namespace XamarinApp.ViewModels
{
    public class ItemPageViewModel: ViewModelBase
    {
        public AsyncCommand<Item> SelectedCommand { get; }
        public new AsyncCommand RefreshCommand { get; }
        Item lastSelectedItem;
        public Item LastSelectedItem
        {
            get => LastSelectedItem;
            set => SetProperty(ref lastSelectedItem, value); 
        }
        public ItemPageViewModel()
        {
            Title = "Item Page";
            SelectedCommand = new AsyncCommand<Item>(Selected);
            RefreshCommand = new AsyncCommand(Refresh);
            Refresh();
        }
        async Task Selected(Item item)
        {
            if (item == null)
                return;
            await Application.Current.MainPage.DisplayAlert($"id: {item.Id}, {item.Name}", item.LongDescription, "Ok");
            await Refresh();
        }
       
      
    
        //refreshes page
        public new async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1500);
            Items.Clear();
            var items = await ItemService.GetItems();
            Items.AddRange(items);
            IsBusy = false;
        }

    }
}
