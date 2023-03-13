// See https://aka.ms/new-console-template for more information

using EventsAndDelegatesEx1;

Console.WriteLine("Hello, World!");
Helper.RunFaultTolerant(Helper.ThrowOcasionallyException, 3);