using System;
using System.Collections.Generic;
using System.Windows;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        State state = State.Empty;
        Data.Song song = null;
        public MainWindow()
        {
            InitializeComponent();
            LoadSongs();
            this.ChangeState(State.Empty);
        }

        private void ChangeState(State newstate) {
            this.state = newstate;
            this.SetDefaultState();
            if (this.state == State.Empty || this.state == State.Sclected) {
                this.Title = "Musik Bibliothek";
            }
            if (this.state == State.Empty) {
                this.song = null;
                Entries.UnselectAll();
                NewButton.IsEnabled = true;
                Entries.Visibility = Visibility.Visible;
            }
            if (this.state == State.Sclected)
            {
                NewButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                DeleteButton.IsEnabled = true;
                Entries.Visibility = Visibility.Visible;
                if (Entries.SelectedItems.Count < 1) {
                    this.ChangeState(State.Empty);
                }
            }
            if (this.state == State.New)
            {
                BackButton.IsEnabled = true;
                EntryEditor.ResetForm();
                EntryEditor.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = true;
                this.Title = "Neuer Song erstellen";
            }
            if (this.state == State.Edit)
            {
                BackButton.IsEnabled = true;
                EntryEditor.loadSong(this.song);
                EntryEditor.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = true;
                this.Title = "Song bearbeiten";
            }
        }

        private void SetDefaultState() {
            EntryEditor.Visibility = Visibility.Collapsed;
            Entries.Visibility = Visibility.Collapsed;
            NewButton.IsEnabled = false;
            EditButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
            BackButton.IsEnabled = false;
            SaveButton.IsEnabled = false;
        }

        private void NewEntry(object sender, RoutedEventArgs e)
        {
            ChangeState(State.New);
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            if (EntryEditor.unsaved) {
                if (MessageBox.Show("Wollen Sie die ungespeicherte Änderungen verwerfen?", "Ungespeicherte Änderungen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
            }
            ChangeState(State.Empty);
        }

        private void EditEntry(object sender, RoutedEventArgs e)
        {
            Data.Song item = (Data.Song)Entries.SelectedItem;
            this.song = item;
            ChangeState(State.Edit);
        }

        private void DeleteEntry(object sender, RoutedEventArgs e)
        {
            Data.Song item = (Data.Song) Entries.SelectedItem;
            item.Loeschen();
            ChangeState(State.Empty);
            LoadSongs();
        }

        private void SaveEntry(object sender, RoutedEventArgs e)
        {
            if (EntryEditor.IsValid())
            {
                bool create = this.song == null;
                if (create) {
                    this.song = new Data.Song();
                }
                this.song.Title = EntryEditor.TitleBox.Text;
                this.song.Erschienen = EntryEditor.ReleasedBox.DisplayDate;
                this.song.Artist = EntryEditor.ArtistBox.Text;
                this.song.Favorit = true;
                this.song.Gerne = EntryEditor.GerneBox.Text;
                this.song.Laenge = EntryEditor.LengthBox.Text;
                this.song.YouTubeID = EntryEditor.YouTubeIdBox.Text;
                if (create)
                {
                    this.song.Erstellen();
                }
                else {
                    this.song.Aktualisieren();
                }
                ChangeState(State.Empty);
                LoadSongs();
            }
        }

        private void LoadSongs() {
            Entries.Items.Clear();
            List<Data.Song> songs = Data.Song.LesenAlle();
            foreach (Data.Song song in songs)
            {
                if (!Entries.Items.Contains(song))
                {
                    Entries.Items.Add(song);
                }
            }
        }

        private void Entries_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ChangeState(State.Sclected);
        }
    }
    enum State
    {
        Empty,
        Sclected,
        Edit,
        New
    }
}
