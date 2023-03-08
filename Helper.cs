using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_EventsAndDelegates
{
    internal class Helper
    {
        public static void GetFileNamesInFolder(string path)
        {
            DirectoryInfo di = new DirectoryInfo(@"D:\folder");
            FileInfo[] files = di.GetFiles();
            string str = "";
            foreach (FileInfo file in files)
            {
                Console.WriteLine(file.Name);
            }
        }
    }
}
