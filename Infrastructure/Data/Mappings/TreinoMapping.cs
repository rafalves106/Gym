using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class TreinoMapping : IEntityTypeConfiguration<Treino>
{
  public void Configure(EntityTypeBuilder<Treino> builder)
  {
    builder.ToTable("Treinos");
    builder.HasKey(t => t.Id);

    builder.Property(t => t.Nome)
      .IsRequired()
      .HasMaxLength(50);

    builder.Property(t => t.DataCriacao)
      .IsRequired();

    builder.Metadata.FindNavigation(nameof(Treino.Exercicios))!
      .SetPropertyAccessMode(PropertyAccessMode.Field);
  }
}