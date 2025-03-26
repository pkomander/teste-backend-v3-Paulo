using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aiko.Dto
{
    public class ExtratoRequest
    {
        public int? InvoiceId { get; set; }
        public string? Custumer { get; set; }
        public int FormatoArquivo { get; set; }
    }
}
