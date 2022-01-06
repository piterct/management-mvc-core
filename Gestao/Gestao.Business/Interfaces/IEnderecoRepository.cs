using Gestao.Business.Models;
using System;
using System.Threading.Tasks;

namespace Gestao.Business.Interfaces
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId);
    }
}
