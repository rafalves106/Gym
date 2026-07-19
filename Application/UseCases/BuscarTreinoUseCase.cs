using Application.DTOs;
using Domain.Repositories;

namespace Application.UseCases;

public class BuscarTreinoUseCase(ITreinoRepository treinoRepository) : IBuscarTreinoUseCase
{
  public async Task<BuscarTreinoOutputDTO> ExecutarAsync(BuscarTreinoInputDTO input)
  {
    var treino = await treinoRepository.ObterPorIdAsync(input.Id);

    if (treino is null)
      throw new KeyNotFoundException("Treino não encontrado.");

    var exerciciosDTO = treino.Exercicios.Select(exercicio => new ExercicioDTO
    {
      Id = exercicio.Id,
      Nome = exercicio.Nome,
      Repeticoes = exercicio.Repeticoes,
      Series = exercicio.Series,
      Descanso = exercicio.Descanso
    });

    var output = new BuscarTreinoOutputDTO(
      id: treino.Id,
      nome: treino.Nome,
      ativo: treino.Ativo,
      exercicios: exerciciosDTO
    );

    return output;
  }
}