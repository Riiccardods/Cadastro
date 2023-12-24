using Microsoft.EntityFrameworkCore;
using cadastro10.Models; // Substitua isso pelo namespace correto onde sua classe Pessoa está definida

namespace cadastro10.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
