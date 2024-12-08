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
	public partial class Button1 : ContentPage
	{
        int oklad = 0;
		public Button1 (int SelectedIndex, string MarkAvto,int Oklad=0)
		{
			InitializeComponent ();
            oklad = Oklad;
            var a = this.FindByName<Picker>("items");
            a.Items.Add("Замена масла");
            a.Items.Add("Замена шин");
            a.Items.Add("Чистка корбюратора");
            a.Items.Add("Ремонт коробки передач");
            a.Items.Add("Замена ДВС");

            Avto.Text = MarkAvto;
            this.FindByName<Picker>("items").SelectedIndex = SelectedIndex;
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
                    DisplayAlert("Error", "Выбирите 1 из вариантов", "OK");
                    break;
            }
        }

        private void Srok_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.Parse(this.FindByName<Entry>("Srok").Text) < 1 && (int.Parse(this.FindByName<Entry>("Srok").Text) > 30))
            {
                DisplayAlert("Error", "Скрок исполнения не может быть больше 30 дней и меньше 1 дня", "OK");
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            string srok = this.FindByName<Entry>("Srok").Text;
            if (!string.IsNullOrEmpty(srok))
            {
                await Navigation.PushAsync(new MainPage(0, srok));
            }
            else
            {
                DisplayAlert("Error", "Заполните поле", "OK");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            int srok = int.Parse(this.FindByName<Entry>("Srok").Text);
            await Navigation.PushAsync(new Button2(srok,oklad));
        }
    }
}