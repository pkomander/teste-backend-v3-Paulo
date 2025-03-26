using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiko.Dto
{
    public class PerformanceDto
    {
        public int? PerformanceId { get; set; }
        public PlayDto Play { get; set; }
        [Required]
        public int Audience { get; set; }
    }
}
