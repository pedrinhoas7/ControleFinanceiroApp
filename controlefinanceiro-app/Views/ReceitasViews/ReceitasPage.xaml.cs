using controlefinanceiro_app.Models;
using controlefinanceiro_app.ViewModels;
using controlefinanceiro_app.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace controlefinanceiro_app.Views
{
    public partial class ReceitasPage : ContentPage
    {
        ReceitasViewModel _viewModel;

        public ReceitasPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ReceitasViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}