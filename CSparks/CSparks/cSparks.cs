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
        public static Dateable yourDate {get; set;}

        static void Main(string[] args)
        {
            //Get a date! :D
            yourDate = new Dateable("", null);
            yourDate = yourDate.pickARandomDate();

            Console.WriteLine("Woohoo got a date with " + yourDate.name);

            //Say something to impress them
            string speech = Speech.createWholeSpeech(yourDate);

            //What you said
            if (World.score > 10)
                Console.Write("\n\n\nWow you'll get another date with this line\n\n" + speech);
            else if (World.score > 5)
                Console.Write("\n\n\nNice! This is what you said\n\n" + speech);
            else if (World.score > 0)
                Console.Write("\n\n\nHere's what you said\n\n" + speech);
            else
                Console.Write("\n\n\nThis is the best you could come up with\n\n" + speech);

            Console.Write("You scored " + World.score);

            Console.WriteLine("\n\nPress any button to close");
            Console.ReadKey();
        }

    }

}
