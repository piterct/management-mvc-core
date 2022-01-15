using FluentValidation;
using FluentValidation.Results;
using Gestao.Business.Models;
using System.Threading.Tasks;

namespace Gestao.Business.Services
{
    public abstract class BaseService
    {

        protected void Notificar(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }
        protected void Notificar(string mensagem)
        {

        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            if(validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
