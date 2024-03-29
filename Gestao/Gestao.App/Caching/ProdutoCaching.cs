﻿using Gestao.Business.Interfaces;
using Gestao.Business.Models;
using Gestao.Data.Repository;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Gestao.App.Caching
{
    public class ProdutoCaching<T> : BaseCaching<ProdutoRepository>, IProdutoRepository where T : IProdutoRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly T _inner;
        private readonly ILogger<ProdutoCaching<T>> _logger;

        public async Task<List<Produto>> ObterTodos()
        {
            var key = "obter-todos-produtos";
            var item = _memoryCache.Get<List<Produto>>(key);

            if (item == null)
            {
                item = await _inner.ObterTodos();
                if (item != null)
                {
                    _memoryCache.Set(key, item, TimeSpan.FromMinutes(1));
                }
            }

            return item;
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            var key = GetKey(id.ToString());
            var item = _memoryCache.Get<Produto>(key);

            if (item == null)
            {
                _logger.LogTrace("Cache miss for {cacheKey}", key);
                item = await _inner.ObterPorId(id);
                if (item != null)
                {
                    _logger.LogTrace("Setting item in cache for {cacheKey}", key);
                    _memoryCache.Set(key, item, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                _logger.LogTrace("Cache hit for {cacheKey}", key);
            }

            return item;
        }


        public async Task<IEnumerable<Produto>> Buscar(Expression<Func<Produto, bool>> predicate)
        {
            return await _inner.Buscar(predicate);
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

        public async Task Adicionar(Produto entity)
        {
            await _inner.Adicionar(entity);
        }

        public async Task Atualizar(Produto entity)
        {
            await _inner.Atualizar(entity);
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
