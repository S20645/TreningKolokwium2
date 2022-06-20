using System;
using System.Collections.Generic;

namespace test2.Models.DTOs
{
    public class Albums
    {
        public int IdAlbum { get; set; }
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public string MusicLabelName { get; set; }
        public List<Tracks> Tracks { get; set; }
        
    }

    public class Tracks
    {
        public string TrackName { get; set; }
        public float Duration { get; set; }

    }
}
