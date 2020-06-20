using SISControlAPI.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace SISControlAPI.Infra.EntityConfiguration
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            Property(model => model.bairro).HasMaxLength(50).IsRequired().HasColumnName("Bairro");

            Property(model => model.cidade).HasMaxLength(50).IsRequired().HasColumnName("Cidade");

            Property(model => model.estado).HasMaxLength(20).IsRequired().HasColumnName("Estado");

            Property(model => model.rua).HasMaxLength(50).IsRequired().HasColumnName("Rua");

            Property(model => model.numero).HasMaxLength(6).IsRequired().HasColumnName("Numero");
        }
    }
}
