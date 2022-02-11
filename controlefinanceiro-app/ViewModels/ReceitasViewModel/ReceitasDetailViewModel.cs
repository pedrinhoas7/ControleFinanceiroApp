using controlefinanceiro_app.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace controlefinanceiro_app.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ReceitasDetailViewModel : ReceitaBaseViewModel
    {
        private string itemId;
        private string description;
        private double amount;
        public string Id { get; set; }


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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetReceitaAsync(itemId);
                Id = item.Id;
                Description = item.Description;
                Amount = Amount;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
