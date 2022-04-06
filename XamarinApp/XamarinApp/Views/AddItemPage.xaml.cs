using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.ViewModels;

namespace XamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        public AddItemPage()
        {
            InitializeComponent();
            BindingContext = new ItemAddViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
             DisplayAlert("Alert", "Item has been Created", "OK");
        }
    }
}