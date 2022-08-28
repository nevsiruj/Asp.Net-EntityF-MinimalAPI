using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebAPI.Entities
{
    public partial class SysuxDb : DbContext
    {
        protected readonly IConfiguration Configuration;
        public SysuxDb(DbContextOptions<SysuxDb> options)
          : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = Configuration.GetConnectionString("Default");
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public virtual DbSet<ContactoCliente> ContactoClientes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
