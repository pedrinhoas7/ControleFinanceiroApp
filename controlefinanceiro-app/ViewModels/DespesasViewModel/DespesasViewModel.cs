using controlefinanceiro_app.Models;
using controlefinanceiro_app.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace controlefinanceiro_app.ViewModels
{
    public class DespesasViewModel : DespesaBaseViewModel
    {
        private Despesa _selectedItem;

        public ObservableCollection<Despesa> Despesas { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Despesa> ItemTapped { get; }

        public DespesasViewModel()
        {
            Title = "Despesas";
            Despesas = new ObservableCollection<Despesa>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Despesa>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Despesas.Clear();
                var items = await DataStore.GetDespesasAsync(true);
                foreach (var item in items)
                {
                    Despesas.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Despesa SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewDespesaPage));
        }

        async void OnItemSelected(Despesa item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(DespesaDetailPage)}?{nameof(DespesasDetailViewModel.ItemId)}={item.Id}");
        }
    }
}