using PersonReader.Interface;
using System;

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

        static void FetchData()
        {
            WriteLine();
            WriteLine("=================");

            IPersonReader reader = ReaderFactory.GetReader();

            var people = reader.GetPeople();
            foreach (var person in people)
                WriteLine(person.ToConsoleRecord());

            WriteLine("=================");

            ShowReaderType(reader);

            WriteLine("=================");
            WriteLine();
            WriteLine("Press any key to continue...");
            ReadKey();
        }
        private static void ShowReaderType(IPersonReader reader)
        {
            WriteLine($"Reader Type: {reader.GetType()}");
        }

        private static bool ShowMenu()
        {
            Clear();
            WriteLine("Choose an option:");
            WriteLine("1) Use Dynanic Data Reader");
            WriteLine("2) Exit");
            Write("\r\nSelect an option: ");

            switch (ReadKey().Key)
            {
                case ConsoleKey.D1:
                    FetchData();
                    return true;
                case ConsoleKey.D2:
                    return false;
                default:
                    return true;
            }
        }
    }
}
