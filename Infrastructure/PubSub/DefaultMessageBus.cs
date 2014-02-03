using System;
using System.Collections.Generic;

namespace Infrastructure.PubSub
{
    public class DefaultMessageBus : IMessageBus
    {
        public delegate void HandlerOfEvent(Event eventToSend);

        private readonly Dictionary<Type, List<HandlerOfEvent>> _subscribers;

        public DefaultMessageBus()
        {
            _subscribers = new Dictionary<Type, List<HandlerOfEvent>>();
        }

        public void Unsubscribe(Type eventType)
        {
            throw new NotImplementedException();
        }

        public void Send(Event someEvent)
        {
            List<HandlerOfEvent> currentSubscribers = _subscribers[someEvent.GetType()];

            if (currentSubscribers != null)
            {
                foreach (HandlerOfEvent currentSubscriber in currentSubscribers)
                {
                    currentSubscriber.DynamicInvoke(someEvent);
                }
            }
        }

        public void Subscribe(Type eventType, HandlerOfEvent listener)
        {
            if (_subscribers.ContainsKey(eventType) == false)
            {
                _subscribers.Add(eventType, new List<HandlerOfEvent>());
            }

            List<HandlerOfEvent> currentSubscribers = _subscribers[eventType];

            if (currentSubscribers.Contains(listener) == false)
            {
                currentSubscribers.Add(listener);
            }
        }
    }
}