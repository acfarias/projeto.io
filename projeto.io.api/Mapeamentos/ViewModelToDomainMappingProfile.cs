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

            CreateMap<CadastrarClienteCommand, Cliente>()
                .ConvertUsing(c => new Cliente(Guid.NewGuid(), c.Nome, c.Cpf.CPF, c.NomeMae, c.DataNascimento, c.Ativo,
                new EnderecoCliente(Guid.NewGuid(), c.Endereco.Logradouro, c.Endereco.Complemento, c.Endereco.TipoEndereco, c.Endereco.Bairro, c.Endereco.Cidade, c.Endereco.Pais)));

        }
    }
}
