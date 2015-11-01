namespace qPatterns.Core.Repository
{
    public interface IRepositoryIntKeyed<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(int id);
    }
}
