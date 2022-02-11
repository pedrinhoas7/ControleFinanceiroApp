using controlefinanceiro_app.Models;
using controlefinanceiro_app.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace controlefinanceiro_app.Views
{
    public partial class NewDespesaPage : ContentPage
    {
        public Despesa Item { get; set; }

        public NewDespesaPage()
        {
            InitializeComponent();
            BindingContext = new NewDespesasViewModel();
        }
    }
}