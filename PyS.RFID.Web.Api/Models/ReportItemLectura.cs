using System;
using System.ComponentModel.DataAnnotations;

namespace PyS.RFID.Web.Api.Models
{
    public class ReportItemLectura
    {
        [Key]
        public Int64 Id { get; set; }
        public string EPC { get; set; }
        public string ModuloId { get; set; }
        public string ModuloRol { get; set; }
        public int Lecturas { get; set; }
        public string Local { get; set; }
        public string Empresa { get; set; }
        public DateTime UltimaLectura { get; set; }
    }
}
