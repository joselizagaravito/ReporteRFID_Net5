using System;
using System.Collections.Generic;

#nullable disable

namespace PyS.RFID.APIRest.Models
{
    public partial class Tag
    {
        public int Id { get; set; }
        public int? Tag1 { get; set; }
        public string Epc { get; set; }
        public string Tid { get; set; }
        public int? InvTimes { get; set; }
        public int? Rssi { get; set; }
        public int? AntId { get; set; }
        public int? ArticuloId { get; set; }
        public DateTime? LastTime { get; set; }
        public string RowState { get; set; }
    }
}
