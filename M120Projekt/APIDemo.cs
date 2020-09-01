using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA
            Data.Song klasseA1 = new Data.Song();
            klasseA1.Title = "Artikel 1";
            klasseA1.Erschienen = DateTime.Today;
            klasseA1.Artist = "Artist";
            klasseA1.Favorit = true;
            klasseA1.Gerne = "Pop";
            klasseA1.Laenge = 1.5f;
            klasseA1.YouTubeID = "123";

            Int64 klasseA1Id = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        public static void DemoACreateKurz()
        {
            Data.Song klasseA2 = new Data.Song { Title = "Artikel 2", Favorit = true, Erschienen = DateTime.Today, Artist = "Artist", Gerne = "Pop", Laenge = 1.6f, YouTubeID = "345"};
            Int64 klasseA2Id = klasseA2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Song klasseA in Data.Song.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.SongID + " Name:" + klasseA.Title);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.Song klasseA1 = Data.Song.LesenID(1);
            klasseA1.Title = "Artikel 1 nach Update";
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            // Data.Song.LesenID(2).Loeschen();
            Debug.Print("Artikel mit Id 2 gelöscht");
        }
        #endregion
    }
}
