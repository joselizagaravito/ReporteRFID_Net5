using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PyS.RFID.APIRest.Models
{
    public class Archivo
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Extension { get; set; }
        public double Tamanio { get; set; }
        public string Ubicacion { get; set; }
    }
}
