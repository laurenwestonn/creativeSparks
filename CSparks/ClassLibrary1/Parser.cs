using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public static class Parser
    {
    	struct Line {
    		public int ID;
    		public int nextID;
    		public string phrase;
    		public int rating;
    		public List<string> attracts;
    		public List<string> offends;
    		
    		public Line(int I, int nI, string p, int r, List<string> a, List<string> o)
    		{
    			ID = I;
    			nextID = nI;
    			phrase = p;
    			rating = r;
    			attracts = a;
    			offends = o;
    		}
    	}
    	
    	void Start()
    	{
    		string file = "phrases.txt";
    		
    		lines = new List<Line>();
    		LoadDialogue(file); 
    	}
    
    	public LoadDialogue(string filename)
    	{
    		string path = "Assets/Resources/" + filename;
    		string lineOfText;
    		StreamReader r = new StreamReader(filename);
    		
    		using(r)
    		{
    			do {
    				line = r.ReadLine();
    				if(line != null) {
    					
    				}
    				
    			}
    		}
    		
    	}
 		}   
}
