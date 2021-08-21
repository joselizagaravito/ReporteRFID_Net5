using System;
using System.Collections.Generic;

#nullable disable

namespace PyS.RFID.APIRest.Models
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public string CodigoArticulo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? LocalId { get; set; }
        public string EPC { get; set; }
        public string Precio { get; set; }
        public DateTime? LastTime { get; set; }
        public string RowState { get; set; }
    }
}
