using Gestao.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao.Business.Interfaces
{
    public  interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        Task Atualizar(TEntity obj);
        Task Remover(Guid id);
    }
}
