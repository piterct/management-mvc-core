using Gestao.Business.Interfaces;
using Gestao.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gestao.Business.Services
{
    public class ProdutoService : BaseService, IProdutoService
    {
        public Task Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
