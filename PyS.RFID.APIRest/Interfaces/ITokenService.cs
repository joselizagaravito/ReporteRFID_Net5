using PyS.RFID.APIRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PyS.RFID.APIRest.Interfaces
{
    public interface ITokenService
    {
        string CreateToke(Usuario user);
    }
}
