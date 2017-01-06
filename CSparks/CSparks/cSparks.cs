﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSparks
{
    class cSparks
    {
        //Global static var to hold all phrases
        //Accessible everywhere
        public static Phrase phraseA = new Phrase("pigeon", null);
        public static Phrase phraseB = new Phrase("are standing on my shoe", null);
        public static Phrase[] arrayA = {phraseA, phraseB};
        public static Phrase phrase = new Phrase("Hello you ", arrayA);

        static void Main(string[] args)
        {
            //have static class with one instance of a phrase
            populatePhrases();

            //recursive method to write one speech
            string speech = createSpeech();

            printNextPhrases(phrase);

            Console.WriteLine(speech);
            Console.WriteLine("Press any button to close");
            Console.ReadKey();
        }

        private static void printNextPhrases(Phrase phrase)
        {
            if (phrase == null)
                return;
            if (phrase.getFollowOns() == null)
            {
                Console.WriteLine("There are no more phrases after this one.");
                return;
            }

            //Print this phrase
            Console.WriteLine(phrase.getCurrentPhrase() + "...\n");

            //Print the next possible phrases
            int count=1;

            foreach (Phrase followOnPhrase in phrase.getFollowOns()) {
                Console.WriteLine("" + count + ": " + followOnPhrase.getCurrentPhrase());
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

    class Phrase
    {
	    string currentPhrase;
	    Phrase[] followOn;

	    public Phrase(string setCurrentPhrase, Phrase[] setFollowOn) 
	    {
            currentPhrase = setCurrentPhrase;
            followOn = setFollowOn;
        }

        public Phrase[] getFollowOns()
        {
            return followOn;
        }

        public void setFollowOn(Phrase[] arrPhrase)
        {
            followOn = arrPhrase;
        }

        public string getCurrentPhrase()
        {
            return currentPhrase;
        }

        public void setCurrentPhrase(string newPhrase)
        {
            currentPhrase = newPhrase;
        }

	    public Phrase getNextPhrase() 
	    {
		    Console.WriteLine("Please enter the number of the phrase you'd like next");

		    int count = 1;
		    foreach (Phrase nextPhrase in followOn) {
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