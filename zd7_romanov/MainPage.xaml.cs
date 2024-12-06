using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace zd7_romanov
{
    public partial class MainPage : ContentPage
    {
        Dictionary<string,string> services;

        public MainPage()
        {
            InitializeComponent();
            var a = this.FindByName<Picker>("items");
            a.Items.Add("Замена масла");
            a.Items.Add("Замена шин");
            a.Items.Add("Чистка корбюратора");
            a.Items.Add("Ремонт коробки передач");
            a.Items.Add("Замена ДВС");
        }

        private void items_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var a = this.FindByName<Picker>("items");
            a.TextColor = Color.Black;
            switch (a.SelectedIndex)
            {
                case 0:
                    Image.Source = "maslo.jpg";
                    break;
                case 1:
                    Image.Source = "shini.jpg";
                    break;
                case 2:
                    Image.Source = "korb.jpg";
                    break;
                case 3:
                    Image.Source = "korobka.jpg";
                    break;
                case 4:
                    Image.Source = "dvs.jpg";
                    break;
                default:
                    DisplayAlert("Error","Выбирите 1 из вариантов","OK");
                    break;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Button1());
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Button2());
        }
    }
}
