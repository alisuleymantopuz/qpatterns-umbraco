namespace qPatterns.Core.Repository
{
    public interface IReadOnlyIntKeyedRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(int id);
    }
}
