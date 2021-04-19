using System;
using System.Collections.Generic;

#nullable disable

namespace PyS.RFID.APIRest.Models
{
    public partial class Local
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Dirección { get; set; }
        public int? EmpresaId { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string RowState { get; set; }
    }
}
