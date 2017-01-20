using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Phrase
    {
        public string currentPhrase { get; set; }
        public List<Phrase> followOn { get; set; }
        public int rating { get; set; }

        public Phrase(string setCurrentPhrase, List<Phrase> setFollowOn, int setRating)
        {
            currentPhrase = setCurrentPhrase;
            followOn = setFollowOn;
            rating = setRating;
        }

        public Phrase getNextPhrase()
        {
            Console.WriteLine("Please enter the number of the phrase you'd like next");

            int count = 1;
            foreach (Phrase nextPhrase in followOn)
            {
                Console.WriteLine(count + ": " + nextPhrase.currentPhrase);
                count++;
            }


            //prompt user for a number regarding the phrase they'd like to say
            int input = 1;
            //while input isn't numerical and isnt less than count, keep prompting

            //return the chosen phrase
            return this.followOn[input];
        }
    }
}
