using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeuEvento.Domain.Eventos;

namespace SeuEvento.Infra.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder
                .Property(e => e.Logradouro)
                .HasColumnName("varchar(150)")
                .HasMaxLength(150)
                .IsRequired();

            builder
                .Property(e => e.Numero)
                .HasColumnName("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(e => e.Bairro)
                .HasColumnName("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(e => e.Cep)
                .HasColumnName("varchar(8)")
                .HasMaxLength(8)
                .IsRequired();

            builder
                .HasOne(e => e.Evento)
                .WithOne(e => e.Endereco)
                .HasForeignKey<Endereco>(e => e.EventoId)
                .IsRequired(false);


            builder
                .Ignore(e => e.ValidationResult);

            builder
                .Ignore(e => e.CascadeMode);

            builder
                .ToTable("Enderecos");
        }
    }
}