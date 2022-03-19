using Flunt.Validations;
using Gestao.Business.Commands.Shared;
using Gestao.Business.Models;
using System.Collections.Generic;

namespace Gestao.Business.Commands.Input
{
    public  class CriaFornecedorCommand : CommandEntity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* Ef Relations */

        public IEnumerable<Produto> Produtos { get; set; }

        public override void Validate()
        {
            AddNotifications(
          new Contract()
              .Requires()
              .IsNotNullOrEmpty(Nome, "Nome", "O Campo {0} é obrigatorio !")
              .IsNotNullOrEmpty(Documento, "Documento", "O Campo {0} é obrigatorio !")
               );
        }
    }
}
