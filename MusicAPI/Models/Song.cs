using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    public class Song
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public string Duration { get; set; }
        public DateTime? UploadedDate { get; set; }
        [Required]
        public bool IsFeatured { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        [NotMapped]
        public IFormFile AudioFile { get; set; }
        public string? AudioUrl { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
    }
}
