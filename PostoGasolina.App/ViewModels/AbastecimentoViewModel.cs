using Microsoft.AspNetCore.Mvc;
using PostoGasolina.Business.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PostoGasolina.App.ViewModels
{
    public class AbastecimentoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public float Litragem { get; set; }
        public decimal ValorLitro { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public DateTime DataAbastecimento { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public VeiculoViewModel Veiculo { get; set; }
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }

    }
}
