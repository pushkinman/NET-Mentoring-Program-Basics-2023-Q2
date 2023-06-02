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
        public event Func<string, bool> FilteredFileFound;
        public event Func<string, bool> FilteredDirectoryFound;

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
            OnStart(rootFolder);

            foreach (var item in TraverseDirectory(rootFolder))
            {
                yield return item;
            }

            OnFinish(rootFolder);
        }

        private IEnumerable<string> TraverseDirectory(string folderPath)
        {
            if (DirectoryFound != null)
            {
                OnDirectoryFound(folderPath);
            }

            foreach (var file in Directory.GetFiles(folderPath))
            {
                if (FileFound != null)
                {
                    OnFileFound(file);
                }

                if (filter == null || (FilteredFileFound != null && FilteredFileFound(file)))
                {
                    yield return file;
                }
            }

            foreach (var directory in Directory.GetDirectories(folderPath))
            {
                if (DirectoryFound != null)
                {
                    OnDirectoryFound(directory);
                }

                if (filter == null || (FilteredDirectoryFound != null && FilteredDirectoryFound(directory)))
                {
                    yield return directory;
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            string rootFolder = @"C:\Users\Anton\Downloads";
            var visitor = new FileSystemVisitor(rootFolder, path => path.Contains(".txt"));

            visitor.Start += path => Console.WriteLine($"Start: {path}");
            visitor.Finish += path => Console.WriteLine($"Finish: {path}");
            visitor.FileFound += path => Console.WriteLine($"File Found: {path}");
            visitor.DirectoryFound += path => Console.WriteLine($"Directory Found: {path}");
            visitor.FilteredFileFound += path =>
            {
                Console.WriteLine($"Filtered File Found: {path}");
                return true;
            };
            visitor.FilteredDirectoryFound += path =>
            {
                Console.WriteLine($"Filtered Directory Found: {path}");
                return true;
            };

            foreach (var item in visitor.Traverse())
            {
                Console.WriteLine(item);
            }
        }
    }
}
