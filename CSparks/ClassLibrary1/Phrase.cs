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
        public int generalRating { get; set; }
        public List<int> impresses { get; set; }
        public List<int> offends { get; set; }

        public Phrase(string setCurrentPhrase, List<Phrase> setFollowOn, int setGeneralRating, List<int> setImpresses, List<int> setOffends)
        {
            currentPhrase = setCurrentPhrase;
            followOn = setFollowOn;
            generalRating = setGeneralRating;
            impresses = setImpresses;
            offends = setOffends;
        }

        public static void printCurrentPhrases(List<Phrase> listOfPhrases)
        {
            if (listOfPhrases == null)
                return;

            int count = 1;

            foreach (Phrase phrase in listOfPhrases)
            {
                Console.WriteLine(count + ": " + phrase.currentPhrase);
                count++;
            }
        }

        public static void printNextPhrases(Phrase phrase)
        {
            if (phrase == null)
                return;
            if (phrase.followOn == null)
            {
                Console.WriteLine("There are no more phrases after this one.");
                return;
            }

            //Print this phrase
            Console.WriteLine(phrase.currentPhrase + "...\n");

            //Print the next possible phrases
            int count = 1;

            foreach (Phrase followOnPhrase in phrase.followOn)
            {
                Console.WriteLine("" + count + ": " + followOnPhrase.currentPhrase);
                count++;
            }
        }
    }
}
