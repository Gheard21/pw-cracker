using System.Collections.Generic;

namespace EsetChallenge.Models
{
    class Element
    {
        public char Character { get; set; }
        public List<char> Previous { get; set; } = new List<char>();

        public Element(char character) => Character = character;
    }
}
