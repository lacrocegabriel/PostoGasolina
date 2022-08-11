using System;
using System.Collections.Generic;

namespace PostoGasolina.Business.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime DataCadastro { get; set; }
        public IEnumerable<Veiculo> Veiculos { get; set; }
        public IEnumerable<Abastecimento> Abastecimentos { get; set; }
        public bool Ativo { get; set; }

    }
}