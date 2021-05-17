using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PyS.RFID.APIRest.Context;
using PyS.RFID.APIRest.DTOs;
using PyS.RFID.APIRest.Interfaces;
using PyS.RFID.APIRest.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PyS.RFID.APIRest.Controllers
{
    public class ReadTAGController : BaseApiController
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;

        public ReadTAGController(DataContext context, ITokenService tokenService)
        {
            this.context = context;
            this.tokenService = tokenService;
        }
       
    }
}
