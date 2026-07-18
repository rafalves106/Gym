namespace Application.DTOs;

public class EditarTreinoInputDTO
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public bool Ativo { get; set; }
}