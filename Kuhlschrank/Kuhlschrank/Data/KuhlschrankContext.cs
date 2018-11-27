using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kuhlschrank.Models
{
    public class KuhlschrankContext : DbContext
    {
        public KuhlschrankContext (DbContextOptions<KuhlschrankContext> options)
            : base(options)
        {
        }

        public DbSet<Kuhlschrank.Models.Fridge> Fridge { get; set; }
        public DbSet<Kuhlschrank.Models.Client> Client { get; set; }
        public DbSet<Kuhlschrank.Models.ClientFridge> ClientFridge { get; set; }
    }
}
