using Clientes.Bussines;
using System;
using System.ComponentModel.DataAnnotations;


namespace Clientes.Dtos
{
    public class ClienteDto
    {
        
        [Required(ErrorMessage = "{0} Es requerido")]
        [Display(Name = "Id del Cliente")]
        public int IdCli { get; set; }

        [ValidarNumerico(ErrorMessage = "Numero de documento no numerico")]
        [Required(ErrorMessage = "{0} Es requerido")]
        [Display(Name = "Numero de documento no numerico")]
        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "{0} Es requerido")]
        [Display(Name = "Nombre del cliente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "{0} Es requerido")]
        [Display(Name = "Dirección del cliente")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "{0} Es requerido")]
        [Display(Name = "Telefono del cliente")]
        [Phone(ErrorMessage = "no valido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "{0} Es requerido")]
        [Display(Name = "Ciudad del cliente")]
        public string Ciudad { get; set; }
    }
}
