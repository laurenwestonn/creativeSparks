using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Dateable
    {
        public List<int> attributes { get; set; }
        public String name { get; set; }

        public Dateable(String setName, List<int> setAttributes)
        {
            attributes = setAttributes;
            name = setName;
        }

        //Pick a random number to choose a random date
        public Dateable getADate()
        {
            Console.WriteLine("Counting from " + (int)(World.dates.Count() - 1) ); //no length to dates
            return World.dates[new Random().Next(0, World.dates.Count()-1)];
        }
    }
}
