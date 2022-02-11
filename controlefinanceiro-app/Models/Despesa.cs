using System;

namespace controlefinanceiro_app.Models
{
    public class Despesa
    {
        public string Id { get; set; }
        
        public string Description { get; set; }

        public double Amount { get; set; }

        public string Date { get; set; }
        public double Categoria { get; set; }

    }
}

