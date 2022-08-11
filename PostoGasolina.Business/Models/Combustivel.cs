using PostoGasolina.Business.Models.Enums;

namespace PostoGasolina.Business.Models
{
    public class Combustivel : Entity
    {
        public TipoCombustivel TipoCombustivel { get; set; }
        public decimal Valor { get; set; }
        public float SaldoLitragem { get; set; }

    }
}
