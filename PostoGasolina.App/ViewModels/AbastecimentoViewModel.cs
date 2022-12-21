using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PostoGasolina.Business.Models;
using PostoGasolina.Business.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PostoGasolina.App.ViewModels
{
    [JsonObject(IsReference = true)]
    public class AbastecimentoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public float Litragem { get; set; }
        public decimal ValorLitro { get; set; }
        public int TipoCombustivelId { get; set; }
        public TipoCombustivelViewModel TipoCombustivel { get; set; }
        public DateTime? DataAbastecimento { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
        [HiddenInput]
        public Guid ClienteId { get; set; }
        [HiddenInput]
        public Guid VeiculoId { get; set; }

    }
}
