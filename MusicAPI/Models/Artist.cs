using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        // navigation props
        public ICollection<Album>? Albums { get; set; }
        public ICollection<Song>? Songs { get; set; }
    }
}
