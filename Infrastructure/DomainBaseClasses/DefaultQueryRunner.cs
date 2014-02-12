namespace mikkark.SCA.Infra.DomainBaseClasses
{
    public class DefaultQueryRunner : IQueryRunner
    {
        public TResult ExecuteQuery<TResult>(Query<TResult> query)
        {
            return query.Execute();
        }
    }
}