using Application.DTOs;
namespace Application.UseCases;

public interface IEditarTreinoUseCase
{
  Task<bool> ExecutarAsync(Guid id, EditarTreinoInputDTO input);
}