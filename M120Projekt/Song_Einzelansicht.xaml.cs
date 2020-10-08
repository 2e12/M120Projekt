using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Song_Einzelansicht.xaml
    /// </summary>
    public partial class Song_Einzelansicht : UserControl
    {
        public Song_Einzelansicht()
        {
            InitializeComponent();
        }

        public bool IsValid() {
            bool isValid = true;
            if (1 > this.TitleBox.Text.Length | this.TitleBox.Text.Length > 128) {
                isValid = false;
            }

            if (1 > this.ArtistBox.Text.Length | this.ArtistBox.Text.Length > 128)
            {
                isValid = false;
            }

            if (this.LengthBox.Text != "" & !Regex.IsMatch(this.LengthBox.Text, "[0-9]{1,2}:[0-5][0-9]"))
            {
                isValid = false;
            }

            if (this.YouTubeIdBox.Text != "" & this.YouTubeIdBox.Text.Length != 10) 
            {
                isValid = false;
            }

            if (isValid) {
                Console.WriteLine("VALID");
            }

            return isValid;
        }

        private void TitleBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
