using Infrastructure.PubSub;

namespace Infrastructure.DomainBaseClasses
{
    public abstract class Command
    {
        public Command()
        {
            MessageBus = MessageBusServiceInstantiator.MessageBus;
            CommandExecutor = new DefaultCommandExecutor();
            QueryRunner = new DefaultQueryRunner();
        }

        public IMessageBus MessageBus { get; set; }

        public IQueryRunner QueryRunner { get; set; }

        public ICommandExecutor CommandExecutor { get; set; }
        public abstract void Execute();

        protected void ExecuteCommand(Command cmd)
        {
            cmd.MessageBus = MessageBus;

            CommandExecutor.Execute(cmd);
        }

        protected TResult ExecuteCommand<TResult>(Command cmd) where TResult : new()
        {
            return new TResult();
        }
    }
}