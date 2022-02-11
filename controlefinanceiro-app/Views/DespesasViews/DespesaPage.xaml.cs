

using controlefinanceiro_app.Models;
using controlefinanceiro_app.ViewModels ;
using Xamarin.Forms;

namespace controlefinanceiro_app.Views
{
    public partial class DespesaPage : ContentPage
    {
        DespesasViewModel _viewModel;

        public DespesaPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new DespesasViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}