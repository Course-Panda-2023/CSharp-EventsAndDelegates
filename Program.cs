// See https://aka.ms/new-console-template for more information
using AdditionalAssignmentsDelegates;
using DirectoryWatcherNameSpace;
using Microsoft.VisualBasic;

//Console.WriteLine("Hello, World!");

//string[] files = IDirectoryWatcher.GetFilesInDirectory(@"C:\Users\mamag2\Desktop\eyal\SQL");
//foreach (string file in files)
//{
//    Console.WriteLine(file);
//}




//string directoryPath = @"C:\Users\mamag2\Desktop\eyal\SQL";
//retFiles func = new retFiles(DirectoryWatcher.PrintFilesInDirectory);
//DirectoryWatcherFactory factory = new DirectoryWatcherFactory();


//DirectoryWatcher tracker = factory.Create(directoryPath, func, "*.txt");
//tracker.startTracking();    
//Console.WriteLine("Tracking directory: {0}", directoryPath); 
//Console.ReadLine();

//tracker.StopTracking();

//////////


//ExceptionFunc myExceptionFunc = Assignments.stam;

////Assignments.func1(5, myExceptionFunc);


//Assignments.func2(new DateTime(2003, 3, 24), Assignments.getAge);

AlarmClock my_alaram = new AlarmClock(DateTime.Now.AddSeconds(4), AlarmClock.GoodMorning);
Console.ReadLine();
// static void print(object obj)
//{
//    Console.WriteLine("object :" + obj);
//}

//voidfunc myfunc = print;
//List<object> mylist = new List<object>() {1,5.3,6,4 };
//Assignments.func4(mylist, myfunc);