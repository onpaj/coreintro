using System.ComponentModel.DataAnnotations;

namespace API
{
    public class InputDto
    {
        [Required]
        public string Value1 { get; set; }
        [Required]
        public int Value2 { get; set; }
    }
}