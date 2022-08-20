using Microsoft.AspNetCore.Mvc;
using PostoGasolina.Business.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostoGasolina.App.ViewModels
{
    public class VeiculoViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public bool Ativo { get; set; }
        public ClienteViewModel Cliente { get; set; }
        public IEnumerable<AbastecimentoViewModel> Abastecimentos { get; set; }
        public Guid ClienteId { get; set; }

    }
}