using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SISControlWeb.ViewModel
{
    public class UsuarioViewModel
    {

        [MaxLength(50)]
        [Required]
        public string nome { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [MaxLength(50)]
        [Required]
        public string senha { get; set; }

    }
}
