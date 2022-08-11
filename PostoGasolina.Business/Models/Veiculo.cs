using PostoGasolina.Business.Models.Enums;
using System;

namespace PostoGasolina.Business.Models
{
    public class Veiculo : Entity
    {
        public Guid ClienteId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public bool Ativo { get; set; }
        public Cliente Cliente { get; set; }

    }
}
