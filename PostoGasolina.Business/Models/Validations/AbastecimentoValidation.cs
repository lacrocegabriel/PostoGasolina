using FluentValidation;
using static PostoGasolina.Business.Models.Validations.Documentos.ValidacaoDocumentos.ValidacaoDocs;

namespace PostoGasolina.Business.Models.Validations
{
    public class AbastecimentoValidation : AbstractValidator<Abastecimento>
    {
        public AbastecimentoValidation()
        {
            RuleFor(a => a.Litragem)
                .NotEmpty().WithMessage("o campo {PropertyName} precisa ser fornecido");

            RuleFor(a => a.ValorLitro)
                .NotEmpty().WithMessage("o campo {PropertyName} precisa ser fornecido");
                
            RuleFor(a => a.DataAbastecimento)
                .NotEmpty().WithMessage("o campo {PropertyName} precisa ser fornecido");

            RuleFor(a => a.TipoCombustivelId)
                .NotEmpty().WithMessage("É necessário informar o tipo do combustível");

            RuleFor(a => a.ClienteId)
                .NotEmpty().WithMessage("É necessário informar o cliente");

            RuleFor(a => a.VeiculoId)
                .NotEmpty().WithMessage("É necessário informar o veículo");
            
        }
    }
}

