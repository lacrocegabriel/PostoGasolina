using PostoGasolina.Business.Models.Enums;
using System;

namespace PostoGasolina.Business.Models
{
    public class Abastecimento : Entity
    {
        public Cliente Cliente { get; set; }
        public float Litragem { get; set; }
        public decimal ValorLitro { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public DateTime DataAbastecimento { get; set; }
    }
}
