using System;
using System.Collections.Generic;

namespace Clientes.models.Models
{
    public partial class TblVentas
    {
        public int Id { get; set; }
        public string Cantidad { get; set; }
        public int IdCli { get; set; }
        public int IdProd { get; set; }

        public virtual TblClientes IdCliNavigation { get; set; }
        public virtual TblProductos IdProdNavigation { get; set; }
    }
}
