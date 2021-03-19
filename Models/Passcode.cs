using System;
using System.Collections.Generic;
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

        public void InitDigits() => Digits = FileText.Replace(Environment.NewLine, "").Distinct().Select(d => new Digit(d)).ToArray();

        public void PrintResults()
        {
            Console.WriteLine($"Filename: {Filename}");
            Console.Write("Passcode: ");
            Array.ForEach(Digits, d => Console.Write(d.Number));
            Console.WriteLine(Environment.NewLine);
        }

        private void ProcessHints() => Array.ForEach(FileText.Split(Environment.NewLine), hint =>
        {
            Digits.First(d => d.Number == hint[1]).PreviousNumbers.Add(hint[0]);
            Digits.First(d => d.Number == hint[2]).PreviousNumbers.UnionWith(new HashSet<char>() { hint[0], hint[1] });
        });
    }
}