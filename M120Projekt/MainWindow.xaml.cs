using System.Windows;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        State state = State.Empty;
        public MainWindow()
        {
            InitializeComponent();
            // Aufruf diverse APIDemo Methoden
            APIDemo.DemoACreate();
            APIDemo.DemoACreateKurz();
            APIDemo.DemoARead();
            APIDemo.DemoAUpdate();
            APIDemo.DemoARead();
            APIDemo.DemoADelete();

            this.ChangeState(State.Empty);
        }

        private void ChangeState(State newstate) {
            this.state = newstate;
            this.SetDefaultState();
            if (this.state == State.Empty || this.state == State.Sclected) {
                this.Title = "Musik Bibliothek";
            }
            if (this.state == State.Empty) {
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
                EntryEditor.ResetValues();
                EntryEditor.Visibility = Visibility.Visible;
                SaveButton.IsEnabled = true;
                this.Title = "Neuer Song erstellen";
            }
            if (this.state == State.Edit)
            {
                BackButton.IsEnabled = true;
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
                if (MessageBox.Show( "Wollen Sie die ungespeicherte Änderungen verwerfen?", "Ungespeicherte Änderungen", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
            }
            ChangeState(State.Empty);
        }

        private void EditEntry(object sender, RoutedEventArgs e)
        {
            ChangeState(State.Edit);
        }

        private void DeleteEntry(object sender, RoutedEventArgs e)
        {
            ChangeState(State.Empty);
        }

        private void SaveEntry(object sender, RoutedEventArgs e)
        {
            if (EntryEditor.IsValid())
            {
                ChangeState(State.Empty);
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
