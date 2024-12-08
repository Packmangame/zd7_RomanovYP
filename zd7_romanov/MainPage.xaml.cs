using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace zd7_romanov
{
    public partial class MainPage : ContentPage
    {
        string srokIspoln = "";
        public MainPage(double Price,string SrokIspoln)  
        {
            srokIspoln=SrokIspoln;
            
            InitializeComponent();

            

            this.FindByName<Entry>("adres").Text=Preferences.Get("Adres", string.Empty);
            this.FindByName<Entry>("PhoneNumb").Text=Preferences.Get("PN", string.Empty);
            this.FindByName<Entry>("oklad").Text=Preferences.Get("O", string.Empty);
            this.FindByName<Entry>("MarkAvto").Text=Preferences.Get("MA", string.Empty);
            this.FindByName<Entry>("FIO").Text=Preferences.Get("FIO", string.Empty);
            this.FindByName<Entry>("WIN").Text=Preferences.Get("WIN", string.Empty);
            this.FindByName<Entry>("Probeg").Text=Preferences.Get("P", string.Empty);
            this.FindByName<Label>("SrokIspoln").Text=Preferences.Get("SI", string.Empty);
            this.FindByName<Label>("Price").Text=Preferences.Get("Price", string.Empty);


            if (Price == 0 && SrokIspoln == "")
            {
                this.FindByName<Label>("Price").Text = "0 руб.";
                this.FindByName<Label>("SrokIspoln").Text = "0 дней";
            }
            else
            {
                this.FindByName<Label>("Price").Text = $"{Price} руб.";
                this.FindByName<Label>("SrokIspoln").Text = $"{SrokIspoln} дней";
            }
            var a = this.FindByName<Picker>("items");
            a.SelectedIndex = 0;
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
            int intdex= this.FindByName<Picker>("items").SelectedIndex;
            string markAvto= this.FindByName<Entry>("MarkAvto").Text;

            if (string.IsNullOrEmpty(markAvto) || intdex < 0 || intdex > 4 || string.IsNullOrEmpty(this.FindByName<Entry>("oklad").Text))
            {
                DisplayAlert("Error", "Заполните поля", "OK");
            }
            else
            { 
                    ListAdd();
                    int oklad = int.Parse(this.FindByName<Entry>("oklad").Text);

                    await Navigation.PushAsync(new Button1(intdex, markAvto, oklad));

            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (srokIspoln == "")
            {
                if (!string.IsNullOrEmpty(this.FindByName<Entry>("oklad").Text))
                {

                        ListAdd();
                        int oklad = int.Parse(this.FindByName<Entry>("oklad").Text);
                        await Navigation.PushAsync(new Button2(1, oklad));

                }
                else
                {
                    DisplayAlert("Error", "Заполните поле оклад", "OK");
                }
            }
            else {
                if (!string.IsNullOrEmpty(this.FindByName<Entry>("oklad").Text))
                {

                        ListAdd();
                        int oklad = int.Parse(this.FindByName<Entry>("oklad").Text);
                        await Navigation.PushAsync(new Button2(Convert.ToInt32(srokIspoln), oklad));

                }
                else
                {
                    DisplayAlert("Error", "Заполните поле оклад", "OK");
                }

            }
        }
        private void ListAdd()
        {
            Preferences.Set("GodVip", this.FindByName<DatePicker>("GodVip").Date);
            Preferences.Set("Adres",this.FindByName<Entry>("adres").Text);
            Preferences.Set("PN", this.FindByName<Entry>("PhoneNumb").Text);
            Preferences.Set("O", this.FindByName<Entry>("oklad").Text);
            Preferences.Set("MA", this.FindByName<Entry>("MarkAvto").Text);
            Preferences.Set("FIO", this.FindByName<Entry>("FIO").Text);
            Preferences.Set("WIN", this.FindByName<Entry>("WIN").Text);
            Preferences.Set("P", this.FindByName<Entry>("Probeg").Text);
            Preferences.Set("DS", this.FindByName<DatePicker>("dateStart").Date.ToString());
            Preferences.Set("DE", this.FindByName<DatePicker>("dateEnd").Date.ToString());
            Preferences.Set("SI", this.FindByName<Label>("SrokIspoln").Text);
            Preferences.Set("Price", this.FindByName<Label>("Price").Text);
        }
    }
}
