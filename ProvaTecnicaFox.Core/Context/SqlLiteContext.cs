using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProvaTecnicaFox.Core.Context.SqlContext;

namespace ProvaTecnicaFox.Core.Context
{
    public class SqlLiteContext : SqlContext
    {
        public SqlLiteContext(IConfiguration configuration) : base(configuration) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("SqlLiteConnectionString"));
        }
    }
}
