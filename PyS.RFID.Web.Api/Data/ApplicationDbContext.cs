using Microsoft.EntityFrameworkCore;
using PyS.RFID.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PyS.RFID.Web.Api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }
        public DbSet<ReportItemLectura> ReportItemLectura { get; set; }
        public DbSet<ReadTag> ReadTag { get; set; }
    }
}
