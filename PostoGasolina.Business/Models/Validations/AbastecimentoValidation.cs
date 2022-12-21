using FluentValidation;
using static PostoGasolina.Business.Models.Validations.Documentos.ValidacaoDocumentos.ValidacaoDocs;

namespace PostoGasolina.Business.Models.Validations
{
    public class AbastecimentoValidation : AbstractValidator<Abastecimento>
    {
        public AbastecimentoValidation()
        {
            RuleFor(a => a.Litragem)
                .NotEmpty().WithMessage("A litragem abastecida precisa ser fornecida");

            RuleFor(a => a.ValorLitro)
                .NotEmpty().WithMessage("O valor do litro precisa ser fornecido");
                
            RuleFor(a => a.DataAbastecimento)
                .NotEmpty().WithMessage("A data de abastecimento precisa ser informada");

            RuleFor(a => a.TipoCombustivelId)
                .NotNull().WithMessage("É necessário informar o tipo do combustível");

            RuleFor(a => a.ClienteId)
                .NotEmpty().WithMessage("É necessário informar o cliente");

            RuleFor(a => a.VeiculoId)
                .NotEmpty().WithMessage("É necessário informar o veículo");
            
        }
    }
}

