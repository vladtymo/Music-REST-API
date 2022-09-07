using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    // Data Transfer Object (DTO)
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Rating { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
