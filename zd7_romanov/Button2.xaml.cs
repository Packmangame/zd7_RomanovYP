using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zd7_romanov
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Button2 : ContentPage
	{
		public Button2 (int Srok, int Oklad)
		{
			/*HDS=20%*/
			InitializeComponent ();
			this.FindByName<Label>("Srok").Text = Srok.ToString() + " дн.";
			this.FindByName<Label>("Oklad").Text = Oklad.ToString() + " руб.";

			double NDS=Oklad*20/100;
			var s = this.FindByName<Label>("Skidka");
			if (Srok >= 1 && Srok <= 3)
			{
				s.Text = "40%";
                int skidka = Oklad * 40 / 100;
                double price = Oklad - skidka +NDS;
                this.FindByName<Label>("Stoim").Text = price.ToString() + " руб.";
            }
			else if (Srok >= 4 && Srok <= 6)
			{
				s.Text = "25%";
                int skidka = Oklad * 25 / 100;
                double price = Oklad - skidka + NDS;
                this.FindByName<Label>("Stoim").Text = price.ToString() + " руб.";
            }
			else if (Srok >= 20 && Srok <= 30)
			{
				s.Text = "-20%";
				int skidka = Oklad * 20 / 100;
				double price=Oklad+skidka+NDS;
                this.FindByName<Label>("Stoim").Text = price.ToString() + " руб.";
			}
		}


        private async void Button_Clicked_1(object sender, EventArgs e)
        {
			string stoim = this.FindByName<Label>("Stoim").Text;
			stoim = stoim.Substring(0, stoim.Length - 5);
			double ans=Convert.ToDouble(stoim);

            string srok = this.FindByName<Label>("Srok").Text;
			srok=srok.Substring(0, srok.Length - 4);
            await Navigation.PushAsync(new MainPage(ans, srok));
        }
    }
}