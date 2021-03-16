using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PyS.RFID.Web.Api.Models
{
    public class ReadTag
    {
        public int Id { get; set; }
        public int TAG { get; set; }
        public string EPC { get; set; }
        public string TID { get; set; }
        public int InvTimes{ get; set; }
        public int RSSI { get; set; }
        public int AntID { get; set; }
        public DateTime LastTime { get; set; }
        public DateTime FirstReadTime { get; set; }
        public string Color { get; set; }
        public string ModuloId { get; set; }
        public string ModuloRol { get; set; }

    }
}
