using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Album
    {
        public int Id { get; set; }
        [Required, StringLength(100, MinimumLength = 2)]
        [RegularExpression(@"$[A-Z]\w*^")]
        public string Name { get; set; }
        [Range(1,10)]
        public float Rating { get; set; }
        public int Year { get; set; }
    }
}
