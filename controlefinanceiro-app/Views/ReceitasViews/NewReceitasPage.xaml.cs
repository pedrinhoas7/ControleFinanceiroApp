using controlefinanceiro_app.Models;
using controlefinanceiro_app.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace controlefinanceiro_app.Views
{
    public partial class NewReceitasPage : ContentPage
    {
        public Receita Item { get; set; }

        public NewReceitasPage()
        {
            InitializeComponent();
            BindingContext = new NewReceitasViewModel();
        }


    }
}