using System;
using System.Collections.Generic;
using System.Text;

namespace SISControlAPI.Domain.ValueObjects
{
    public class Endereco
    {
        public string rua { get; set; }

        public string bairro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public string numero { get; set; }
    }
}
