using PostoGasolina.Business.Models.Enums;
using System;

namespace PostoGasolina.Business.Models
{
    public class Combustivel : Entity
    {
        public TipoCombustivel TipoCombustivel { get; set; }
        public decimal Valor { get; set; }
        public float SaldoLitragem { get; set; }
        public DateTime DataInativacao { get; set; }
        public string MotivoInativacao { get; set; }
        public bool Ativo { get; set; }

    }
}
