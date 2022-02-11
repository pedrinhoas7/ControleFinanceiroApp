using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace controlefinanceiro_app.Services
{
    public interface IReceitaDataStore<T>
    {
        Task<bool> AddReceitaAsync(T despesa);
        Task<bool> UpdateReceitaAsync(T despesa);
        Task<bool> DeleteReceitaAsync(string id);
        Task<T> GetReceitaAsync(string id);
        Task<IEnumerable<T>> GetReceitaAsync(bool forceRefresh = false);
    }
}
