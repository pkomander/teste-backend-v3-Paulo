using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiko.Dto
{
    public class InvoiceDto
    {
        public int? InvoiceId { get; set; }
        [Required]
        public string Custumer { get; set; }
        public List<PerformanceDto> Performances { get; set; }
    }
}
