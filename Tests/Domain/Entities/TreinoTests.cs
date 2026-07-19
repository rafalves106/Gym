using Domain.Entities;
using FluentAssertions;

namespace Tests.Domain.Entities;

public class TreinoTests
{
  [Fact]
  public void Instanciar_DeveCriarTreinoComEstadoInicialCorreto()
  {
    var id = Guid.NewGuid();
    var nome = "Treino A";
    var dataCriacao = DateTime.Now;
    var ativo = true;

    var treino = new Treino(id, nome, dataCriacao, ativo);

    treino.Id.Should().Be(id);
    treino.Nome.Should().Be(nome);
    treino.DataCriacao.Should().Be(dataCriacao);
    treino.Ativo.Should().BeTrue();
  }

  [Fact]
  public void AlterarNome_DeveAlterarNomeComSucesso()
  {
    var treino = new Treino(Guid.NewGuid(), "Treino A", DateTime.Now, true);
    var novoNome = "Treino B";

    treino.AlterarNome(novoNome);

    treino.Nome.Should().Be(novoNome);
  }

  [Fact]
  public void AlterarAtivo_DeveDesativarTreinoComSucesso()
  {
    var treino = new Treino(Guid.NewGuid(), "Treino A", DateTime.Now, true);

    treino.Desativar();

    treino.Ativo.Should().BeFalse();
  }

  [Fact]
  public void AlterarAtivo_DeveAtivarTreinoComSucesso()
  {
    var treino = new Treino(Guid.NewGuid(), "Treino A", DateTime.Now, false);

    treino.Ativar();

    treino.Ativo.Should().BeTrue();
  }

  [Fact]
  public void AdicionarExercicio_DeveAdicionarExercicioComSucesso()
  {
    var treino = new Treino(Guid.NewGuid(), "Treino A", DateTime.Now, true);
    var exercicio = new Exercicio(Guid.NewGuid(), treino.Id, "Exercicio A", 3, 10, 90);

    treino.AdicionarExercicio(exercicio);

    treino.Exercicios.Should().Contain(exercicio);
  }

  [Fact]
  public void RemoverExercicio_DeveRemoverExercicioComSucesso()
  {
    var treino = new Treino(Guid.NewGuid(), "Treino A", DateTime.Now, true);
    var exercicio = new Exercicio(Guid.NewGuid(), treino.Id, "Exercicio A", 3, 10, 90);
    treino.AdicionarExercicio(exercicio);

    treino.RemoverExercicio(exercicio);

    treino.Exercicios.Should().NotContain(exercicio);
  }

  [Fact]
  public void AdicionarExercicio_DeveLancarExcecaoQuandoExercicioForNulo()
  {
    var treino = new Treino(Guid.NewGuid(), "Treino A", DateTime.Now, true);

    Action act = () => treino.AdicionarExercicio(null!);

    act.Should().Throw<ArgumentNullException>();
  }

  [Fact]
  public void AdicionarExercicio_DeveLancarExcecaoQuandoIdDoTreinoDoExercicioForDiferente()
  {
    var treino = new Treino(Guid.NewGuid(), "Treino A", DateTime.Now, true);
    var exercicio = new Exercicio(Guid.NewGuid(), Guid.NewGuid(), "Exercicio A", 3, 10, 90);

    Action act = () => treino.AdicionarExercicio(exercicio);

    act.Should().Throw<InvalidOperationException>().WithMessage("Não é possível adicionar um exercício que pertence a outro treino.");
  }
}