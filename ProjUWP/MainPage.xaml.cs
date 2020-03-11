using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using ProjUWP.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(HomeView));
            Flags flags = new Flags();
            API api = new API
            {
                Category = "any",
                Type = "twopart",
                Joke = "Two Flags walked into a bar to order two drinks \n Cyke flags can't walk.",
                Flags = string.Empty,
                Search = string.Empty,
                //Flags = new Flags { Nsfw = false, Sexist = false, Political = false, Racist = false, Religious = false}  
            };
            

        }

        private void MenuSelected(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {

            var item = NavView.SelectedItem as NavigationViewItem;
            switch (item.Tag)
            {
                case "home":
                    ContentFrame.Navigate(typeof(HomeView));
                    NavView.Header = "Welcome";
                    break;
                case "api1":
                    ContentFrame.Navigate(typeof(HomeView));
                    NavView.Header = "Youtube";
                    break;
                case "api2":
                    ContentFrame.Navigate(typeof(HomeView));
                    NavView.Header = "API";
                    break;
            }
        }
    }
}
