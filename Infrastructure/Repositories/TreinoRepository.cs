using Domain.Entities;
using Domain.Repositories;
namespace Infrastructure.Repositories;

public class TreinoRepository : ITreinoRepository
{
  public Task AtualizarAsync(Treino treinoAtualizado)
  {
    throw new NotImplementedException();
  }

  public Task CriarAsync(Treino treino)
  {
    throw new NotImplementedException();
  }

  public Task<Treino?> ObterPorIdAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<Treino>> ObterTodosAsync()
  {
    throw new NotImplementedException();
  }

  public Task RemoverAsync(Treino treino)
  {
    throw new NotImplementedException();
  }
}