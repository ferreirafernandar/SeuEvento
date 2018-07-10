using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeuEvento.Domain.Eventos;

namespace SeuEvento.Infra.Data.Mappings
{
    public class EventoMapping : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder
                .Property(e => e.Nome)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Property(e => e.DescricaoCurta)
                .HasColumnType("varchar(150)");

            builder
                .Property(e => e.DescricaoLonga)
                .HasColumnType("varchar(max)");

            builder
                .Property(e => e.NomeEmpresa)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder
                .Ignore(e => e.ValidationResult);

            builder
                .Ignore(e => e.Tags);

            builder
                .Ignore(e => e.CascadeMode);

            builder
                .HasOne(e => e.Organizador)
                .WithMany(o => o.Eventos)
                .HasForeignKey(o => o.OrganizadorId);

            builder
                .HasOne(e => e.Categoria)
                .WithMany(e => e.Eventos)
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired(false);

            builder
                .ToTable("Eventos");
        }
    }
}