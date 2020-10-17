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
        bool _unsaved = false;

        public bool unsaved
        {
            get { return _unsaved; }
        }

        public Song_Einzelansicht()
        {
            InitializeComponent();
            HideErrors();
        }

        private void HideErrors() {
            TitelError.Visibility = Visibility.Collapsed;
            ArtistError.Visibility = Visibility.Collapsed;
            LengthError.Visibility = Visibility.Collapsed;
            YouTubeIdError.Visibility = Visibility.Collapsed;
        }

        public bool IsValid() {
            bool isValid = true;
            HideErrors();
            if (1 > this.TitleBox.Text.Length | this.TitleBox.Text.Length > 128) {
                isValid = false;
                TitelError.Visibility = Visibility.Visible;
            }

            if (1 > this.ArtistBox.Text.Length | this.ArtistBox.Text.Length > 128)
            {
                isValid = false;
                ArtistError.Visibility = Visibility.Visible;
            }

            if (this.LengthBox.Text != "" & !Regex.IsMatch(this.LengthBox.Text, "[0-9]{1,2}:[0-5][0-9]"))
            {
                isValid = false;
                LengthError.Visibility = Visibility.Visible;
            }

            if (this.YouTubeIdBox.Text != "" & this.YouTubeIdBox.Text.Length != 10) 
            {
                isValid = false;
                YouTubeIdError.Visibility = Visibility.Visible;
            }

            return isValid;
        }

        public void ResetValues() {
            HideErrors();
            TitleBox.Text = "";
            ArtistBox.Text = "";
            ReleasedBox.SelectedDate = null;
            GerneBox.SelectedIndex = 4;
            LengthBox.Text = "3:10";
            FavoritBox.IsChecked = false;
            YouTubeIdBox.Text = "";
            _unsaved = false;
        }

        private void DataChanged() {
            _unsaved = true;
        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            DataChanged();
        }

        private void ReleasedBox_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DataChanged();
        }

        private void GerneBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataChanged();
        }

        private void TextChanged(object sender, RoutedEventArgs e)
        {
            DataChanged();
        }
    }
}
