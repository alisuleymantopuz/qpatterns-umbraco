using System;

namespace qPatterns.Core.Repository
{
    public interface IRepositoryGuidKeyed<TEntity> : IRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(Guid id);
    }
}
