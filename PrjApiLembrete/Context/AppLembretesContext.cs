using Microsoft.EntityFrameworkCore;
using PrjApiLembrete.Entities;

namespace PrjApiLembrete.Context
{
    public class AppLembretesContext : DbContext //herdar de DbContext para informar que essa classe representará o BD - obrigatorio 
    {
        public AppLembretesContext(DbContextOptions<AppLembretesContext> options) : base(options) { }


        public DbSet<Lembrete> Lembretes { get; set; } //represenando uma tabela no BD
    }
}
