namespace Domain.Entities;

public class Treino
{
  private Guid _id;
  private string _nome = string.Empty;
  private List<Exercicio> _exercicios;
  private DateTime _dataCriacao;
  private bool _ativo;

  private Treino(Guid id, string nome, List<Exercicio> exercicios, DateTime dataCriacao, bool ativo)
  {
    _id = id;
    _nome = nome;
    _exercicios = new List<Exercicio>();
    _dataCriacao = dataCriacao;
    _ativo = ativo;
  }

  private static void ValidarNome(string nome)
  {
    if (string.IsNullOrWhiteSpace(nome))
      throw new ArgumentException("Nome do treino não pode ser vazio.");

    if (nome.Length < 3)
      throw new ArgumentException("Nome do treino deve ter pelo menos 3 caracteres.");

    if (nome.Length > 50)
      throw new ArgumentException("Nome do treino não pode ter mais de 50 caracteres.");
  }

  private static void ValidarDataCriacao(DateTime dataCriacao)
  {
    if (dataCriacao > DateTime.Now)
      throw new ArgumentException("Data de criação não pode ser no futuro.");
  }

  public void AdicionarExercicio(Exercicio exercicio)
  {
    if (exercicio == null)
      throw new ArgumentNullException(nameof(exercicio), "Exercício não pode ser nulo.");

    _exercicios.Add(exercicio);
  }

  public void RemoverExercicio(Exercicio exercicio)
  {
    if (exercicio == null)
      throw new ArgumentNullException(nameof(exercicio), "Exercício não pode ser nulo.");

    _exercicios.Remove(exercicio);
  }
}