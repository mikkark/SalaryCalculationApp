namespace mikkark.SCA.Infra.PubSub
{
    public static class MessageBusServiceInstantiator
    {
        private static readonly IMessageBus _messageBus = new DefaultMessageBus();

        public static IMessageBus MessageBus
        {
            get { return _messageBus; }
        }
    }
}