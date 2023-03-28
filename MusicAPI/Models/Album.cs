using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }
        public int ArtistId { get; set; }

        // navigation props
        public ICollection<Song>? Songs { get; set; }
    }
}
