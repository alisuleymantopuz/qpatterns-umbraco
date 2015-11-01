namespace qPatterns.Core.Storage
{
    public interface IStorageStrategy<in TKey, TValue>
    {
        void Put(TKey key, TValue value);

        TValue Get(TKey key);

        void Remove(TKey key);
    }
}
