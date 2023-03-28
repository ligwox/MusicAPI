using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicAPI.Models
{
    [NotMapped]
    public class SongResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public string ImageUrl { get; set; }
        public string AudioUrl { get; set; }
    }
}
