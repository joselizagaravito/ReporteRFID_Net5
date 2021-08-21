using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PyS.RFID.APIRest.DTOs
{
    public class LecturasSeguimientos
    {
        public Int32 Id { get; set; }
        public string EPC { get; set; }
        public string Nombre { get; set; }
        public int ModuloId { get; set; }
        public string ModuloRol { get; set; }
        public int Lecturas { get; set; }
        public string Local { get; set; }
        public string Antena { get; set; }
        public string Empresa { get; set; }
        public string RUC { get; set; }
        public DateTime UltimaLectura { get; set; }
    }
}
