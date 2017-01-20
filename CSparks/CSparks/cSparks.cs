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
            //recursive method to write our your first speech
            string speech = createSpeech();

            Console.Write("Here is your phrase\n" + speech);

            Console.WriteLine("\n\nPress any button to close");
            Console.ReadKey();
        }

        private static void printCurrentPhrases(List<Phrase> listOfPhrases)
        {
            if (listOfPhrases == null)
                return;

            int count=1;

            foreach (Phrase phrase in listOfPhrases)
            {
                Console.WriteLine(count + ": " + phrase.currentPhrase);
                count++;
            }
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
            string speech;

		    //choose the first phrase
		    Phrase opener = new Phrase("Default phrase, you shouldn't see this",null);
            startSpeech(ref opener);

            //Build up the string for your speech
            speech = opener.currentPhrase;

            Console.WriteLine("\n\n" + opener.currentPhrase + "...");
            printCurrentPhrases(opener.followOn);

		    //addToSpeech(opener);

            return speech;
	    }

	    private static void startSpeech(ref Phrase phrase)
        {
            //The number you press
            int choice=-1;
            //You haven't yet chosen the next phrase
            bool notChosenNextPhrase = true;

            //Ask the user to chose the next phrase from a few that are printed out. Repeat until user chooses one
            while (notChosenNextPhrase)
            {
                printCurrentPhrases(World.getFirstPhraseList());

                choice = isKeyPressNumeric(Console.ReadKey());

                //check if you've made a valid choice, if so, exit the loop
                if (choice > 0 & choice <= World.getFirstPhraseList().Count)
                {
                    notChosenNextPhrase = false; //next phrase is now chose, continue
                }
                else
                    Console.WriteLine("\nChoose a numbered phrase. You chose " + choice);
            }

            phrase = World.getFirstPhraseList()[choice-1];
	    }

        private static string addToSpeech(string speech, Phrase mostRecentPhrase)
        {
            if (mostRecentPhrase == null)
                return speech;
            else
                return "Gotta add to " + speech;

            mostRecentPhrase.getNextPhrase();
        }

        private static int isKeyPressNumeric(ConsoleKeyInfo keyPress)
        {
            //Returns -1 if the key is not numeric
            int choice = -1;

            //Convert to int if you pressed a number
            if (char.IsDigit(keyPress.KeyChar))
                choice = int.Parse(keyPress.KeyChar.ToString());

            return choice;
        }

    }

}
