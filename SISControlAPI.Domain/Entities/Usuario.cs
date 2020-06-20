using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SISControlAPI.Domain.Entities
{
    public class Usuario
    {
        public int id { get; set; }

        public string nome { get; set; }

        [EmailAddress]
        public string email { get; set; }

        public string senha { get; set; }
    }
}
