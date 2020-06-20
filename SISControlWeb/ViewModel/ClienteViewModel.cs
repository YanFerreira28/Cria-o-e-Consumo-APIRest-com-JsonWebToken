using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SISControlWeb.ViewModel
{
    public class ClienteViewModel
    {

        [Required]
        [MaxLength(50)]
        public string nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string sobrenome { get; set; }

        [Required]
        [MaxLength(50)]
        public string rua { get; set; }

        [Required]
        [MaxLength(50)]
        public string bairro { get; set; }

        [Required]
        [MaxLength(50)]
        public string cidade { get; set; }

        [Required]
        [MaxLength(50)]
        public string estado { get; set; }

        [Required]
        [MaxLength(6)]
        public string numero { get; set; }

        [Required]
        public int produtoId { get; set; }
    }
}
