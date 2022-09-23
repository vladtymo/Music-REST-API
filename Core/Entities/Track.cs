using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Track
    {
        public int Id { get; set; }
        [Required, MaxLength(100)]
        //[RegularExpression(@"$[A-Z]\w*^")] we use FluentValidation instead
        public string Name { get; set; }
        public float? Rating { get; set; }
        public TimeSpan Duration { get; set; }
        public string? ImagePath { get; set; }
    }
}
