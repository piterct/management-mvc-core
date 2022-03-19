using Gestao.Business.Models;
using System.Collections.Generic;

namespace Gestao.Business.Commands.Input
{
    public  class CriaFornecedorCommand
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* Ef Relations */

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
