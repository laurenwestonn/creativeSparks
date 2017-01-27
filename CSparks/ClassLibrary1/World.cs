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
        public static readonly List<Dateable> dates = new List<Dateable>();
        public static int score;

        static World()
        {
            populatePhrases();
            populateDates();
            score = 0;
        }

        //To be used to start a speech
        public static List<Phrase> getFirstPhraseList()
        {
            return phraseList;
        }

        //Fill in the phrases for this world
        private static void populatePhrases()
        {
            //AA FOLLOW ONS (Hey you are...)
            Phrase AAA = new Phrase("okay ",
                            makeLastPhraseList("enough for me.", 1, null, null,
                                                "lets go someplace else!", 7, null, null,
                                                "for someone else.", -1, null, null),
                            -2, null, null);
            Phrase AAB = new Phrase("rough ", null, -6, new List<int> { (int)personality.CHAV }, null);
            Phrase AAC = new Phrase("sensitive ", null, 0, null, null);

            //AB FOLLOW ONS (Hey how did...)
            Phrase ABA = new Phrase("your dog die?", null, -10, new List<int> { (int)personality.CHAV }, null);
            Phrase ABB = new Phrase("you get here?", null, 0, null, null);
            Phrase ABC = new Phrase("you know we'd be perfect?", null, 0, null, null);

            //AC FOLLOW ONS (Hey I want...)
            Phrase ACA = new Phrase("you.", null, 0, null, null);
            Phrase ACB = new Phrase("to go.", null, -10, null, null);
            Phrase ACC = new Phrase("my meemaw.", null, -10, null, null);


            //A FOLLOW ONS
            Phrase AA = new Phrase("you are ", new List<Phrase> { AAA, AAB, AAC }, 0, null, null);
            Phrase AB = new Phrase("how did ", new List<Phrase> { ABA, ABB, ABC }, 0, null, null);
            Phrase AC = new Phrase("I want ", new List<Phrase> { ACA, ACB, ACC }, 0, null, null);


            //Now we have follow on phrases for A, we can make the first phrase: A. Make the other openers too
            Phrase A = new Phrase("Hey ", new List<Phrase> { AA, AB, AC }, 0, null, null);
            Phrase B = new Phrase("Yo ", null, -2, new List<int> { (int)personality.CHAV }, null);
            Phrase C = new Phrase("Howdy ", null, -2, new List<int> { (int)personality.COWBOY }, new List<int> { (int)personality.CHAV });

            //Put each of the speeches into a list. This will be used in the game.
            phraseList.Add(A);
            phraseList.Add(B);
            phraseList.Add(C);
        }


        //Puts three strings into a list of phrases that have no follow on phrases
        //make this generic: for args.length
        public static List<Phrase> makeLastPhraseList(string A, int ratingA, List<int> impressesA, List<int> offendsA,
                                                    string B, int ratingB, List<int> impressesB, List<int> offendsB,
                                                    string C, int ratingC, List<int> impressesC, List<int> offendsC)
        {
            //Make the phrases that follow on
            Phrase pA = new Phrase(A, null, ratingA, impressesA, offendsA);
            Phrase pB = new Phrase(B, null, ratingB, impressesB, offendsB);
            Phrase pC = new Phrase(C, null, ratingC, impressesC, offendsC);

            //Put the follow on phrases in a list to return
            //Which one of the below work? Second two don't need the above
            return new List<Phrase>(new Phrase[] { pA, pB, pC });
            //return new List<Phrase>(new Phrase[]{new Phrase(A, null),new Phrase(B, null),new Phrase(C, null)});
            //return new List<Phrase>{new Phrase(A, null),new Phrase(B, null),new Phrase(C, null)};

        }


        //Fill in the dates for this world
        private static void populateDates()
        {
            //Cats
            Dateable cat = new Dateable("cat", new List<int> { (int)personality.CAT });
            Dateable shyCat = new Dateable("shy cat", new List<int> { (int)personality.CAT, (int)personality.SHY });

            //Chav
            Dateable chav = new Dateable("chav", new List<int> { (int)personality.CHAV });
            Dateable confidentChav = new Dateable("confident chav", new List<int> { (int)personality.CHAV, (int)personality.CONFIDENT });

            //Jock
            Dateable jock = new Dateable("jock", new List<int> { (int)personality.JOCK });

            //Emo
            Dateable emo = new Dateable("emo", new List<int> { (int)personality.EMO });

            //Poet
            Dateable poet = new Dateable("poet", new List<int> { (int)personality.POET });

            dates.Add(cat);
            dates.Add(shyCat);
            dates.Add(chav);
            dates.Add(confidentChav);
            dates.Add(jock);
            dates.Add(emo);
            dates.Add(poet);
        }

        public static void amendScore(Phrase p, Dateable yourDate) {

            Console.WriteLine("\nYour score was " + score);

            //Check if your dates specifically hates or likes this line 
            if (yourDate.attributes != null &&
                p.impresses != null &&
                p.impresses.Contains(yourDate.attributes[0]))
            {
                Console.WriteLine(yourDate.name + " liked that");
                score += 10;
            }
            else if (yourDate.attributes != null &&
                p.offends != null &&
                p.offends.Contains(yourDate.attributes[0]))
            {
                Console.WriteLine(yourDate.name + " didn't like that");
                score -= 10;
            }
            //Before setting the general score
            else
            {
                score += p.generalRating;
            }

            Console.WriteLine("Your score is now " + score);
        }
    }
}
