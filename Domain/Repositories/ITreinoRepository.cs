namespace Domain.Repositories;

using Domain.Entities;

public interface ITreinoRepository
{
  Task<Treino?> ObterPorIdAsync(Guid id);
  Task<IEnumerable<Treino>> ObterTodosAsync();
  Task CriarAsync(Treino treino);
  Task AtualizarAsync(Treino treinoAtualizado);
  Task RemoverAsync(Treino treino);
}