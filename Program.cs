
using System.Collections.ObjectModel;
using System.Xml.Serialization;

class Program
{
    public static List<string> textFilesInPath(string dirPath)
    {
        List<string> textFiles = new List<string>();
        
        foreach(string fileName in Directory.GetFiles(dirPath))
        {
            if (fileName.EndsWith(".txt"))
                textFiles.Add(fileName);
        }
        return textFiles;
    }
    public static void Main(string[] args)
    {
        // FilesInPaths fip = textFilesInPath;
        // DirectoryWatcher directoryWatcher = new DirectoryWatcher("C:/Users/HILLEL/Desktop/test", fip);

        // EX1
        // FaultTolerant.EX1(FaultTolerant.ExceptionThrower, probabilty : 0.1, max_times : 10);
        
        // EX2
        AlarmClock AC = new AlarmClock();
        AC.EX2(DateTime.Now.AddSeconds(10), AlarmClock.PrintYearsFrom2000);
        
        // EX3
        // Collection<int> numbers = new Collection<int>{1, 2, 3, 4, 5, 6};
        // List<MathOp> funcs = new List<MathOp>() {CollectionsAndFunctions.SquareNumber,
        //                                         CollectionsAndFunctions.SqrtNumber,
        //                                         CollectionsAndFunctions.Sin,
        //                                         CollectionsAndFunctions.Cos};
        // CollectionsAndFunctions.EX3(numbers, funcs);

    }

    
    
}
