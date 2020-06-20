using SISControlAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace SISControlAPI.Infra.EntityConfiguration
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(model => model.id);

            Property(model => model.nome).IsRequired().HasMaxLength(50).HasColumnName("Nome");

            Property(model => model.fornecedor).IsRequired().HasMaxLength(60).HasColumnName("Fornecedor");

            Property(model => model.marca).IsRequired().HasMaxLength(40).HasColumnName("Marca");

            Property(model => model.valor).IsRequired().HasColumnName("Valor");

        }
    }
}
