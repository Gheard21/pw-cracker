using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EsetChallenge.Models;

namespace EsetChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Clear the console to make the results more immediatly readable.
            Console.Clear();

            //  Get the path to the passwords directory.
            var path = Directory.GetCurrentDirectory() + @"\passwords";

            //  Retrieve all .txt files in the passwords directory.
            var files = Directory.GetFiles(path, "*.txt");

            Array.ForEach<string>(files, file =>
            {
                //  Read all the text from the file and remove any empty lines from the beginning and end of the file.
                var data = File.ReadAllText(file).Trim();

                /*
                    Remove all the new lines from a copy of the data and replace them with an empty string so that we get 
                    a continuous string of alphanumeric characters. We can then select all the unique characters and create 
                    a list of digits from this.
                */
                var passcode = data.Replace(Environment.NewLine, "").Distinct().Select(d => new Digit(d)).ToList();

                /*
                    Split the file into the individual passcode hints, for the second element in the hint, add the previous
                    element to it's PreviousNumbers property. Do similiar for the third property, but add both prior elements.
                */
                data.Split(Environment.NewLine).ToList().ForEach(hint =>
                {
                    passcode.First(d => d.Number == hint[1]).PreviousNumbers.Add(hint[0]);
                    passcode.First(d => d.Number == hint[2]).PreviousNumbers.UnionWith(new HashSet<char>() { hint[0], hint[1] });
                });

                //  Order each digit in the passcode by the total amount of previous numbers in the Digits PreviousNumbers property.
                passcode = passcode.OrderBy(d => d.PreviousNumbers.Count()).ToList();

                Console.WriteLine($"Filename: {Path.GetFileName(file)}");
                Console.Write("Passcode: ");
                passcode.ForEach(d => Console.Write(d.Number));
                Console.WriteLine(Environment.NewLine);
            });
        }
    }
}

