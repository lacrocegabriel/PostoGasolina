using Microsoft.EntityFrameworkCore;
using PostoGasolina.Business.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PostoGasolina.Business.Models
{
    //[Keyless]
    public class TipoCombustivel
    {
        [Key]
        public IdTipoCombustivel Id { get; set; }
        public string Descricao { get; set; }
    }
}
