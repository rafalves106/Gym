using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class GymDbContext(DbContextOptions<GymDbContext> options) : DbContext(options)
{
  public DbSet<Treino> Treinos { get; set; }
  public DbSet<Exercicio> Exercicios { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);

    base.OnModelCreating(modelBuilder);
  }
}