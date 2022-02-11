using controlefinanceiro_app.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace controlefinanceiro_app.ViewModels
{
    public class NewReceitasViewModel : ReceitaBaseViewModel
    {
        private string description;
        private double amount;
        private int categoria;
        public string date;


        public NewReceitasViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(description);
        }


        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public double Amount
        {
            get => Amount;
            set => SetProperty(ref amount, value);
        }

        public int Categoria
        {
            get => Categoria;
            set => SetProperty(ref categoria, value);
        }

        public string Date
        {
            get => Date;
            set => SetProperty(ref date, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Receita newItem = new Receita()
            {
                Id = Guid.NewGuid().ToString(),
                Description = Description,
                Amount = Amount,
                Date = Date,
                Categoria = Categoria

            };

            await DataStore.AddReceitaAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
