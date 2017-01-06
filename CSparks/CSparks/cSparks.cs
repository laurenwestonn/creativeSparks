using System;
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
        public Phrase phrase;

        static void Main(string[] args)
        {
            //have static class with one instance of a phrase
            populatePhrases();

            //recursive method to write one speech
            string speech = createSpeech();

            Console.WriteLine(speech);
            Console.WriteLine("Press any button to close");
            Console.ReadKey();
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
	    string message;
	    Phrase[] followOn;

	    public Phrase(string setMessage, Phrase[] setFollowOn) 
	    {
            message = setMessage;
            followOn = setFollowOn;
	    }

	    public Phrase getNextPhrase() 
	    {
		    Console.WriteLine("Please enter the number of the phrase you'd like next");

		    int count = 1;
		    foreach (Phrase nextPhrase in followOn) {
			    Console.WriteLine(count + ": " + nextPhrase.message);
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
