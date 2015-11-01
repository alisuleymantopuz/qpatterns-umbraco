using System;

namespace qPatterns.Core.Specifications
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        public Func<T, bool> Expression { get; private set; }

        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            else
                this.Expression = expression;
        }

        public override bool IsSatisfiedBy(T o)
        {
            return this.Expression(o);
        }
    }  
}
