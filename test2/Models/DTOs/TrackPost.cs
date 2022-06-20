using System.ComponentModel.DataAnnotations;

namespace test2.Models.DTOs
{
    public class TrackPost
    {
        [Required]
        public int IdTrack { get; set; }
        [Required]
        [StringLength(20)]
        public string TrackName { get; set; }
        [Required]
        public float Duration { get; set; }
        public int IdMusicAlbum { get; set; }
    }
}
