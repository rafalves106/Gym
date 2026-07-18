using Application.DTOs;
namespace Application.UseCases;

public interface IRemoverTreinoUseCase
{
  Task<bool> ExecutarAsync(RemoverTreinoInputDTO input);
}