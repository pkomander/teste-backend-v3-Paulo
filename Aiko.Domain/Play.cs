using System.ComponentModel.DataAnnotations;

namespace Aiko.Domain
{
    public class Play
    {
        [Key]
        [Required]
        public int PlayId { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Lines { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
