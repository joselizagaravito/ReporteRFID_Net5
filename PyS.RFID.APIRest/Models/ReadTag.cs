using System;
using System.Collections.Generic;

#nullable disable

namespace PyS.RFID.APIRest.Models
{
    public partial class ReadTag
    {
        public int Id { get; set; }
        public int? Tag { get; set; }
        public string Epc { get; set; }
        public string Tid { get; set; }
        public int? InvTimes { get; set; }
        public int? Rssi { get; set; }
        public int? AntId { get; set; }
        public DateTime? LastTime { get; set; }
        public DateTime? FirstReadTime { get; set; }
        public string Color { get; set; }
        public string ModuloId { get; set; }
        public string ModuloRol { get; set; }
    }
}
