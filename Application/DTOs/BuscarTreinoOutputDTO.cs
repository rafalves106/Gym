namespace Application.DTOs;

public class BuscarTreinoOutputDTO
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public bool Ativo
  { get; set; }

  public IEnumerable<ExercicioDTO> Exercicios { get; set; } = new List<ExercicioDTO>();

  public BuscarTreinoOutputDTO(Guid id, string nome, IEnumerable<ExercicioDTO> exercicios, bool ativo)
  {
    Id = id;
    Nome = nome;
    Exercicios = exercicios;
    Ativo = ativo;
  }
}