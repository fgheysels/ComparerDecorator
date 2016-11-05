using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparerDecoratorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region setup some test-data

            var persons = new[]
            {
                new Person {Name = "Frederik", Age = 38},
                new Person {Name = "Nahim", Age = 39},
                new Person {Name = "Bert", Age = 27},
                new Person {Name = "Jeroen", Age = 25},
                new Person {Name = "Tania", Age = 42},
                new Person {Name = "Koen", Age = 25},
                new Person {Name = "Cedric", Age = 6},
                new Person {Name = "Mathias", Age = 6},
                new Person {Name = "Margot", Age = 4},
                new Person {Name = "Simon", Age = 38},
                new Person {Name = "Barbara", Age = 39},
                new Person {Name = "Jeroen", Age = 25},
                new Person {Name = "Jeroen", Age = 26}
            };

            #endregion

            Array.Sort(persons, PersonSorters.ByName);

            Console.WriteLine("NameSort:");

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }

            Console.WriteLine();
            Console.WriteLine("AgeSort:");

            Array.Sort(persons, PersonSorters.ByAge);

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }

            Console.WriteLine();
            Console.WriteLine("Name, then by Age, using the ChainComparer:");

            Array.Sort(persons, new ChainComparer<Person>(new[] { PersonSorters.ByName, PersonSorters.ByAge }));

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Name} - {p.Age}");
            }           

            Console.WriteLine("Sorting persons via Decorators");

            Array.Sort(persons, PersonSorters.ByName.ThenBy(PersonSorters.ByAge).Reverse());
            Console.WriteLine("Persons sorted by name, then by age, then reversed");

            foreach (var p in persons)
            {
                Console.WriteLine(p);
            }


            Console.ReadLine();

        }
    }
}
