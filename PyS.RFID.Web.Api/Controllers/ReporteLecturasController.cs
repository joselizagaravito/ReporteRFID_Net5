using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PyS.RFID.Web.Api.Data;
using PyS.RFID.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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
        public IEnumerable<ReportItemLectura> GetReporte(string fecha, string ruc)
        {
            string pattern = "yyyy-MM-dd";
            DateTime parseDate;
            List<ReportItemLectura> lista = null;

            if (DateTime.TryParseExact(fecha, pattern, null, DateTimeStyles.None, out parseDate))
            {
                var param = new SqlParameter("@FECHA", fecha);
                var param2 = new SqlParameter("@RUC", ruc);
                lista = _context.ReportItemLectura.FromSqlRaw("usp_LecturasPorDia @FECHA, @RUC", param, param2).ToList();
            }

            return lista;
        }
    }
}
