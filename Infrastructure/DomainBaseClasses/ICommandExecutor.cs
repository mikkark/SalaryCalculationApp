namespace mikkark.SCA.Infra.DomainBaseClasses
{
    public interface ICommandExecutor
    {
        void Execute(Command cmd);
    }
}