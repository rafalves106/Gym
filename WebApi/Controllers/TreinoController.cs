using Microsoft.AspNetCore.Mvc;
using Application.UseCases;
using Application.DTOs;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreinoController(
  ICriarTreinoUseCase criarTreinoUseCase,
  IEditarTreinoUseCase editarTreinoUseCase,
  IRemoverTreinoUseCase removerTreinoUseCase,
  IListarTreinosUseCase listarTreinosUseCase,
  IBuscarTreinoUseCase buscarTreinoUseCase) : ControllerBase
{
  [HttpPost]
  public async Task<IActionResult> CriarTreino([FromBody] CriarTreinoInputDTO request)
  {
    var result = await criarTreinoUseCase.ExecutarAsync(request);
    return Created(string.Empty, result);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> EditarTreino([FromRoute] Guid id, [FromBody] EditarTreinoInputDTO request)
  {
    try
    {
      var result = await editarTreinoUseCase.Execute(id, request);
      return Ok(result);
    }
    catch (KeyNotFoundException ex)
    {
      return NotFound(new { message = ex.Message });
    }

  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> RemoverTreino([FromRoute] Guid id)
  {
    try
    {
      var request = new RemoverTreinoInputDTO { Id = id };
      await removerTreinoUseCase.ExecutarAsync(request);
      return NoContent();
    }
    catch (KeyNotFoundException ex)
    {
      return NotFound(new { message = ex.Message });
    }
  }

  [HttpGet]
  public async Task<IActionResult> ListarTreinos()
  {
    var result = await listarTreinosUseCase.ExecutarAsync();
    return Ok(result);
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> BuscarTreino([FromRoute] Guid id)
  {
    try
    {
      var request = new BuscarTreinoInputDTO { Id = id };
      var result = await buscarTreinoUseCase.ExecutarAsync(request);
      return Ok(result);
    }
    catch (KeyNotFoundException ex)
    {
      return NotFound(new { message = ex.Message });
    }
  }
}