using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class World
    {
        //populate here, access in the game cSparks
        public static readonly List<Phrase> phraseList = new List<Phrase>();

        static World()
        {
            populatePhrases();
        }

        public static List<Phrase> getFirstPhraseList()
        {
            return phraseList;
        }

        private static void populatePhrases()
        {
            //AA FOLLOW ONS (Hey you are...)
            Phrase AAA = new Phrase("okay ", 
                            makeLastPhraseList("enough for me.", "to leave.", "for someone else."));
            Phrase AAB = new Phrase("rough ", null);
            Phrase AAC = new Phrase("sensitive ", null);

            //AB FOLLOW ONS (Hey how did...)
            Phrase ABA = new Phrase("your dog die?", null);
            Phrase ABB = new Phrase("you get here?", null);
            Phrase ABC = new Phrase("you know we'd be perfect?", null);

            //AC FOLLOW ONS (Hey I want...)
            Phrase ACA = new Phrase("you.", null);
            Phrase ACB = new Phrase("to go.", null);
            Phrase ACC = new Phrase("my meemaw.", null);


            //A FOLLOW ONS
            Phrase AA = new Phrase("you are ", new List<Phrase>{AAA,AAB,AAC});
            Phrase AB = new Phrase("how did ", new List<Phrase>{ABA,ABB,ABC});
            Phrase AC = new Phrase("I want ",  new List<Phrase>{ACA,ACB,ACC});

            //Now we have follow on phrases for A, we can make the first phrase: A. Make the other openers too
            Phrase A = new Phrase("Hey ", new List<Phrase>{AA,AB,AC});
            Phrase B = new Phrase("Yo ", null);
            Phrase C = new Phrase("Howdy ", null);

            //Put each of the speeches into a list. This will be used in the game.
            phraseList.Add(A);
            phraseList.Add(B);
            phraseList.Add(C);
        }


        //Puts three strings into a list of phrases that have no follow on phrases
        //make this generic: for args.length
        public static List<Phrase> makeLastPhraseList(string A, string B, string C)
        {
            //Make the phrases that follow on
            Phrase pA = new Phrase(A, null);
            Phrase pB = new Phrase(B, null);
            Phrase pC = new Phrase(C, null);

            //Put the follow on phrases in a list to return
            //Which one of the below work? Second two don't need the above
            return new List<Phrase>(new Phrase[]{pA,pB,pC});
            //return new List<Phrase>(new Phrase[]{new Phrase(A, null),new Phrase(B, null),new Phrase(C, null)});
            //return new List<Phrase>{new Phrase(A, null),new Phrase(B, null),new Phrase(C, null)};

        }
    }
}
