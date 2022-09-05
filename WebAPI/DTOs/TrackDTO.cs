using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTOs
{
    public class TrackDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Rating { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
