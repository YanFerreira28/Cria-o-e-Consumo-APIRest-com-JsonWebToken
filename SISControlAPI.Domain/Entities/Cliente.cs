using SISControlAPI.Domain.ValueObjects;
using System.Collections.Generic;

namespace SISControlAPI.Domain.Entities
{
    public class Cliente
    {
        public int id { get; set; }

        public string nome { get; set; }

        public string sobrenome { get; set; }

        public Endereco endereco { get; set; }

        public virtual ICollection<Produto> produto { get; set; }

    }
}
