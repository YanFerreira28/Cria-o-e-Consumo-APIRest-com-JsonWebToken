using SISControlAPI.Domain.Entities;
using SISControlAPI.Domain.ValueObjects;
using System.Data.Entity.ModelConfiguration;

namespace SISControlAPI.Infra.EntityConfiguration
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(model => model.id);

            Property(model => model.nome).IsRequired().HasMaxLength(50).HasColumnName("Nome");

            Property(model => model.sobrenome).IsRequired().HasMaxLength(50).HasColumnName("Sobrenome");

            HasOptional(model => model.produto).WithMany();
        }
    }
}
