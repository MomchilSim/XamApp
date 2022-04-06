using MvvmHelpers.Commands;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinApp.Services;

namespace XamarinApp.ViewModels
{
    internal class ItemAddViewModel : ViewModelBase
    {
        public string Name { get; set; }
        public string ShDesc { get; set; }
        public string LgDesc { get; set; }
        public string Qty { get; set; }
        public MediaFile Image { get; set; }
        public string TypeOfQty { get; set; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand PicCommand { get; }
        public ItemAddViewModel()
        {
            AddCommand = new AsyncCommand(Add);
            PicCommand = new AsyncCommand(Pic);
        }
        async Task Add()
        {
            var name = Name;
            var description = ShDesc;
            var longdescription = LgDesc;
            var qty = Qty;
            var typeofqty = TypeOfQty;
            var image = Image;
            await ItemService.AddItem(name, description, longdescription, qty, typeofqty, image);
            Name = ShDesc = LgDesc = Qty = TypeOfQty = null;

        }
        async Task Pic()
        {
            var photo = await CrossMedia.Current.TakePhotoAsync(
                  new StoreCameraMediaOptions
                  {
                      SaveToAlbum = true
                  });
            Image = photo;
        }
    }
}
