﻿using acf.lib.bootstrap.Interfaces;
using projeto.io.domain.Interfaces;
using projeto.io.domain.ValueObjects;
using System.Threading.Tasks;

namespace projeto.io.domain.Clientes.Repositorio
{
    public interface IClienteRepositorio : IRepositorio<Cliente>, IServiceScopedInjection
    {
        Task<Cliente> ObterPorCpf(CPF Cpf);
    }
}
