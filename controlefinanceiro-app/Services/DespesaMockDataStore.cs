using controlefinanceiro_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace controlefinanceiro_app.Services
{
    public class DespesaMockDataStore : IDespesasDataStore<Despesa>
    {
        readonly List<Despesa> despesas;

        public DespesaMockDataStore()
        {
            despesas = new List<Despesa>()
            {
                 new Despesa { Id = Guid.NewGuid().ToString(),  Description="Essa despesa" ,Amount = 0, Date = DateTime.UtcNow.ToString(), Categoria=0 },
            };
        }

        public async Task<bool> AddDespesaAsync(Despesa despesa)
        {
            despesas.Add(despesa);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateDespesaAsync(Despesa despesa)
        {
            var oldItem = despesas.Where((Despesa arg) => arg.Id == despesa.Id).FirstOrDefault();
            despesas.Remove(oldItem);
            despesas.Add(despesa);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteDespesaAsync(string id)
        {
            var oldItem = despesas.Where((Despesa arg) => arg.Id == id).FirstOrDefault();
            despesas.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Despesa> GetDespesaAsync(string id)
        {
            return await Task.FromResult(despesas.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Despesa>> GetDespesasAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(despesas);
        }
    }
}