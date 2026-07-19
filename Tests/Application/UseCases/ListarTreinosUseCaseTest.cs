using Application.UseCases;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Tests.Application.UseCases;

public class ListarTreinosUseCaseTests
{
  [Fact]
  public async Task ExecutarAsync_DeveRetornarListaDeDtos_QuandoExistiremTreinos()
  {
    var treino1 = new Treino(Guid.NewGuid(), "Treino A", DateTime.Now, true);
    var treino2 = new Treino(Guid.NewGuid(), "Treino B", DateTime.Now, false);

    var repositoryMock = new Mock<ITreinoRepository>();

    repositoryMock.Setup(r => r.ObterTodosAsync()).ReturnsAsync(new List<Treino> { treino1, treino2 });

    var useCase = new ListarTreinosUseCase(repositoryMock.Object);

    var result = await useCase.ExecutarAsync();

    result.Should().NotBeNull();
    result.Should().HaveCount(2);
    result.Should().ContainSingle(t => t.Id == treino1.Id && t.Nome == "Treino A" && t.Ativo);
    result.Should().ContainSingle(t => t.Id == treino2.Id && t.Nome == "Treino B" && !t.Ativo);
  }

  [Fact]
  public async Task ExecutarAsync_DeveRetornarListaVazia_QuandoNaoExistiremTreinos()
  {
    var repositoryMock = new Mock<ITreinoRepository>();
    repositoryMock.Setup(r => r.ObterTodosAsync()).ReturnsAsync(new List<Treino>());

    var useCase = new ListarTreinosUseCase(repositoryMock.Object);

    var result = await useCase.ExecutarAsync();

    result.Should().NotBeNull();
    result.Should().BeEmpty();
  }
}