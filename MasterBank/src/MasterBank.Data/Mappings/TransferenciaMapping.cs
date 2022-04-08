using MasterBank.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MasterBank.Data.Mappings
{
    public class TransferenciaMapping : IEntityTypeConfiguration<Transferencia>
    {
        public void Configure(EntityTypeBuilder<Transferencia> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ChavePixOrigem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(x => x.Valor)
                .IsRequired();

            builder.Property(x => x.ChavePixDestino)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.ToTable("Transferencia");
        }
    }
}
