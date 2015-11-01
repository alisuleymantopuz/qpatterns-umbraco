namespace qPatterns.Core.Specifications
{
    public interface IBusinessSpecificationRule<T>
    {
        BusinessSpecificationResult<T> CheckRules(T instance);
        string Code { get; }
        string Message { get; }
    }
}
