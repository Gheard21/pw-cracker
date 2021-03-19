using System;
using System.Collections.Generic;

namespace EsetChallenge.Models
{
    public class Digit : IComparable<Digit>
    {
        public char Number { get; set; }
        
        // A HashSet is used to make sure we only store each unqiue value add to the list of previous numbers.  
        public HashSet<char> PreviousNumbers { get; set; } = new HashSet<char>();

        public Digit(char number) => Number = number;

        // The IComparable interface has been implemented to allow for easy sorting of the passcode in Passcode.cs
        public int CompareTo(Digit other)
        {
            if (PreviousNumbers.Count > other.PreviousNumbers.Count)
                return 1;
            else if (PreviousNumbers.Count < other.PreviousNumbers.Count)
                return -1;
            else
                return 0;
        }
    }
}