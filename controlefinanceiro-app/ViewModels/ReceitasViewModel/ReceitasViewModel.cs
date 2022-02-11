using controlefinanceiro_app.Models;
using controlefinanceiro_app.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace controlefinanceiro_app.ViewModels
{
    public class ReceitasViewModel : ReceitaBaseViewModel
    {
        private Receita _selectedItem;

        public ObservableCollection<Receita> Receita { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Receita> ItemTapped { get; }

        public ReceitasViewModel()
        {
            Title = "Receitas";
            Receita = new ObservableCollection<Receita>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Receita>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Receita.Clear();
                var items = await DataStore.GetReceitaAsync(true);
                foreach (var item in items)
                {
                    Receita.Add(item);
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

        public Receita SelectedItem
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
            await Shell.Current.GoToAsync(nameof(NewReceitasPage));
        }

        async void OnItemSelected(Receita item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ReceitasDetailPage)}?{nameof(ReceitasDetailViewModel.ItemId)}={item.Id}");
        }
    }
}