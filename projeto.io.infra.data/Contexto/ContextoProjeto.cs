using Microsoft.EntityFrameworkCore;
using projeto.io.domain.Clientes;

namespace projeto.io.infra.data.Contexto
{
    public class ContextoProjeto : DbContext
    {
        public ContextoProjeto() { }

        public ContextoProjeto(DbContextOptions<ContextoProjeto> contextOptions) : base(contextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("ProjetoDB");
        }


        public DbSet<Cliente> Clientes { get; set; }
    }
}
