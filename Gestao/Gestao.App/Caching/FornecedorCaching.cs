using Gestao.Business.Interfaces;
using Gestao.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gestao.App.Caching
{
    public class FornecedorCaching<T> : IFornecedorRepository where T : IFornecedorRepository
    {
        public Task Adicionar(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Fornecedor entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Fornecedor> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Fornecedor>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
