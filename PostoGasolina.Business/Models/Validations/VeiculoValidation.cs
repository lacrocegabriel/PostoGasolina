using FluentValidation;
using static PostoGasolina.Business.Models.Validations.Documentos.ValidacaoDocumentos.ValidacaoDocs;

namespace PostoGasolina.Business.Models.Validations
{
    public class VeiculoValidation : AbstractValidator<Veiculo>
    {
        public VeiculoValidation()
        {
            RuleFor(v => v.Modelo)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(v => v.Marca)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(v => v.Ano)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");
                
            RuleFor(v => v.Placa)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(v => v.TipoCombustivelId)
                .NotNull().WithMessage("O campo Tipo de Combustível precisa ser fornecido");

            RuleFor(v => v.ClienteId)
                .NotEmpty().WithMessage("O campo Cliente precisa ser fornecido");
        }
    }
}

