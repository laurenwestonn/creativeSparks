using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class World
    {
        public static readonly List<Phrase> phraseList = new List<Phrase>();
        public static readonly List<Phrase> phraseListA = new List<Phrase>();

        static World()
        {
            populatePhrases();
        }

        private static void populatePhrases()
        {
            phraseList.Add(new Phrase("Hey ", null));
            phraseListA.Add(new Phrase("Hey ", phraseList));
        }
    }
}
