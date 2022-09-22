using FluentValidation;
using static PostoGasolina.Business.Models.Validations.Documentos.ValidacaoDocumentos.ValidacaoDocs;

namespace PostoGasolina.Business.Models.Validations
{
    public class VeiculoValidation : AbstractValidator<Veiculo>
    {
        public VeiculoValidation()
        {
            RuleFor(v => v.Modelo)
                .NotEmpty().WithMessage("o campo {PropertyName} precisa ser fornecido");

            RuleFor(v => v.Ano)
                .NotEmpty().WithMessage("o campo {PropertyName} precisa ser fornecido");
                
            RuleFor(v => v.Placa)
                .NotEmpty().WithMessage("o campo {PropertyName} precisa ser fornecido");

            RuleFor(v => v.TipoCombustivelId)
                .NotEmpty().WithMessage("É necessário informar o tipo do combustível");

            RuleFor(v => v.ClienteId)
                .NotEmpty().WithMessage("É necessário informar o cliente");
        }
    }
}

