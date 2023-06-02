using System;
using System.Collections.Generic;
using System.IO;

namespace Advanced_CSharp
{
    public class FileSystemVisitor
    {
        private readonly string rootFolder;
        private readonly Func<string, bool> filter;

        public event Action<string> Start;
        public event Action<string> Finish;
        public event Action<string> FileFound;
        public event Action<string> DirectoryFound;
        public event Action<string> FilteredFileFound;
        public event Action<string> FilteredDirectoryFound;

        public FileSystemVisitor(string rootFolder)
            : this(rootFolder, null)
        {
        }

        public FileSystemVisitor(string rootFolder, Func<string, bool> filter)
        {
            this.rootFolder = rootFolder;
            this.filter = filter;
        }

        public IEnumerable<string> Traverse()
        {
            if (Directory.Exists(rootFolder) == false)
            {
                Console.WriteLine("The path does not refer to a directory.");
                yield break;
            }

            OnStart(rootFolder);

            foreach (var item in TraverseDirectory(rootFolder))
            {
                yield return item;
            }

            OnFinish(rootFolder);
        }

        private IEnumerable<string> TraverseDirectory(string folderPath)
        {
            foreach (var file in Directory.GetFiles(folderPath))
            {
                if (filter == null || filter(file))
                {
                    OnFilteredFileFound(file);
                }
                else if (FileFound != null)
                {
                    OnFileFound(file);
                }

                yield return file;
            }

            foreach (var directory in Directory.GetDirectories(folderPath))
            {
                if (filter == null || filter(directory))
                {
                    OnFilteredDirectoryFound(directory);
                }
                else if (DirectoryFound != null)
                {
                    OnDirectoryFound(directory);
                }

                foreach (var file in TraverseDirectory(directory))
                {
                    yield return file;
                }
            }
        }


        private void OnStart(string path)
        {
            Start?.Invoke(path);
        }

        private void OnFinish(string path)
        {
            Finish?.Invoke(path);
        }

        private void OnFileFound(string filePath)
        {
            FileFound?.Invoke(filePath);
        }

        private void OnDirectoryFound(string directoryPath)
        {
            DirectoryFound?.Invoke(directoryPath);
        }

        private void OnFilteredFileFound(string filePath)
        {
            FilteredFileFound?.Invoke(filePath);
        }

        private void OnFilteredDirectoryFound(string directoryPath)
        {
            FilteredDirectoryFound?.Invoke(directoryPath);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string rootFolder = @$"C:\Users\{Environment.UserName}\Downloads\Test";
            var visitor = new FileSystemVisitor(rootFolder, path => path.Contains("txt"));

            visitor.Start += path => Console.WriteLine($"Start: {path}");
            visitor.Finish += path => Console.WriteLine($"Finish: {path}");
            visitor.FileFound += path => Console.WriteLine($"File Found: {path}");
            visitor.DirectoryFound += path => Console.WriteLine($"Directory Found: {path}");
            visitor.FilteredFileFound += path =>
            {
                WriteColorText("Filtered File Found: ", ConsoleColor.Green);
                Console.WriteLine(path);
            };
            visitor.FilteredDirectoryFound += path =>
            {
                WriteColorText("Filtered Directory Found: ", ConsoleColor.Green);
                Console.WriteLine(path);
            };

            foreach (var item in visitor.Traverse())
            {
                Console.WriteLine(item);
            }
        }

        static void WriteColorText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
