using Application.DTOs;
namespace Application.UseCases;

public interface IEditarTreinoUseCase
{
  Task<bool> Execute(EditarTreinoInputDTO input);
}