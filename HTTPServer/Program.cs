using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HTTPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Call CreateRedirectionRulesFile() function to create the rules of redirection 
            CreateRedirectionRulesFile();
            //Start server
            // 1) Make server object on port 1000
            // 2) Start Server
            string path =  "G:\\Http Protocol\\HTTP-Protocol\\HTTPServer\\redirectionRules.txt";
            Server s = new Server(1000, "G:\\Http Protocol\\HTTP-Protocol\\HTTPServer\\redirectionRules.txt");
            s.StartServer();

            //CreateRedirectionRulesFile();
        }

        static void CreateRedirectionRulesFile()
        {
          
            FileStream fw = new FileStream("redirectionRules.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fw);
            sw.WriteLine("aboutus2.html,aboutus2.html");
            sw.WriteLine("aboutus.html,aboutus2.html");
            sw.WriteLine("main.html,main.html");
            sw.WriteLine("notfound.html,NotFound.html");
            sw.WriteLine("superkora.html,Redirect.html");
            sw.Close();
            
            // TODO: Create file named redirectionRules.txt
            // each line in the file specify a redirection rule
            // example: "aboutus.html,aboutus2.html"
            // means that when making request to aboustus.html,, it redirects me to aboutus2
        }
        // ya habla xDD
    }
}
