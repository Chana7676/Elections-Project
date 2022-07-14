using Microsoft.EntityFrameworkCore;
using Elections.Classes;

namespace Elections.Data
{    
    public class ElectionsDbContext : DbContext
    {
        public ElectionsDbContext() { }

        public ElectionsDbContext(DbContextOptions<ElectionsDbContext> options) : base(options)
        {
        }

        public DbSet<Party> Parties => Set<Party>();
        public DbSet<Voter> Voters => Set<Voter>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                //base.OnModelCreating(modelBuilder);
                base.OnModelCreating(modelBuilder);
                //modelBuilder.Entity<Party>().ToTable("Parties");
                //modelBuilder.Entity<Voter>().ToTable("Voters");
                modelBuilder.ApplyConfigurationsFromAssembly(typeof(Voter).Assembly);
            }
            catch (Exception ex) {
                throw ex;
            }
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(Party).Assembly);
            //throw new Exception();    
        }
    }
}
