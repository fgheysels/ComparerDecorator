using System.Collections;
using System.Collections.Generic;

namespace ComparerDecoratorTest
{
    public static class PersonSorters
    {
        public static readonly IComparer<Person> ByName = new NameSort();

        public static readonly IComparer<Person> ByAge = new AgeSort();

        private class NameSort : IComparer, IComparer<Person>
        {
            public int Compare(object x, object y)
            {
                Person a = x as Person;
                Person b = y as Person;

                return Compare(a, b);
            }

            public int Compare(Person x, Person y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }

        private class AgeSort : IComparer, IComparer<Person>
        {
            public int Compare(object x, object y)
            {
                Person a = x as Person;
                Person b = y as Person;

                return Compare(a, b);
            }

            public int Compare(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age);
            }
        }
    }
}