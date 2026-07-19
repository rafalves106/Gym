using Application.UseCases;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Tests.Application.UseCases;

public class RemoverTreinoUseCaseTest
{
  [Fact]
  public async Task ExecutarAsync_DeveRemoverTreino_QuandoTreinoExistir()
  {
    var input = new RemoverTreinoInputDTO
    {
      Id = Guid.NewGuid()
    };


    var treinoExistente = new Treino(input.Id, "Treino A", DateTime.Now, true);

    var repositoryMock = new Mock<ITreinoRepository>();

    repositoryMock.Setup(r => r.ObterPorIdAsync(input.Id)).ReturnsAsync(treinoExistente);

    repositoryMock.Setup(r => r.RemoverAsync(It.IsAny<Treino>())).Returns(Task.CompletedTask);

    var useCase = new RemoverTreinoUseCase(repositoryMock.Object);
    await useCase.ExecutarAsync(input);

    repositoryMock.Verify(r => r.RemoverAsync(treinoExistente), Times.Once);
  }

  [Fact]
  public async Task ExecutarAsync_DeveLancarExcecao_QuandoTreinoNaoExistir()
  {
    var input = new RemoverTreinoInputDTO
    {
      Id = Guid.NewGuid()
    };

    var repositoryMock = new Mock<ITreinoRepository>();

    repositoryMock.Setup(r => r.ObterPorIdAsync(input.Id)).ReturnsAsync((Treino?)null);

    var useCase = new RemoverTreinoUseCase(repositoryMock.Object);

    Func<Task> act = async () => await useCase.ExecutarAsync(input);

    await act.Should().ThrowAsync<KeyNotFoundException>();
  }
}