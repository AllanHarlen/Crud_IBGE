using Microsoft.EntityFrameworkCore;

namespace Crud_IBGE.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options)
        { 
        
        }

        public DbSet<Processo> Processos { get; set; }
    }
}
