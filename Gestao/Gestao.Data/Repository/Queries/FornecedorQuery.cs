using Gestao.Business.Queries.Fornecedor;
using Gestao.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao.Data.Repository.Queries
{
    public class FornecedorQuery: IFornecedorQuery
    {
        protected readonly GestaoDbContext _context;

        public FornecedorQuery(GestaoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FornecedorResult>> ObterTodos()
        {
            return  await _context.FornecedorResults.FromSqlRaw<FornecedorResult>("select * from Fornecedores").ToListAsync();
        }

        public async Task<IEnumerable<FornecedorResult>> ObterTodosProcedure()
        {
            return await _context.FornecedorResults.FromSqlRaw<FornecedorResult>("spTodosFornecedores").ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }


}
