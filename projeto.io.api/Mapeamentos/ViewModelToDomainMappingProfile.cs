using AutoMapper;
using projeto.io.api.ViewModel.Cliente;
using projeto.io.domain.Commands.Clientes.Commands;
using projeto.io.domain.Commands.Clientes.Entities;
using projeto.io.domain.ValueObjects;
using System;

namespace projeto.io.api.Mapeamentos
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<string, Documento>()
                .ConstructUsing(c => new Documento(c));

            CreateMap<ClienteViewModel, CadastrarClienteCommand>()
                .ConvertUsing(c => new CadastrarClienteCommand(c.Nome, new Documento(c.Cpf), c.NomeMae, c.DataNascimento, true,
                new Endereco(c.Endereco.Logradouro, c.Endereco.Complemento, c.Endereco.TipoEndereco, c.Endereco.Bairro, c.Endereco.Cidade, c.Endereco.Pais)));

            CreateMap<Endereco, EnderecoCliente>()
                .ConvertUsing(e => new EnderecoCliente(Guid.NewGuid(), e.Logradouro, e.Complemento, e.TipoEndereco, e.Bairro, e.Cidade, e.Pais));

            CreateMap<Tuple<Guid, CadastrarClienteCommand>, Cliente>()
                .ConvertUsing(c => new Cliente(Guid.NewGuid(), c.Item2.Nome, c.Item2.Cpf.CPF, c.Item2.NomeMae, c.Item2.DataNascimento, c.Item2.Ativo, c.Item1));

        }
    }
}
