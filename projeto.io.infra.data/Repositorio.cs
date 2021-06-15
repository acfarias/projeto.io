using projeto.io.domain.core.Modelos;
using projeto.io.domain.Interfaces;
using projeto.io.infra.data.Contexto;
using System;
using System.Threading.Tasks;

namespace projeto.io.infra.data
{
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : Entity<TEntity>
    {
        private readonly ContextoProjeto _contextoProjeto;
        public Repositorio(ContextoProjeto contextoProjeto)
        {
            _contextoProjeto = contextoProjeto;
        }

        public async Task Cadastrar(TEntity entity)
        {
            await _contextoProjeto.AddAsync(entity);
            await _contextoProjeto.SaveChangesAsync();
        }

        public async Task<int> Atualizar(TEntity entity)
        {
            _contextoProjeto.Update(entity);
            return await _contextoProjeto.SaveChangesAsync();
        }

        public async Task<TEntity> ObterPorId(Guid id)
        {
            return await _contextoProjeto.FindAsync<TEntity>(id);
        }

        public async Task<int> Excluir(TEntity entity)
        {
            _contextoProjeto.Remove(entity);
            return await _contextoProjeto.SaveChangesAsync();
        }

        public void Dispose()
        {
            _contextoProjeto.DisposeAsync();
        }
    }
}
