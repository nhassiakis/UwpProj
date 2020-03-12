using ProjUWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Web;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public class Category
    {
        public bool AnyVal { get; set; }
        public bool CustomVal { get; set; }
        public bool ProgrammingVal { get; set; }
        public bool MiscVal { get; set; }
        public bool DarkVal { get; set; }

    }

    public sealed partial class HomeView : Page
    {
        API jokeApi = new API();
        public HomeView()
        {
            this.InitializeComponent();
        }




        private void Toggle_Any(object sender, RoutedEventArgs e)
        {
            string selectedToppingsText = string.Empty;
            jokeApi.Category = "any";
            ToggleButton[] toggleButtons = new ToggleButton[] { Any, Custom, Prog, Misc, Dark };
            foreach (ToggleButton button in toggleButtons)
            {

                if (Any.IsChecked == true)
                {
                    Custom.IsEnabled = false;
                    Prog.IsEnabled = false;
                    Misc.IsEnabled = false;
                    Dark.IsEnabled = false;
                }
                else if (Any.IsChecked != true)
                {
                    Custom.IsChecked = true;

                    Custom.IsEnabled = true;
                    Prog.IsEnabled = true;
                    Misc.IsEnabled = true;
                    Dark.IsEnabled = true;

                }
                if (button.IsChecked == true)
                {
                    if (selectedToppingsText.Length > 1)
                    {
                        selectedToppingsText += ",";
                    }
                    if (Custom != button)
                    {
                        selectedToppingsText += button.Content;

                    }
                }
            }
            if (selectedToppingsText == string.Empty)
            {
                selectedToppingsText = "any";
                jokeApi.Category = selectedToppingsText;
            }
            if (Any.IsChecked == true)
            {
                selectedToppingsText = "any";
                jokeApi.Category = selectedToppingsText;
            }
            else
            {
                jokeApi.Category = selectedToppingsText;
            }
        }


        private void blackListClick(object sender, RoutedEventArgs e)
        {
            string selectedToppingsText = string.Empty;
            jokeApi.Flags = string.Empty;
            CheckBox[] toggleCheckBox = new CheckBox[] { nsfw, religious, political, sexist, racist };
            foreach (CheckBox checkBox in toggleCheckBox)
            {
                if (checkBox.IsChecked == true)
                {
                    if (selectedToppingsText.Length > 1)
                    {
                        selectedToppingsText += ",";
                    }
                    selectedToppingsText += checkBox.Content;
                }
            }
            jokeApi.Flags = selectedToppingsText;
        }

        private void typeClick(object sender, RoutedEventArgs e)
        {
            string selectedToppingsText = string.Empty;
            jokeApi.Type = string.Empty;
            CheckBox[] toggleCheckBox = new CheckBox[] { single, twopart };
            foreach (CheckBox checkBox in toggleCheckBox)
            {
                if (checkBox.IsChecked == true)
                {
                    if (selectedToppingsText.Length < 1)
                    {
                        selectedToppingsText += checkBox.Content;
                    }
                    else
                        selectedToppingsText = string.Empty;
                }
            }
            jokeApi.Type = selectedToppingsText;
        }

        private void searchJoke(object sender, RoutedEventArgs e)
        {


            string baseURL = "https://sv443.net/jokeapi/v2/joke/";

            string sendJokeURL = JokeURL(baseURL);

            httpRequest(sendJokeURL);

        }

        private string JokeURL(string baseUrl)
        {
            string category = jokeApi.Category;
            string blacklist = jokeApi.Flags;
            string type = jokeApi.Type;
            jokeApi.Search = string.Empty;
            string search = searchInput.Text;

            if (blacklist.Length > 0)
            {
                blacklist = "?blacklistFlags=" + jokeApi.Flags;
            }
            if (type.Length > 0)
            {
                if (blacklist.Length > 0)
                {
                    type = "&type=" + jokeApi.Type;
                }
                else
                {
                    type = "?type=" + jokeApi.Type;
                }
            }
            if (search.Length > 0)
            {
                jokeApi.Search = search;
                if (blacklist.Length > 0 || type.Length > 0)
                {
                    search = "&contains=" + jokeApi.Search;
                }
                else
                {
                    search = "?contains=" + jokeApi.Search;
                }
            }

            return baseUrl + category + blacklist + type + search;
        }
        public void httpRequest(string URL)
        {
            WebRequest request = WebRequest.Create(URL);
            WebResponse response = request.GetResponse();
            Joke joke = new Joke();
                // Convert the stream to a string
            using (Stream dataStream = response.GetResponseStream())
            using (StreamReader sr = new StreamReader(dataStream))
            using (JsonReader reader = new JsonTextReader(sr))
            {

                // Deserialize the string into an object of the Joke class
                JsonSerializer ser = new JsonSerializer();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {

                       joke = ser.Deserialize<Joke>(reader);
                        
                    }
                }

                if (joke.type == "single")
                {
                    // If type == "single", the joke only has the "joke" property
                    output.Text = joke.joke;
                }
                else
                {
                    // If type == "twopart", the joke has the "setup" and "delivery" properties
                    output.Text = joke.setup;
                 
                    output.Text +=  "\n" + joke.delivery;
                }
            }

            // Close the request
            response.Close();
        }
    }
}
