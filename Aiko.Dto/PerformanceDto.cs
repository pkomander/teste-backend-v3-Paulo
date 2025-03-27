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
        public int? PlayId { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [Swashbuckle.AspNetCore.Annotations.SwaggerSchema(ReadOnly = true)]
        public PlayDto? Play { get; set; }
        [Required]
        public int Audience { get; set; }
        public int InvoiceId { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        [System.Text.Json.Serialization.JsonIgnore]
        [Swashbuckle.AspNetCore.Annotations.SwaggerSchema(ReadOnly = true)]
        public InvoiceDto? Invoice { get; set; }
    }
}
