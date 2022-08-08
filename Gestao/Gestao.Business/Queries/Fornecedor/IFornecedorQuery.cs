using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gestao.Business.Queries.Fornecedor
{
    public interface IFornecedorQuery: IQuery
    {
        Task<IEnumerable<FornecedorResult>> ObterTodos();
        Task<IEnumerable<FornecedorResult>> ObterTodosProcedure();
    }
}
