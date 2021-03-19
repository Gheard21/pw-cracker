using System;
using System.IO;
using EsetChallenge.Models;
namespace EsetChallenge
{
    class Program
    {
        static void Main(string[] args) => Array.ForEach(Directory.GetFiles(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/passwords", "*.txt"), file => new Passcode(file).PrintResults());
    }
}

