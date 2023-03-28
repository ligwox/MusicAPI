using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    [NotMapped]
    public class ArtistResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
