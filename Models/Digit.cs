using System.Collections.Generic;

namespace EsetChallenge.Models
{
    public class Digit
    {
        public char Number { get; set; }
        public HashSet<char> PreviousNumbers { get; set; } = new HashSet<char>();

        public Digit(char number) => Number = number;
    }
}