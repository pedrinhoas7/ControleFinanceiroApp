using controlefinanceiro_app.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace controlefinanceiro_app.Views
{
    public partial class ReceitasDetailPage : ContentPage
    {
        public ReceitasDetailPage()
        {
            InitializeComponent();
            BindingContext = new ReceitasDetailViewModel();
        }
    }
}