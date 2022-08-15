using System;

namespace PostoGasolina.App.Models
{
    public class Abastecimento
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
