using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SISControlAPI.Domain.Entities;
using SISControlAPI.Infra.EntityConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SISControlAPI.Infra.Contexto
{
    public class DataContexto : DbContext
    {
        public DataContexto() : base("DefaultConnection")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
