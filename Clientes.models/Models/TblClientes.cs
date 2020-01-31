using System;
using System.Collections.Generic;

namespace Clientes.models.Models
{
    public partial class TblClientes
    {
        public TblClientes()
        {
            TblVentas = new HashSet<TblVentas>();
        }

        public int IdCli { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Ciudad { get; set; }

        public virtual ICollection<TblVentas> TblVentas { get; set; }
    }
}
