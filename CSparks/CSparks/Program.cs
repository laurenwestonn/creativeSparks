using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSparks
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

            System.Console.WriteLine("Wahey");
        }
        
        void populatePhrases(); 
	    {
		    //populate the global static 'phrase' as harcoded
	    }

	    string createSpeech() 
	    {
		    //get the first phrase randomly
		    string opener = startSpeech();
		    //
		    addToSpeech(opener);
		    return "Hi there"
	    }

	    string startSpeech() 
	    {
		    int totallyARandomNumber = 1;
		    //return phrase.followOn[totallyARandomNumber];

		    return "Hi"
	    }

	    string addToSpeech(string speech, Phrase mostRecentPhrase) {
		    if (mostRecentPhrase == null)
			    return speech;
		
		    mostRecentPhrase.getNextPhrase();
	    }

    }

    class Phrase
    {
	    string message;
	    string[] followOn;

	    public Phrase(string message, Phrase[] followOn) 
	    {
		    message = message;
		    followOn = followOn;
	    }

	    public Phrase getNextPhrase() 
	    {
		    System.Console.WriteLine("Please enter the number of the phrase you'd like next");

		    int count = 1;
		    foreach (Phrase nextPhrase in followOn) {
			    System.Console.WriteLine(count + ": " + nextPhrase.message);
			    count++;
		    }


		    //prompt user for a number regarding the phrase they'd like to say
		    input = 1;
		    //while input isn't numerical and isnt less than count, keep prompting

		    //return the chosen phrase
		    return this.followOn[input];
	    }
    }
}
