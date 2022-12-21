using PostoGasolina.Business.Models.Enums;
using System;

namespace PostoGasolina.Business.Models
{
    public class Abastecimento : Entity
    {
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public decimal Litragem { get; set; }
        public decimal ValorLitro { get; set; }
        public IdTipoCombustivel TipoCombustivelId { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public DateTime? DataAbastecimento { get; set; }
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }
    }
}
