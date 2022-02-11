using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace controlefinanceiro_app.Services
{
    public interface IDespesasDataStore<T>
    {
        Task<bool> AddDespesaAsync(T despesa);
        Task<bool> UpdateDespesaAsync(T despesa);
        Task<bool> DeleteDespesaAsync(string id);
        Task<T> GetDespesaAsync(string id);
        Task<IEnumerable<T>> GetDespesasAsync(bool forceRefresh = false);
    }
}
