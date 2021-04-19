using System;
using System.Collections.Generic;

#nullable disable

namespace PyS.RFID.APIRest.Models
{
    public partial class Modulo
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int? LocalId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string RowState { get; set; }
    }
}
