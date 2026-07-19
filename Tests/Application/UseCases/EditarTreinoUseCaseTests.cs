using Application.UseCases;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Tests.Application.UseCases;

public class EditarTreinoUseCaseTests
{
  [Fact]
  public async Task ExecutarAsync_DeveEditarTreino_QuandoTreinoExistir()
  {
    var idFake = Guid.NewGuid();

    var treinoAntigo = new Treino(idFake, "Treino Antigo", DateTime.Now, true);

    var input = new EditarTreinoInputDTO
    {
      Nome = "Treino A Editado",
      Ativo = false
    };

    var repositoryMock = new Mock<ITreinoRepository>();

    repositoryMock.Setup(r => r.ObterPorIdAsync(idFake)).ReturnsAsync(treinoAntigo);

    repositoryMock.Setup(r => r.AtualizarAsync(It.IsAny<Treino>())).Returns(Task.CompletedTask);

    var useCase = new EditarTreinoUseCase(repositoryMock.Object);
    await useCase.ExecutarAsync(idFake, input);

    treinoAntigo.Nome.Should().Be("Treino A Editado");
    treinoAntigo.Ativo.Should().BeFalse();

    repositoryMock.Verify(r => r.AtualizarAsync(treinoAntigo), Times.Once);
  }

  [Fact]
  public async Task ExecutarAsync_DeveLancarExcecao_QuandoTreinoNaoExistir()
  {
    var idFake = Guid.NewGuid();

    var input = new EditarTreinoInputDTO
    {
      Nome = "Treino A Editado",
      Ativo = false
    };

    var repositoryMock = new Mock<ITreinoRepository>();

    repositoryMock.Setup(r => r.ObterPorIdAsync(idFake)).ReturnsAsync((Treino?)null);

    var useCase = new EditarTreinoUseCase(repositoryMock.Object);

    Func<Task> act = async () => await useCase.ExecutarAsync(idFake, input);

    await act.Should().ThrowAsync<KeyNotFoundException>();
  }
}