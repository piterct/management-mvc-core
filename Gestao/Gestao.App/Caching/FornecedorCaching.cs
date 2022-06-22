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
    public class FornecedorCaching<T> : IFornecedorRepository where T : IFornecedorRepository
    {
        private readonly IMemoryCache _memoryCache;
        private readonly T _inner;
        private readonly ILogger<FornecedorCaching<T>> _logger;

        public FornecedorCaching(IMemoryCache memoryCache, T inner, ILogger<FornecedorCaching<T>> logger)
        {
            _memoryCache = memoryCache;
            _inner = inner;
            _logger = logger;
        }

        public async Task<List<Fornecedor>> ObterTodos()
        {
            var key = "lista-de-fornecedores";
            var item = _memoryCache.Get<List<Fornecedor>>(key);

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

        public async Task<Fornecedor> ObterPorId(Guid id)
        {
            var key = GetKey(id.ToString());
            var item = _memoryCache.Get<Fornecedor>(key);

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

        public async Task<IEnumerable<Fornecedor>> Buscar(Expression<Func<Fornecedor, bool>> predicate)
        {
            return await _inner.Buscar(predicate);
        }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await _inner.ObterFornecedorEndereco(id);
        }

        public async Task Adicionar(Fornecedor entity)
        {
            await _inner.Adicionar(entity);
        }

        public async Task Atualizar(Fornecedor entity)
        {
            await _inner.Atualizar(entity);
        }

        public Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChanges()
        {
            return _inner.SaveChanges();
        }
        public void Dispose()
        {
            _inner?.Dispose();
        }

        private static string GetKey(string key)
        {
            return $"{typeof(T).FullName}:{key}";
        }
    }
}
