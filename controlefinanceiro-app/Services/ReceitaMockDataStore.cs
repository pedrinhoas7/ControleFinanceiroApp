using controlefinanceiro_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace controlefinanceiro_app.Services
{
    public class ReceitaMockDataStore : IReceitaDataStore<Receita>
    {
        readonly List<Receita> receita;

        public ReceitaMockDataStore()
        {
            receita = new List<Receita>()
            {
                  new Receita { Id = Guid.NewGuid().ToString(),  Description="Essa é uma receita" ,Amount = 0, Date = DateTime.UtcNow.ToString(), Categoria=0 },
            };
        }

        public async Task<bool> AddReceitaAsync(Receita r)
        {
            receita.Add(r);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateReceitaAsync(Receita r)
        {
            var oldItem = receita.Where((Receita arg) => arg.Id == r.Id).FirstOrDefault();
            receita.Remove(oldItem);
            receita.Add(r);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteReceitaAsync(string id)
        {
            var oldItem = receita.Where((Receita arg) => arg.Id == id).FirstOrDefault();
            receita.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Receita> GetReceitaAsync(string id)
        {
            return await Task.FromResult(receita.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Receita>> GetReceitaAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(receita);
        }
    }
}