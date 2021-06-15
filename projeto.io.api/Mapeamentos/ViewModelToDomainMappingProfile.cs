using AutoMapper;
using projeto.io.api.ViewModel.Cliente;
using projeto.io.domain.Clientes;
using projeto.io.domain.Clientes.Commands;
using projeto.io.domain.ValueObjects;
using System;

namespace projeto.io.api.Mapeamentos
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ClienteViewModel, CadastrarClienteCommand>()
                .ConstructUsing(c => new CadastrarClienteCommand(c.Nome, new CPF(c.Cpf), c.NomeMae, c.DataNascimento, true));

            CreateMap<CadastrarClienteCommand, Cliente>()
                .ConstructUsing(c => new Cliente(Guid.NewGuid(), c.Nome, c.Cpf, c.NomeMae, c.DataNascimento, c.Ativo));
        }
    }
}
