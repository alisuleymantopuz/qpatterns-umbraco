namespace qPatterns.Core.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public ISpecification<T> LeftSpecification { get; private set; }
        public ISpecification<T> RightSpecification { get; private set; }

        public OrSpecification(ISpecification<T> rightSpecification, ISpecification<T> leftSpecification)
        {
            LeftSpecification = leftSpecification;
            RightSpecification = rightSpecification;
        }


        public override bool IsSatisfiedBy(T o)
        {
                return this.LeftSpecification.IsSatisfiedBy(o)
                         || this.RightSpecification.IsSatisfiedBy(o);
        }
    }
}
