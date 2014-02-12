using System;

namespace mikkark.SCA.Infra.PubSub
{
    public interface IMessageBus
    {
        void Subscribe(Type eventType, DefaultMessageBus.HandlerOfEvent handler);
        void Unsubscribe(Type eventType);
        void Send(Event someEvent);
    }
}