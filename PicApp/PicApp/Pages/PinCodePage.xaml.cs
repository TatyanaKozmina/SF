using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PicApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinCodePage : ContentPage
    {
        public PinCodePage()
        {
            InitializeComponent();
        }

        private async void Enter_Click(object sender, EventArgs e)
        {
            wrongPIN.Text = String.Empty;
            string wrongPINText = "Некорректный ПИН код";

            if (Preferences.ContainsKey("pin1"))
            {
                if (Preferences.Get("pin1", string.Empty) != pin1.Text ||
                   Preferences.Get("pin2", string.Empty) != pin2.Text ||
                   Preferences.Get("pin3", string.Empty) != pin3.Text ||
                   Preferences.Get("pin4", string.Empty) != pin4.Text)
                    wrongPIN.Text = wrongPINText;
                else
                    await Navigation.PushAsync(new PicListPage());
            }
            else
            {
                List<string> pins = new List<string> { pin1.Text, pin2.Text, pin3.Text, pin4.Text };
                if (pins.Where(p => String.IsNullOrEmpty(p)).Any())
                    wrongPIN.Text = wrongPINText;
                else
                {
                    // Сохраним значения пин кода
                    Preferences.Set("pin1", pin1.Text);
                    Preferences.Set("pin2", pin2.Text);
                    Preferences.Set("pin3", pin3.Text);
                    Preferences.Set("pin4", pin4.Text);
                    await Navigation.PushAsync(new PicListPage());
                }
            }
        }

        protected override void OnAppearing()
        {
            if (Preferences.ContainsKey("pin1"))
            {
                labelSetPIN.Text = "Введите ПИН код";
                buttonSetPIN.Text = "Ввод";
            }
            else
            {
                labelSetPIN.Text = "Установите ПИН код";
                buttonSetPIN.Text = "Установить";
            }

            base.OnAppearing();
        }
    }
}