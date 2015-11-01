using System;

namespace qPatterns.Core.Repository
{
    public interface IReadOnlyGuidKeyedRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity FindBy(Guid id);
    }
}
