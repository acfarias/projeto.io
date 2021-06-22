using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto.io.domain.Commands.Clientes.Entities;

namespace projeto.io.infra.data.Configuracoes
{
    public class ConfiguracaoClientes : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> e)
        {
            e.ToTable("Clientes");
            e.HasKey(e => e.Id);

            e.Property(e => e.Cpf).HasColumnName("Cpf");
        }
    }
}
