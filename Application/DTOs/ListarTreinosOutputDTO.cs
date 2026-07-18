namespace Application.DTOs;

public class ListarTreinosOutputDTO
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public bool Ativo { get; set; }

  public ListarTreinosOutputDTO(Guid id, string nome, bool ativo)
  {
    Id = id;
    Nome = nome;
    Ativo = ativo;
  }
}