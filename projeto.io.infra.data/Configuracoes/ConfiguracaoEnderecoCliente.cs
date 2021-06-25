using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using projeto.io.domain.Commands.Clientes.Entities;

namespace projeto.io.infra.data.Configuracoes
{
    public class ConfiguracaoEnderecoCliente : IEntityTypeConfiguration<EnderecoCliente>
    {
        public void Configure(EntityTypeBuilder<EnderecoCliente> e)
        {
            e.ToTable("EnderecosClientes");
            e.HasKey(e => e.Id);

            e.HasMany(c => c.Clientes)
                .WithOne(e => e.Endereco)
                .HasForeignKey(c => c.IdEndereco);
        }
    }
}
