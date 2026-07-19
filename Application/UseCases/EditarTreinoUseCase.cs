using Application.DTOs;
using Domain.Repositories;

namespace Application.UseCases;

public class EditarTreinoUseCase(ITreinoRepository treinoRepository) : IEditarTreinoUseCase
{
  public async Task<bool> ExecutarAsync(Guid id, EditarTreinoInputDTO input)
  {
    var treino = await treinoRepository.ObterPorIdAsync(id);

    if (treino is null)
      throw new KeyNotFoundException("Treino não encontrado.");

    treino.AlterarNome(input.Nome);


    if (input.Ativo)
      treino.Ativar();
    else
      treino.Desativar();

    await treinoRepository.AtualizarAsync(treino);

    return true;
  }
}