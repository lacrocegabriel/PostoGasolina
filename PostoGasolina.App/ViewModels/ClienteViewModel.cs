using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostoGasolina.App.ViewModels
{
    [JsonObject(IsReference = true)]
    public class ClienteViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public DateTime? DataCadastro { get; set; }
        [JsonIgnore]
        public IEnumerable<VeiculoViewModel> Veiculos { get; set; }
        [JsonIgnore]
        public IEnumerable<AbastecimentoViewModel> Abastecimentos { get; set; }
        public bool Ativo { get; set; }
    }
}
