using Application.DTOs;
namespace Application.UseCases;

public interface IListarTreinosUseCase
{
  Task<IEnumerable<ListarTreinosOutputDTO>> ExecutarAsync();
}