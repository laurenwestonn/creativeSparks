using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace cSparks
{
    class cSparks
    {
        //Global static var to hold all phrases
        //Accessible everywhere
        public static Phrase phraseA = new Phrase("pigeon", null);
        public static Phrase phraseB = new Phrase("are standing on my shoe", null);
        public static List<Phrase> arrayA;
        //arrayA.Add(phraseA);
        //arrayA.Add(phraseB);
        public static Phrase phrase = new Phrase("Hello you ", arrayA);

        static void Main(string[] args)
        {
            //have static class with one instance of a phrase
            populatePhrases();

            //recursive method to write one speech
            string speech = createSpeech();

            printNextPhrases(World.phraseList(0));

            Console.WriteLine(speech);
            Console.WriteLine("Press any button to close");
            Console.ReadKey();
        }

        private static void printNextPhrases(Phrase phrase)
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
            int count=1;

            foreach (Phrase followOnPhrase in phrase.followOn) {
                Console.WriteLine("" + count + ": " + followOnPhrase.currentPhrase);
                count++;
            }
        }
        
        private static void populatePhrases()
	    {
		    //populate the global static 'phrase' as harcoded

	    }

	    private static string createSpeech() 
	    {
		    //get the first phrase randomly
		    string opener = startSpeech();
		    //
		    //addToSpeech(opener);
            return "Hi there";
	    }

	    private static string startSpeech() 
	    {
		    int totallyARandomNumber = 1;
		    //return phrase.followOn[totallyARandomNumber];

            return "Hi";
	    }

	    private static string addToSpeech(string speech, Phrase mostRecentPhrase) {
            if (mostRecentPhrase == null)
                return speech;
            else
                return "Gotta add to " + speech;
		
		    mostRecentPhrase.getNextPhrase();
	    }

    }

}
