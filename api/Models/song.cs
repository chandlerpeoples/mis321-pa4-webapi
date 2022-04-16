using System;

namespace api.Models
{
    public class Song
    {
        public int SongID {get; set;}
        public string? SongTitle {get; set;}
        public DateTime SongTimestamp {get; set;}
        public string? Deleted {get; set;}
        public bool Favorited {get; set;}
    }
}