using PostoGasolina.Business.Models.Enums;
using System;

namespace PostoGasolina.Business.Models
{
    public class Combustivel : Entity
    {
        public TipoCombustivel TipoCombustivel { get; set; }
        public decimal Valor { get; set; }

    }
}
