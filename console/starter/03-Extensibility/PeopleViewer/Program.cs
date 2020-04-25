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

        static void UseWebService()
        {
            WriteLine();
            WriteLine("=================");



            WriteLine("=================");



            WriteLine("=================");
            WriteLine();
            WriteLine("Press any key to continue...");
            ReadKey();
        }

        static void UseCSVFile()
        {

        }

        static void UseSQLDatabase()
        {

        }

        private static void ShowReaderType(IPersonReader reader)
        {
            WriteLine($"Reader Type: {reader.GetType()}");
        }

        private static bool ShowMenu()
        {
            Clear();
            WriteLine("Choose an option:");
            WriteLine("1) Use Web Service");
            WriteLine("2) Use CSV Text File");
            WriteLine("3) Use SQL Database");
            WriteLine("4) Exit");
            Write("\r\nSelect an option: ");

            switch (ReadKey().Key)
            {
                case ConsoleKey.D1:
                    UseWebService();
                    return true;
                case ConsoleKey.D2:
                    UseCSVFile();
                    return true;
                case ConsoleKey.D3:
                    UseSQLDatabase();
                    return true;
                case ConsoleKey.D4:
                    return false;
                default:
                    return true;
            }
        }
    }
}
