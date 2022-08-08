using Gestao.Business.Models;
using System;

namespace Gestao.Business.Queries.Fornecedor
{
    public class FornecedorResult
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public bool Ativo { get; set; }
    }
}
