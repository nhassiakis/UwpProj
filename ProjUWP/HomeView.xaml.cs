using ProjUWP.Models;
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
            ToggleButton[] toggleButtons = new ToggleButton[] { Any, Custom, Prog, Misc, Dark };
            foreach (ToggleButton button in toggleButtons)
            {
                if (Any.IsChecked == true)
                {
                    Custom.IsEnabled = false;
                    Prog.IsEnabled = false;
                    Misc.IsEnabled = false;
                    Dark.IsEnabled = false;


                    //jokeApi.Category = "any";
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
                    selectedToppingsText += button.Content;
                }
            }
            if (selectedToppingsText == "Custom")
            {
                selectedToppingsText = "any";
            }
            if (Any.IsChecked == true)
            {
                toppingsList.Text = "any";
            }
            else
            toppingsList.Text = selectedToppingsText;

            //jokeApi.Category = cateogrie;
        }

        private void Any_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
