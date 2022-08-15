using PostoGasolina.Business.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PostoGasolina.App.ViewModels
{
    public class CombustivelViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public decimal Valor { get; set; }
    }
}
