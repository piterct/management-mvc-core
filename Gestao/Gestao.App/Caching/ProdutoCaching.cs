using Gestao.Business.Interfaces;
using Gestao.Business.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gestao.App.Caching
{
    public class ProdutoCaching<T> : IProdutoRepository where T : IProdutoRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly T _inner;
        private readonly ILogger<ProdutoCaching<T>> _logger;

        public async Task Adicionar(Produto entity)
        {
            await _inner.Adicionar(entity);
        }

        public Task Atualizar(Produto entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> Buscar(Expression<Func<Produto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedores()
        {
           return await _inner.ObterProdutosFornecedores();
        }

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId)
        {
            return await _inner.ObterProdutosPorFornecedor(fornecedorId);
        }

        public async Task<List<Produto>> ObterTodos()
        {
            return await _inner.ObterTodos();
        }

        public async Task Remover(Guid id)
        {
            await _inner.Remover(id);
        }

        public async Task<int> SaveChanges()
        {
            return await _inner.SaveChanges();
        }

        public void Dispose()
        {
            _inner?.Dispose();
        }
    }
}
