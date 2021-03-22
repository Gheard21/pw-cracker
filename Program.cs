using System;
using System.Diagnostics;
using System.IO;
using EsetChallenge.Models;

namespace EsetChallenge
{
    class Program
    {
        /*
            Entry point for the program, all we're doing is looking for all the .txt files
            in the Passwords directory, and then for each one we're newing up a Passcode and
            using the PrintResults method on the Passcode object to display the full passcode.
        */
        static void Main(string[] args) => Array.ForEach(Directory.GetFiles((Debugger.IsAttached ? Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName : Environment.CurrentDirectory) + "/Passwords", "*.txt"), file => new Passcode(file).PrintResults());
    }
}

