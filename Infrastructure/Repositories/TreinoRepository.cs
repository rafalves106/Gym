using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories;

public class TreinoRepository(GymDbContext context) : ITreinoRepository
{
  public async Task AtualizarAsync(Treino treinoAtualizado)
  {
    context.Treinos.Update(treinoAtualizado);
    await context.SaveChangesAsync();
  }

  public async Task CriarAsync(Treino treino)
  {
    await context.Treinos.AddAsync(treino);
    await context.SaveChangesAsync();
  }

  public async Task<Treino?> ObterPorIdAsync(Guid id)
  {
    return await context.Treinos
      .Include(t => t.Exercicios)
      .FirstOrDefaultAsync(t => t.Id == id);
  }

  public async Task<IEnumerable<Treino>> ObterTodosAsync()
  {
    return await context.Treinos.ToListAsync();
  }

  public async Task RemoverAsync(Treino treino)
  {
    context.Treinos.Remove(treino);
    await context.SaveChangesAsync();
  }

}