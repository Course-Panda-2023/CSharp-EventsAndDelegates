using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryWatcher
{
    class Program
    {
        public static void Main(string[] args)
        {
            string myPath = "C:\\Users\\dan-client\\Desktop";

            Console.WriteLine("hello panda");

            DirectoryWatcherFactory dwf = new DirectoryWatcherFactory(GetFiles);
            DirectoryWatcher dw = dwf.Create(myPath);
            dw.start();
            Console.ReadLine();
            dw.stop();
            Console.ReadLine();
        }
        static List<string> GetFiles(string path)
        {

            string[] files = Directory.GetFiles(path);
            foreach (string file in files) { Console.WriteLine(file); }
            List<string> fileList = new List<string>();
            fileList.AddRange(files);
            return fileList;
        }
    }
}
    


