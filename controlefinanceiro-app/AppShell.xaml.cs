using controlefinanceiro_app.ViewModels;
using controlefinanceiro_app.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace controlefinanceiro_app
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ReceitasDetailPage), typeof(ReceitasDetailPage));
            Routing.RegisterRoute(nameof(DespesaDetailPage), typeof(DespesaDetailPage));
            Routing.RegisterRoute(nameof(NewReceitasPage), typeof(NewReceitasPage));
            Routing.RegisterRoute(nameof(NewDespesaPage), typeof(NewDespesaPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
