using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProvaTecnicaFox.Core.Models;
using System;
using System.Collections.Generic;
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
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString"));
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            }
            public DbSet<AccomodationModel> Accomodations { get; set; }
            public DbSet<RoomModel> Rooms { get; set; }
    }
}
