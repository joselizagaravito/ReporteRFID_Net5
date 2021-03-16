using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PyS.RFID.Web.Api.Data;
using PyS.RFID.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PyS.RFID.Web.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReporteLecturasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ReporteLecturasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<ReadTag> Get()
        {
            IEnumerable<ReadTag> lista = _context.ReadTag;
            return lista;
        }
        [HttpGet]
        public IEnumerable<ReportItemLectura> GetReporte()
        {
            List<ReportItemLectura> lista;
            string sql = "Exec usp_LecturasPorDia @FECHA = N'2021-03-14'";
            lista = _context.ReportItemLectura.FromSqlRaw<ReportItemLectura>(sql).ToList();
            return lista;
        }
    }
}
