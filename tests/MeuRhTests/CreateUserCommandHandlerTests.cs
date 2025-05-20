using Domain.Commands;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;

namespace MeuRhTests;

public class CreateUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly CreateUserCommandHandler _handler;

    public CreateUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _handler = new CreateUserCommandHandler(_userRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldAddUser_AndReturnTrue_WhenValidCommand()
    {
        // Arrange
        var command = new CreateUserCommand
        {
            Name = "João da Silva",
            Email = "joao@email.com"
        };

        _userRepositoryMock
            .Setup(repo => repo.AddAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(true);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.IsType<Guid>(result);

        _userRepositoryMock.Verify(repo => repo.AddAsync(It.Is<User>(u => u.Name == command.Name && u.Email == command.Email),
            It.IsAny<CancellationToken>()), Times.Once);
    }
}