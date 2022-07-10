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

        public async Task Atualizar(Produto entity)
        {
            await _inner.Atualizar(entity);
        }

        public async Task<IEnumerable<Produto>> Buscar(Expression<Func<Produto, bool>> predicate)
        {
            return await _inner.Buscar(predicate);
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
           return await _inner.ObterPorId(id);
        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _inner.ObterProdutoFornecedor(id);
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
            _memoryCache?.Dispose();
        }
    }
}
