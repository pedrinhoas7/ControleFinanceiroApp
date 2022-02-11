using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace controlefinanceiro_app.ViewModels
{
    public class HomeViewModel : DespesaBaseViewModel
    {
        public HomeViewModel()
        {
            Title = "Home";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}