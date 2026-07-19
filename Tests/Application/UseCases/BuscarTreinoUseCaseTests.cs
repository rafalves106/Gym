using Application.UseCases;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Tests.Application.UseCases;

public class BuscarTreinoUseCaseTests
{
  [Fact]
  public async Task ExecutarAsync_DeveRetornarDto_QuandoTreinoExiste()
  {
    var id = Guid.NewGuid();
    var treinoFake = new Treino(id, "Treino A", DateTime.Now, true);

    var repositoryMock = new Mock<ITreinoRepository>();

    repositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync(treinoFake);

    var useCase = new BuscarTreinoUseCase(repositoryMock.Object);
    var input = new BuscarTreinoInputDTO { Id = id };

    var result = await useCase.ExecutarAsync(input);

    result.Should().NotBeNull();
    result.Id.Should().Be(id);
    result.Nome.Should().Be("Treino A");
  }

  [Fact]
  public async Task ExecutarAsync_DeveLancarKeyNotFoundException_QuandoTreinoNaoExiste()
  {
    var id = Guid.NewGuid();

    var repositoryMock = new Mock<ITreinoRepository>();

    repositoryMock.Setup(r => r.ObterPorIdAsync(id)).ReturnsAsync((Treino?)null);

    var useCase = new BuscarTreinoUseCase(repositoryMock.Object);
    var input = new BuscarTreinoInputDTO { Id = id };

    Func<Task> act = async () => await useCase.ExecutarAsync(input);

    await act.Should().ThrowAsync<KeyNotFoundException>()
      .WithMessage("Treino não encontrado.");
  }
}