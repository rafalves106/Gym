using Application.UseCases;
using Application.DTOs;
using Domain.Entities;
using Domain.Repositories;
using FluentAssertions;
using Moq;

namespace Tests.Application.UseCases;

public class CriarTreinoUseCaseTests
{
  [Fact]
  public async Task ExecutarAsync_DeveCriarTreino_QuandoInputValido()
  {
    var input = new CriarTreinoInputDTO
    {
      Nome = "Treino A",
      Ativo = true
    };

    var repositoryMock = new Mock<ITreinoRepository>();

    repositoryMock.Setup(r => r.CriarAsync(It.IsAny<Treino>())).Returns(Task.CompletedTask);

    var useCase = new CriarTreinoUseCase(repositoryMock.Object);

    var result = await useCase.ExecutarAsync(input);

    result.Should().NotBeEmpty();

    repositoryMock.Verify(r => r.CriarAsync(It.Is<Treino>(t => t.Nome == input.Nome && t.Ativo == input.Ativo)), Times.Once);
  }

  [Fact]
  public async Task ExecutarAsync_NaoDeveChamarRepositorio_QuandoNomeVazio()
  {
    var input = new CriarTreinoInputDTO
    {
      Nome = "",
      Ativo = true
    };

    var repositoryMock = new Mock<ITreinoRepository>();

    var useCase = new CriarTreinoUseCase(repositoryMock.Object);

    Func<Task> act = async () => await useCase.ExecutarAsync(input);

    await act.Should().ThrowAsync<ArgumentException>();

    repositoryMock.Verify(r => r.CriarAsync(It.IsAny<Treino>()), Times.Never);
  }
}