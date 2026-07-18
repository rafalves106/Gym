using Application.DTOs;
using Domain.Repositories;
using Domain.Entities;

namespace Application.UseCases;

public class CriarTreinoUseCase(ITreinoRepository _treinoRepository) : ICriarTreinoUseCase
{
  public async Task<Guid> ExecutarAsync(CriarTreinoInputDTO input)
  {
    var treino = new Treino(
      id: Guid.NewGuid(),
      nome: input.Nome,
      dataCriacao: DateTime.Now,
      ativo: input.Ativo
    );

    await _treinoRepository.CriarAsync(treino);

    return treino.Id;
  }
}