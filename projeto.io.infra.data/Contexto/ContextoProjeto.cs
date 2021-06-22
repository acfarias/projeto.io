using Microsoft.EntityFrameworkCore;
using projeto.io.domain.Commands.Clientes.Entities;

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

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfigurationsFromAssembly(typeof(ContextoProjeto).Assembly);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EnderecoCliente> EnderecoClientes { get; set; }
    }
}
