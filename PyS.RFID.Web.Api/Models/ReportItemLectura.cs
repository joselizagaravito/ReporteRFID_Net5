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
        public int Total { get; set; }
        public DateTime UltimaLectura { get; set; }
    }
}
