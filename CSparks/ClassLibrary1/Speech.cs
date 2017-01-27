using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Speech
    {
        public static string createWholeSpeech(Dateable date)
        {
            string speech;

            //choose the first phrase
            Phrase opener = new Phrase("", null, -100, null, null);
            startSpeech(ref opener, date);

            //Build up the string for your speech
            speech = opener.currentPhrase;

            speech = addToSpeech(opener.currentPhrase, opener, date);

            return speech;
        }

        public static void startSpeech(ref Phrase phrase, Dateable date)
        {
            //The number you press
            int choice = -1;
            //You haven't yet chosen the next phrase
            bool notChosenNextPhrase = true;

            //Ask the user to chose the next phrase from a few that are printed out. Repeat until user chooses one
            while (notChosenNextPhrase)
            {
                Phrase.printCurrentPhrases(World.getFirstPhraseList());

                choice = isKeyPressNumeric(Console.ReadKey());

                //check if you've made a valid choice, if so, exit the loop
                if (choice > 0 & choice <= World.getFirstPhraseList().Count)
                    notChosenNextPhrase = false; //next phrase is now chosen, continue
            }

            phrase = World.getFirstPhraseList()[choice - 1];

           World.amendScore(phrase, date);
        }

        public static string addToSpeech(string speech, Phrase mostRecentPhrase, Dateable date)
        {
            //Base Case
            //If there's no follow on phrases, return the speech as it is
            if (mostRecentPhrase.followOn == null)
                return speech;

            //Recursive case
            //Print out next phrase options

            //The number you press
            int choice = -1;
            //You haven't yet chosen the next phrase
            bool notChosenNextPhrase = true;

            //Ask the user to chose the next phrase from a few that are printed out. Repeat until user chooses one
            while (notChosenNextPhrase)
            {
                Console.WriteLine("\n\n" + speech + "...");
                Phrase.printCurrentPhrases(mostRecentPhrase.followOn);

                choice = isKeyPressNumeric(Console.ReadKey());

                //check if you've made a valid choice, if so, exit the loop
                if (choice > 0 & choice <= mostRecentPhrase.followOn.Count)
                    notChosenNextPhrase = false; //next phrase is now chosen, continue
            }

            //User has made a valid choice. Get append the text of the next phrase to the speech
            speech = speech + mostRecentPhrase.followOn[choice - 1].currentPhrase;

            if (mostRecentPhrase.followOn[choice - 1].generalRating < 0)
            {
                //update the rating here
                Console.WriteLine("\n\nAre you sure you wanna say that?");
            }

            World.amendScore(mostRecentPhrase.followOn[choice - 1], date);

            //Add any further speeches
            return addToSpeech(speech, mostRecentPhrase.followOn[choice - 1], date);

        }

        public static int isKeyPressNumeric(ConsoleKeyInfo keyPress)
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
