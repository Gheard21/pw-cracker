using System;
using System.IO;
using System.Linq;

namespace EsetChallenge.Models
{
    public class Passcode
    {
        private string Filename { get; set; }
        private string FileText { get; set; }
        private Digit[] Digits { get; set; }

        public Passcode(string file)
        {
            Filename = Path.GetFileName(file);
            FileText = File.ReadAllText(file).Trim();
            InitDigits();
            ProcessHints();
            Array.Sort(Digits);
        }

        /*
            Get all the unique characters from the file, and for each one new up a Digit object to record all
            the elements that we find when processing the hints that come prior to the one we're currently processing.
        */
        public void InitDigits() => Digits = FileText.Replace(Environment.NewLine, "").Distinct().Select(d => new Digit(d)).ToArray();

        public void PrintResults()
        {
            Console.WriteLine($"Filename: {Filename}");
            Console.Write("Passcode: ");
            Array.ForEach(Digits, d => Console.Write(d.Number));
            Console.WriteLine(Environment.NewLine);
        }

        /*
            Seperate the file into individual hints that are n long. As long as it's not the first element in
            the hint, then add each previous element to the PreviousNumbers hash set for the current item in
            Digits.
        */
        private void ProcessHints() => Array.ForEach(FileText.Split(Environment.NewLine), hint =>
        {
            for (var i = 1; i < hint.Length; i++)
                Digits.First(d => d.Number == hint[i]).PreviousNumbers.UnionWith(hint.Take(i).ToHashSet<char>());
        });
    }
}