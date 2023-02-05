using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProvaTecnicaFox.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProvaTecnicaFox.Core.Context
{
        public class SqlContext : DbContext
        {
            protected readonly IConfiguration Configuration;
            public SqlContext(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=appDb;Initial Catalog=ProvaTecnicaFoxSqlDb;Persist Security Info=False;User ID=sa;Password=Password12!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<AccomodationModel>()
                    .HasMany<RoomModel>(g => g.Rooms)
                    .WithOne(s => s.Accomodation)
                    .HasForeignKey(s => s.AccomodationId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
            public DbSet<AccomodationModel> Accomodations { get; set; }
            public DbSet<RoomModel> Rooms { get; set; }
            public DbSet<PriceModel> Prices { get; set; }
    }
}
