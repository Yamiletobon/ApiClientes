using System;
using System.Collections.Generic;

namespace Clientes.models.Models
{
    public partial class TblProductos
    {
        public TblProductos()
        {
            TblVentas = new HashSet<TblVentas>();
        }

        public int IdProd { get; set; }
        public string Descripcion { get; set; }
        public string Precio { get; set; }

        public virtual ICollection<TblVentas> TblVentas { get; set; }
    }
}
