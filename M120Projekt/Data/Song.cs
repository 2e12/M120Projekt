using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class Song
    {
        #region Datenbankschicht
        [Key]
        public Int64 SongID { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Artist { get; set; }
        [Required]
        public String Gerne { get; set; }
        [Required]
        public DateTime Erschienen { get; set; }
        [Required]
        public Boolean Favorit { get; set; }
        [Required]
        public float Laenge { get; set; }
        [Required]
        public String YouTubeID { get; set; }
        #endregion
        #region Applikationsschicht
        public Song() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static List<Song> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.Song select record).ToList();
            }
        }
        public static Song LesenID(Int64 klasseAId)
        {
            using (var db = new Context())
            {
                return (from record in db.Song where record.SongID == klasseAId select record).FirstOrDefault();
            }
        }
        public static List<Song> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Song where record.Title == suchbegriff select record).ToList();
            }
        }
        public static List<Song> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Song where record.Title.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Title == null || this.Title == "") this.Title = "leer";
            if (this.Erschienen == null) this.Erschienen = DateTime.MinValue;
            using (var db = new Context())
            {
                db.Song.Add(this);
                
                
                db.SaveChanges();
                return this.SongID;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.SongID;
            }
        }
        public void Loeschen()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return SongID.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
