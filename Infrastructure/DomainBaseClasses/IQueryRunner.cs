namespace mikkark.SCA.Infra.DomainBaseClasses
{
    public interface IQueryRunner
    {
        TResult ExecuteQuery<TResult>(Query<TResult> query);
    }
}