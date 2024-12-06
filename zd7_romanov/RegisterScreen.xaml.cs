using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd7_romanov
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterScreen : ContentPage
    {
        
        public RegisterScreen()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.FindByName<Entry>("log").Text) || !string.IsNullOrEmpty(this.FindByName<Entry>("pas").Text))
            {
                if (this.FindByName<Entry>("log").Text == "ects" && this.FindByName<Entry>("pas").Text == "ects2024")
                {
                    await Navigation.PushAsync(new MainPage()); 
                }
                else
                {
                    DisplayAlert("Error", "Логин или пароль введенны неправильно", "Ok");
                }

            } else
            {
                DisplayAlert("Error","Заполните поля","Ok");
            }

        }
    }

    
}