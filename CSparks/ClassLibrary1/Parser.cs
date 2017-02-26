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
  	
  	void OnUpdate()
  	{
  	
  	}
  
  	public LoadDialogue(string filename)
  	{
  		string path = "Assets/Resources/" + filename;
  		string lineOfText;
  		string[] arrLine;
  		Line line;
  		StreamReader r = new StreamReader(filename);
  		
  		using(r) {
  			do {
  				lineOfText = r.ReadLine();
  				
  				if(lineOfText != null) {
  					arrLine = lineOfText.Split(',');
  					
						List<string> attracts;
						List<string> offends;
						
  					//populate the attracts list
  					foreach(string a in arrLine[4].Split('.')) {
  						attracts.Add(a);
  					}
  					
						//populate the offends list
  					foreach(string o in arrLine[5].Split('.')) {
  						offends.Add(o);
  					}
  					line = new line(Int32.Parse(arrLine[0]),	//ID
  													Int32.Parse(arrLine[1]),	//Next ID
  													arrLine[2],								//Phrase
  													Int32.Parse(arrLine[3]),	//Rating
  													attracts,									//Attracts
  													offends										//Offends
  													)
  					lines.Add(line);
  				}
  				
  			}
  			while(line != null);
  			r.Close();
  		}
  	}
	}
}
