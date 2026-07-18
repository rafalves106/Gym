using Application.DTOs;
using Domain.Repositories;

namespace Application.UseCases;

public class ListarTreinosUseCase(ITreinoRepository treinoRepository) : IListarTreinosUseCase
{
  public async Task<IEnumerable<ListarTreinosOutputDTO>> ExecutarAsync()
  {
    var treinos = await treinoRepository.ObterTodosAsync();

    var output = treinos.Select(treino => new ListarTreinosOutputDTO(
      id: treino.Id,
      nome: treino.Nome,
      ativo: treino.Ativo
    ));

    return output;
  }
}