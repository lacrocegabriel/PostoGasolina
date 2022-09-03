using PostoGasolina.Business.Models.Enums;
using System;
using System.Collections.Generic;

namespace PostoGasolina.Business.Models
{
    public class Veiculo : Entity
    {
        public Guid ClienteId { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public IdTipoCombustivel TipoCombustivelId { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public bool Ativo { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<Abastecimento> Abastecimentos { get; set; }

    }
}
