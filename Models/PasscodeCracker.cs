using System.Collections.Generic;
using System.Linq;

namespace EsetChallenge.Models
{
    class PasscodeCracker
    {
        public string Passcode { get; set; } = "";
        public List<Element> Elements { get; set; } = new List<Element>();

        public PasscodeCracker(List<string> hints) 
        {
            // Initialise the value of the password to all of the unique numbers in the hints.
            Passcode = string.Join("", hints.Aggregate((sum, val) => sum += val).Distinct().OrderBy(e => e));

            // populate an element for each unique element in the passcode, populating the number
            // of elements that are show previously.
            PopulateElements(hints);

            // order the elements by the amount of previous elements that are found in the hints.
            Elements = Elements.OrderBy(e => e.Previous.Count()).ToList();

            // convert the elements into the newly formed passcode.
            Passcode = string.Join("", Elements.Select(c => c.Character.ToString()));
        }

        public void PopulateElements(List<string> hints)
        {
            Passcode.ToCharArray().ToList().ForEach(c =>
            {
                Elements.Add(new Element(c));
            });

            hints.ForEach(h =>
            {
                var elementOne = Elements.First(e => e.Character == h[0]);
                var elementTwo = Elements.First(e => e.Character == h[1]);
                var elementThree = Elements.First(e => e.Character == h[2]);

                elementTwo.Previous.Add(h[0]);

                elementThree.Previous.AddRange(new List<char> { h[0], h[1] });

                elementTwo.Previous = elementTwo.Previous.Distinct().ToList();
                elementThree.Previous = elementThree.Previous.Distinct().ToList();
            });
        }
    }
}
