using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PyS.RFID.APIRest.DTOs
{
    public class LoginDto
    {
        public string UserName { get; set; }
       
        public string Password { get; set; }
    }
}
