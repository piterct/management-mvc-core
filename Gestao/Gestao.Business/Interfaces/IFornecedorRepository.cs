using Gestao.Business.Models;
using System;
using System.Threading.Tasks;

namespace Gestao.Business.Interfaces
{
    public  interface IFornecedorRepository : IRepository<Fornecedor>
    {
        Task<Fornecedor> ObterFornecedorEndereco(Guid id);
        Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id);
    }
}
