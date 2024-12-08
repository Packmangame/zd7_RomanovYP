using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd7_romanov
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage= new NavigationPage(new MainPage(0,""));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
