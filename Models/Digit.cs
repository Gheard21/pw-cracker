using System.Collections.Generic;

namespace EsetChallenge.Models
{
    public class Digit
    {
        public char Number { get; set; }
        
        // A HashSet is used to make sure we only store each unqiue value add to the list of previous numbers.  
        public HashSet<char> PreviousNumbers { get; set; } = new HashSet<char>();

        public Digit(char number) => Number = number;
    }
}