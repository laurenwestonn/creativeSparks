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
            yourDate = yourDate.getADate();
            Console.WriteLine("Woohoo got a date with " + yourDate.name);

            //Say something to impress them
            string speech = Speech.createSpeech();

            //What you said
            Console.Write("\n\n\nThis is the best you could come up with\n\n" + speech);

            Console.WriteLine("\n\nPress any button to close");
            Console.ReadKey();
        }

    }

}
