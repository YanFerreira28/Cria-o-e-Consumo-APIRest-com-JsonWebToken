using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISControlWeb.ViewModel
{
    public class ProdutoViewModel
    {
        [Required]
        [MaxLength(50)]
        public string nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string fornecedor { get; set; }

        [Required]
        [MaxLength(50)]
        public string marca { get; set; }

        [Required]
        public decimal valor { get; set; }
    }
}
