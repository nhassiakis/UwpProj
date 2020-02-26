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
        public string ApiKey { get; set; }

        public string Category { get; set; }
        public string Type { get; set; }
        public string Joke { get; set; }
        public Flags Flags { get; set; }

        //public void GetApiKey()
        //{
        //    string filePath = @"C:\Users\Nico\Documents\GitHub\UwpProj\GoogleApiKey.txt";
        //    var reader = new StreamReader(path: filePath);
        //    ApiKey = reader.ReadToEnd();
        //}

        public void FlagsAttributes(bool flagN, bool flagRe, bool flagP, bool flagR, bool flagS)
        {
            Flags flags = new Flags
            {
                Nsfw = flagN,
                Religious = flagRe,
                Political = flagP,
                Racist = flagR,
                Sexist = flagS,
            };
    }
}

}
