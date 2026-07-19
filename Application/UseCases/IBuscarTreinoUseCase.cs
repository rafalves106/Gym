using Application.DTOs;
namespace Application.UseCases;

public interface IBuscarTreinoUseCase
{
  Task<BuscarTreinoOutputDTO> ExecutarAsync(BuscarTreinoInputDTO input);
}