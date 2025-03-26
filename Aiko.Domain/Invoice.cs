using System.ComponentModel.DataAnnotations;

namespace Aiko.Domain
{
    public class Invoice
    {
        [Key]
        [Required]
        public int InvoiceId { get; set; }
        public string Custumer { get; set; }

        public ICollection<Performance> Performances { get; set; }
    }
}
