namespace Infrastructure.DomainBaseClasses
{
    public class DefaultCommandExecutor : ICommandExecutor
    {
        public void Execute(Command cmd)
        {
            cmd.Execute();
        }
    }
}