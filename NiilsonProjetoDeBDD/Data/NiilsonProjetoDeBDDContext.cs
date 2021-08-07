using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NiilsonProjetoDeBDD.Models
{
    public class NiilsonProjetoDeBDDContext : DbContext
    {
        public NiilsonProjetoDeBDDContext (DbContextOptions<NiilsonProjetoDeBDDContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecords { get; set; }


    }
}
