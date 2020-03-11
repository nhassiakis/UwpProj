using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjUWP.Models
{
    public class API
    {
        public API()
        {
            Category = "any";
            Type = string.Empty;
            Search = string.Empty;
            Joke = string.Empty;
            Flags = string.Empty;
        }
        
        public string Category { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Search { get; set; }
        public string Joke { get; set; }
        public string Flags { get; set; }

        //public void GetApiKey()
        //{
        //    string filePath = @"C:\Users\Nico\Documents\GitHub\UwpProj\GoogleApiKey.txt";
        //    var reader = new StreamReader(path: filePath);
        //    ApiKey = reader.ReadToEnd();
        //}

    }
}
