using PostoGasolina.Business.Notificacoes;
using System.Collections.Generic;

namespace PostoGasolina.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacao> ObterNotificacoes();

        void Handle(Notificacao notificacao);
    }
}
