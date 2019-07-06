using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyFirstSamples
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(e.OldTextValue != e.NewTextValue)
                textLabel.Text = e.NewTextValue;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(textLabel.TextColor == Color.Black)
            {
                textLabel.TextColor = Color.Green;
            } else
            {
                textLabel.TextColor = Color.Black;
            }
        }

    }
}
