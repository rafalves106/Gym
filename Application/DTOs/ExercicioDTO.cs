namespace Application.DTOs;

public class ExercicioDTO
{
  public Guid Id { get; set; }
  public string Nome { get; set; } = string.Empty;
  public int Repeticoes { get; set; }
  public int Series { get; set; }
  public int Descanso { get; set; }
}