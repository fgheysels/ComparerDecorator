using System.Collections.Generic;

namespace ComparerDecoratorTest
{
    public static class ComparerDecorators
    {
        public static IComparer<T> Reverse<T>(this IComparer<T> target)
        {
            return new ReverseComparerDecorator<T>(target);
        }

        public static IComparer<T> ThenBy<T>(this IComparer<T> target, IComparer<T> thenBy)
        {
            return new ThenByComparerDecorator<T>(target, thenBy);
        }

        #region Comparer Decorators

        // The decorators are inner private classes.  A user of our decorator should never
        // instantiate the decorater classes directly; instead he should work with the 
        // available extension methods wich will give him a more readable api.

        class ReverseComparerDecorator<T> : IComparer<T>

        {
            private readonly IComparer<T> _comparer;

            public ReverseComparerDecorator(IComparer<T> comparer)
            {
                _comparer = comparer;
            }

            public int Compare(T x, T y)
            {
                return _comparer.Compare(x, y) * -1;
            }
        }

        class ThenByComparerDecorator<T> : IComparer<T>
        {
            private readonly IComparer<T> _comparer;
            private readonly IComparer<T> _thenByComparer;

            public ThenByComparerDecorator(IComparer<T> comparer, IComparer<T> thenByComparer)
            {
                _comparer = comparer;
                _thenByComparer = thenByComparer;
            }

            public int Compare(T x, T y)
            {
                int result = _comparer.Compare(x, y);

                if (result == 0)
                {
                    return _thenByComparer.Compare(x, y);
                }

                return result;
            }
        }

        #endregion
    }
}