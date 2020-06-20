using SISControlAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace SISControlAPI.Infra.EntityConfiguration
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            HasKey(model => model.id);

            Property(model => model.nome).HasMaxLength(50).IsRequired().HasColumnName("Nome");

            Property(model => model.senha).HasMaxLength(50).IsRequired().HasColumnName("Senha");

            Property(model => model.email).IsRequired().HasColumnName("Email");
        }
    }
}
