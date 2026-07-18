using Application.DTOs;
using Domain.Repositories;

namespace Application.UseCases;

public class RemoverTreinoUseCase(ITreinoRepository treinoRepository) : IRemoverTreinoUseCase
{
  public async Task<bool> ExecutarAsync(RemoverTreinoInputDTO input)
  {
    var treino = await treinoRepository.ObterPorIdAsync(input.Id);

    if (treino == null)
    {
      throw new Exception("Treino não encontrado");
    }

    await treinoRepository.RemoverAsync(treino);

    return true;
  }
}