using PersonReader.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Loader;

namespace PeopleViewer
{
    public static class ReaderFactory
    {
        public static IPersonReader GetReader()
        {
            LoadAllReaderAssemblies();

            string readerTypeName = ConfigurationManager.AppSettings["ReaderType"];
            Type readerType = Type.GetType(readerTypeName) ?? throw new InvalidOperationException($"Unknown type: {readerTypeName}");
            object reader = Activator.CreateInstance(readerType) ?? throw new InvalidOperationException($"Unable to create instance of type {readerType}");
            IPersonReader personReader = reader as IPersonReader ?? throw new InvalidCastException($"Unable to cast {reader.GetType()} to IPersonReader");
            return personReader;
        }

        public static void LoadAllReaderAssemblies()
        {
            string assemblyPath = AppDomain.CurrentDomain.BaseDirectory + "ReaderAssemblies";

            IEnumerable<string> assemblyFiles = Directory.EnumerateFiles(
                assemblyPath, "*.dll", SearchOption.TopDirectoryOnly);

            foreach (string assemblyFile in assemblyFiles)
            {
                try
                {
                    AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyFile);
                }
                catch (Exception)
                {
                    // Ignore anything that can't be loaded
                }
            }
        }
    }
}
