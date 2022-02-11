using controlefinanceiro_app.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace controlefinanceiro_app.Views
{
    public partial class DespesaDetailPage : ContentPage
    {
        public DespesaDetailPage()
        {
            InitializeComponent();
            BindingContext = new DespesasDetailViewModel();
        }
    }
}