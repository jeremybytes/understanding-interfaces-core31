using Common;
using People.Library;
using System;
using System.Collections.Generic;
using static System.Console;

namespace PeopleViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (ShowMenu()) { }
            WriteLine();
        }

        private static void FetchWithConcreteType()
        {
            WriteLine();
            WriteLine("=================");

            List<Person> people;

            var reader = new PersonReader();
            people = reader.GetPeople();
            foreach (var person in people)
                WriteLine(person.ToConsoleRecord());

            WriteLine("=================");
            WriteLine();
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private static void FetchWithAbstractType()
        {
            WriteLine();
            WriteLine("=================");

            IEnumerable<Person> people;

            var reader = new PersonReader();
            people = reader.GetPeople();
            foreach (var person in people)
                WriteLine(person.ToConsoleRecord());

            WriteLine("=================");
            WriteLine();
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        private static bool ShowMenu()
        {
            Clear();
            WriteLine("Choose an option:");
            WriteLine("1) Use Concrete Type");
            WriteLine("2) Use Abstraction");
            WriteLine("3) Exit");
            Write("\r\nSelect an option: ");

            switch (ReadKey().Key)
            {
                case ConsoleKey.D1:
                    FetchWithConcreteType();
                    return true;
                case ConsoleKey.D2:
                    FetchWithAbstractType();
                    return true;
                case ConsoleKey.D3:
                    return false;
                default:
                    return true;
            }
        }
    }
}
