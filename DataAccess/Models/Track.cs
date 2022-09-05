using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Track
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public float? Rating { get; set; }
        public TimeSpan Duration { get; set; }
    }
}
