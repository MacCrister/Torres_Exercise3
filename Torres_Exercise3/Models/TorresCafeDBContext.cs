using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Torres_Exercise3.Models
{
    public class TorresCafeDBContext : DbContext
    {
        public TorresCafeDBContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Client> Clients { get; set; }
    }
}
