using System.Collections.Generic;

namespace ComparerDecoratorTest
{
    public class ChainComparer<T> : IComparer<T>
    {
        private readonly List<IComparer<T>> _comparers = new List<IComparer<T>>();

        public ChainComparer(IEnumerable<IComparer<T>> comparers)
        {
            foreach (var c in comparers)
            {
                _comparers.Add(c);
            }
        }

        public int Compare(T x, T y)
        {
            foreach (var c in _comparers)
            {
                int result = c.Compare(x, y);

                if (result != 0)
                {
                    return result;
                }
            }

            return 0;
        }
    }
}