using Microsoft.AspNetCore.Mvc;
using PostoGasolina.Business.Interfaces;
using PostoGasolina.Business.Notificacoes;
using System.Collections.Generic;

namespace PostoGasolina.App.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly INotificador _notificador;

        protected BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();

            
        }
        protected List<Notificacao> Notificacoes()
        {
            return _notificador.ObterNotificacoes();

        }


    }
}
