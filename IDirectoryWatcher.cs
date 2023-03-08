using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryWatcher
{
    public delegate void retFiles(string path);
    internal class IDirectoryWatcher

    {

        public retFiles printAllFiles;


        private string directoryPath;

        private FileSystemWatcher watcher;


        public IDirectoryWatcher (string path ,retFiles r )
        {
            printAllFiles= r;
            this.directoryPath = path;

            watcher = new FileSystemWatcher(directoryPath);
            watcher.IncludeSubdirectories = true;

            // Register event handlers for file system events
            watcher.Created += OnFileChanged;
            watcher.Deleted += OnFileChanged;
            watcher.Renamed += OnFileChanged;
            watcher.Error += OnError;

            watcher.EnableRaisingEvents = true;


        }
        public IDirectoryWatcher(string path, retFiles r,string filter)
        {
            printAllFiles = r;
            this.directoryPath = path;

            watcher = new FileSystemWatcher(directoryPath);
            watcher.Filter= filter;


            // Register event handlers for file system events
            watcher.Created += OnFileChanged;
            watcher.Deleted += OnFileChanged;
            watcher.Renamed += OnFileChanged;
            watcher.Error += OnError;

            watcher.EnableRaisingEvents = true;


        }
        public void OnFileChanged(object sender, FileSystemEventArgs e) 
        {
            OnDirectoryChanged(sender, e);
            Console.WriteLine("\n\n///////////////////\nfiles in directory:\n");
            printAllFiles(directoryPath);
            Console.WriteLine("\n///////////////////\n\n");

        }


        //private void OnFileRenamed(object sender, RenamedEventArgs e)
        //{
        //    OnDirectoryChanged(sender, e);
        //    printAllFiles(directoryPath);
        //}

        private void OnError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine("Error occurred: {0}", e.GetException().Message);
        }

        public void StopTracking()
        {
            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
        }

        public static void PrintFilesInDirectory(string path)
        {
            try
            {
                // Get an array of file paths in the directory
                string[] filePaths = Directory.GetFiles(path);

                // Return only the file names (not the full paths)
                for (int i = 0; i < filePaths.Length; i++)
                {
                    Console.WriteLine(Path.GetFileName(filePaths[i]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error getting file list: " + e.Message);
            }
        }
        private void OnDirectoryChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File {0} {1} at {2}", e.Name, e.ChangeType, e.FullPath);
        }


    }
}
