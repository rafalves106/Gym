namespace Domain.Entities;

public class Exercicio
{
  public Guid Id { get; private set; }
  public string Nome { get; private set; } = null!;
  public int Repeticoes { get; private set; }
  public int Series { get; private set; }
  public int Descanso { get; private set; }
  public Guid TreinoId { get; private set; }
  private Exercicio() { }

  public Exercicio(Guid id, Guid treinoId, string nome, int repeticoes, int series, int descanso)
  {
    ValidarNome(nome);
    ValidarRepeticoes(repeticoes);
    ValidarSeries(series);
    ValidarDescanso(descanso);

    Id = id;
    TreinoId = treinoId;
    Nome = nome;
    Repeticoes = repeticoes;
    Series = series;
    Descanso = descanso;
  }

  private static void ValidarNome(string nome)
  {
    if (string.IsNullOrWhiteSpace(nome))
      throw new ArgumentException("Nome do exercício não pode ser vazio.");

    if (nome.Length < 3)
      throw new ArgumentException("Nome do exercício deve ter pelo menos 3 caracteres.");

    if (nome.Length > 50)
      throw new ArgumentException("Nome do exercício não pode ter mais de 50 caracteres.");
  }

  private static void ValidarRepeticoes(int repeticoes)
  {
    if (repeticoes <= 0)
      throw new ArgumentException("Número de repetições deve ser maior que zero.");

    if (repeticoes > 100)
      throw new ArgumentException("Número de repetições não pode ser maior que 100.");
  }

  private static void ValidarSeries(int series)
  {
    if (series <= 0)
      throw new ArgumentException("Número de séries deve ser maior que zero.");

    if (series > 10)
      throw new ArgumentException("Número de séries não pode ser maior que 10.");
  }

  private static void ValidarDescanso(int descanso)
  {
    if (descanso <= 0)
      throw new ArgumentException("Tempo de descanso deve ser maior que zero.");

    if (descanso > 600)
      throw new ArgumentException("Tempo de descanso não pode ser maior que 600 segundos ou 10 minutos.");
  }

  public void AlterarNome(string novoNome)
  {
    ValidarNome(novoNome);
    Nome = novoNome;
  }

  public void AlterarRepeticoes(int novasRepeticoes)
  {
    ValidarRepeticoes(novasRepeticoes);
    Repeticoes = novasRepeticoes;
  }

  public void AlterarSeries(int novasSeries)
  {
    ValidarSeries(novasSeries);
    Series = novasSeries;
  }

  public void AlterarDescanso(int novoDescanso)
  {
    ValidarDescanso(novoDescanso);
    Descanso = novoDescanso;
  }
}