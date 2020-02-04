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


        public void GetApiKey()
        {
            string filePath = @"C:\Users\Nico\Documents\GitHub\UwpProj\GoogleApiKey.txt";
            var reader = new StreamReader(path: filePath);
            ApiKey = reader.ReadToEnd();
        }
    }

}
