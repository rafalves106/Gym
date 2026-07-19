using Application.DTOs;
namespace Application.UseCases;

public interface ICriarTreinoUseCase
{
  Task<Guid> ExecutarAsync(CriarTreinoInputDTO input);
}