using DAL.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBContextUsage : DbContext
    {

        public DbSet<Uygulamalar> Uygulamalar { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
