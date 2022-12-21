using FluentValidation;
using static PostoGasolina.Business.Models.Validations.Documentos.ValidacaoDocumentos.ValidacaoDocs;

namespace PostoGasolina.Business.Models.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Documento)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(11, 14).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.DataCadastro)
                .NotEmpty().WithMessage("O campo Data de Cadastro precisa ser fornecido");


            //When(c => c. == TipoFornecedor.PessoaFisica, () =>
            //{
            //    RuleFor(f => f.Documento.Length).Equal(CpfValidacao.TamanhoCpf)
            //    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido { PropertyValue}.");
            //    RuleFor(f => CpfValidacao.Validar(f.Documento)).Equal(true).
            //    WithMessage("O documento fornecido é inválido.");
            //});

            //When(f => f.TipoFornecedor == TipoFornecedor.PessoaJuridica, () =>
            //{
            //    RuleFor(f => f.Documento.Length).Equal(CnpjValidacao.TamanhoCnpj)
            //    .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido { PropertyValue}.");
            //    RuleFor(f => CnpjValidacao.Validar(f.Documento)).Equal(true).
            //    WithMessage("O documento fornecido é inválido.");
            //});
        }
    }
}

