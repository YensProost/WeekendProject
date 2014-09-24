using System.Data.Entity;
using WeekendProject.DAL.Model;

namespace WeekendProject.DAL
{
    public class BoekenkastContext : DbContext
    {
        public DbSet<Persoon> Personen  { get; set; }
        public DbSet<Boek> Boeken { get; set; }
    }
}