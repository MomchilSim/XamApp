using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Models;
using XamarinApp.Services;

namespace XamarinApp.ViewModels
{
    public class ViewModelBase : BaseViewModel
    {
         public ObservableRangeCollection<Item> Items { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public ViewModelBase()
        {
            Title = "Item Page";
            Items = new ObservableRangeCollection<Item>();
            RefreshCommand = new AsyncCommand(Refresh);
        }
         public async Task Refresh()
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
