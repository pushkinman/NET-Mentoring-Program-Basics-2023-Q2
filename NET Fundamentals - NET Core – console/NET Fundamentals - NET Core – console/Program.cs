using System;
using GreetingLibrary;

namespace NET_Fundamentals___NET_Core___console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length > 0 ? Greeting.SayHello(args[0]) : "Please enter a username as a command line parameter.");
        }
    }
}
