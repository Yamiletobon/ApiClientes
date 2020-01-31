using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clientes.models.Models;
using Clientes.Dtos;
using Clientes.Data.Contracts;
using Clientes.Utils;

namespace Clientes.Controllers
{
    [Route("api/[controller]")]
    [Filter]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository<TblClientes> _clienteRepository;
        private readonly Bd_TestContext _context;

        public ClientesController(IClienteRepository<TblClientes> clientesRepository, Bd_TestContext context)
        {
            _context = context;
            _clienteRepository = clientesRepository;
        }

        // GET: api/Clientes
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<TblClientes>>> Get()
        public async Task<ActionResult<IEnumerable<TblClientes>>> Get()
        {
            return await _context.TblClientes.ToListAsync();

         
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<TblClientes>> GetTblClientes(int id)
        public async Task<ActionResult<TblClientes>> GetTblClientes(int id)
        {
            var tblClientes = await _clienteRepository.GetByIdAsync(id);
            
            if (tblClientes == null)
            {
                return NotFound();
            }

            return tblClientes;
        }

        //// PUT: api/Clientes/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblClientes(int id, TblClientes tblClientes)
        //{
        //    if (id != tblClientes.IdCli)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblClientes).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblClientesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Clientes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Post(ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                BadRequest();
            }

            var cliente = new TblClientes()
            {
                IdCli = clienteDto.IdCli,
                NumeroDocumento = clienteDto.NumeroDocumento,
                Nombre = clienteDto.Nombre,
                Direccion = clienteDto.Direccion,
                Telefono = clienteDto.Telefono,
                Ciudad = clienteDto.Ciudad

            };

            var resultado = await _clienteRepository.Add(cliente);

            return StatusCode(200, "Cliente creado");
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(TblClientes id)
        {
            await _clienteRepository.Remove( id);
            //if (tblClientes == null)
            //{
            //    return NotFound();
            //}

            //_context.TblClientes.Remove(tblClientes);
            //await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{idCli}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDto>> Put(string idCli, [FromBody]ClienteDto clienteDto)
        {
            if (clienteDto == null)
            {
                BadRequest();
            }

            var cliente = new TblClientes()
            {
                IdCli = clienteDto.IdCli,
                NumeroDocumento = clienteDto.NumeroDocumento,
                Nombre = clienteDto.Nombre,
                Direccion = clienteDto.Direccion,
                Telefono = clienteDto.Telefono,
                Ciudad = clienteDto.Ciudad

            };
            //var cuenta = _mapper.Map<Cuenta>(cuentaDto);
            var resultado = await _clienteRepository.Update(cliente);
            if (!resultado)
            {
                NotFound();
            }

            return clienteDto;
        }
    }
}