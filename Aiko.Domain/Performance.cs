using System.ComponentModel.DataAnnotations;

namespace Aiko.Domain
{
    public class Performance
    {
        [Key]
        [Required]
        public int PerformanceId { get; set; }
        public int PlayId { get; set; }
        public Play Play { get; set; }
        public int Audience { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
    }
}
