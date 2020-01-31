using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Data.Contracts
{
    public interface IClienteRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> GetByIdAsync(int id);
        Task<T> SearchByDocumentNumber(string documentNumber, int documentType);
        Task<bool> Remove(T entity);

        Task<IEnumerable<T>> GetAllItemsAsync();

        Task<bool> Update(T entity);

    }
}
