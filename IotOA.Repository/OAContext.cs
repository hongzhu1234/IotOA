using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IotOA.Modle;

namespace IotOA.Repository
{
    public class OAContext : DbContext
    {
        string strsql = ConfigurationManager.AppSettings["SQLConn"];

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(strsql);
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Users> Users { get; set; }
    }
}
