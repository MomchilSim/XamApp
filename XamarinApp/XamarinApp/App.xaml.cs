using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp.Views;

namespace XamarinApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}
