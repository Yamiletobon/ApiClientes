using Clientes.Data.Contracts;
using Clientes.models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clientes.Data.Repositories
{
    public class ClientesRepository : IClienteRepository<TblClientes>
    {
        private readonly Bd_TestContext _context;

        public ClientesRepository(Bd_TestContext context)
        {
            _context = context;
        }

        public async Task<TblClientes> Add(TblClientes newCliente)
        {
            try
            {
                _context.TblClientes.Add(newCliente);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                return null;
            }

            return newCliente;
        }

        public Task<TblClientes> GetByIdAsync(int id)
        {
            return _context.TblClientes.SingleOrDefaultAsync(x => x.IdCli == id);
        }

        Task<TblClientes> IClienteRepository<TblClientes>.SearchByDocumentNumber(string documentNumber, int documentType)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(TblClientes id)
        {
            try
            {
                _context.TblClientes.Remove(id);

                return (await _context.SaveChangesAsync() > 0 ? true : false);

            }
            catch (Exception ex)
            {

            }

            return false;
        }
        public async Task<IEnumerable<TblClientes>> GetAllItemsAsync()
        {
            return await _context.TblClientes.ToListAsync();
        }

        public async Task<bool> Update(TblClientes entity)
        {
            try
            {
                

                _context.TblClientes.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;

                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                
            }

            return false;
        }
    }
}
