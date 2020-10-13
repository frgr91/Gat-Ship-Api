using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GatCrmApi.Models
{
    public partial class GatshipContext : DbContext
    {

        public GatshipContext(DbContextOptions<GatshipContext> options)
            : base(options)
        {
        }

        public DbSet<KundeType> KundeType { get; set; }
        public DbSet<PostAdresse> PostAdresse { get; set; }
        public DbSet<Kunde> Kunde { get; set; }
        public DbSet<Kunde_KundeType> Kunde_KundeType { get; set; }
        public DbSet<KontaktPerson> KontaktPerson { get; set; }

    }
}
