using MasterBank.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterBank.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Documento)
              .IsRequired()
              .HasColumnType("varchar(14)");

            builder.Property(x => x.ChavePix)
              .IsRequired()
              .HasColumnType("varchar(200)");

            builder.ToTable("Cliente");
        }
    }
}
