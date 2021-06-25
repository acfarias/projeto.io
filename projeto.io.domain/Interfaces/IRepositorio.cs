using projeto.io.domain.core.Modelos;
using System;
using System.Threading.Tasks;

namespace projeto.io.domain.Interfaces
{
    public interface IRepositorio<TEntity> : IDisposable where TEntity : Entity<TEntity>
    {
        Task<int> Cadastrar(TEntity entity);
        Task<int> Atualizar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<int> Excluir(TEntity entity);
    }
}
