using Application.DTOs;
using Domain.Repositories;

namespace Application.UseCases;

public class EditarTreinoUseCase(ITreinoRepository treinoRepository) : IEditarTreinoUseCase
{
  public async Task<bool> Execute(EditarTreinoInputDTO input)
  {
    var treino = await treinoRepository.ObterPorIdAsync(input.Id);

    if (treino is null)
      throw new Exception("Treino não encontrado");

    treino.AlterarNome(input.Nome);


    if (input.Ativo)
      treino.Ativar();
    else
      treino.Desativar();

    await treinoRepository.AtualizarAsync(treino);

    return true;
  }
}