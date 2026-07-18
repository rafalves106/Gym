namespace Domain.Entities;

public class Treino
{
  public Guid Id { get; private set; }
  public string Nome { get; private set; } = null!;
  private readonly List<Exercicio> _exercicios = new();
  public IReadOnlyCollection<Exercicio> Exercicios => _exercicios.AsReadOnly();
  public DateTime DataCriacao { get; private set; }
  public bool Ativo { get; private set; }

  private Treino() { }

  public Treino(Guid id, string nome, DateTime dataCriacao, bool ativo)
  {
    ValidarNome(nome);
    ValidarDataCriacao(dataCriacao);

    Id = id;
    Nome = nome;
    DataCriacao = dataCriacao;
    Ativo = ativo;
  }

  public void AlterarNome(string novoNome)
  {
    ValidarNome(novoNome);
    Nome = novoNome;
  }

  public void Ativar()
  {
    Ativo = true;
  }

  public void Desativar()
  {
    Ativo = false;
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