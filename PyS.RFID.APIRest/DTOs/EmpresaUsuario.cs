using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PyS.RFID.APIRest.DTOs
{
    public class EmpresaUsuario
    {
        [Key]
        public string UserName { get; set; }
        public string NombreCompleto { get; set; }
        public string Ruc { get; set; }
        public string Empresa { get; set; }
    }
}
