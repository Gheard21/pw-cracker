using EsetChallenge.Models;
using System;
using System.IO;
using System.Linq;

namespace EsetChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "/passwords"), "*.txt");

            foreach (var file in files)
            {
                var hints = File.ReadAllLines(file).ToList();

                var passcodeCracker = new PasscodeCracker(hints);

                Console.WriteLine(passcodeCracker.Passcode);
            }
        }
    }
}
