using System.Data.Entity;

namespace WeekendProject.DAL
{
    public class BoekenkastContext : DbContext
    {
        public DbSet<Persoon> Personen  { get; set; }
        public DbSet<Boek> Boeken { get; set; }
    }
}