using System;
using System.Threading;
using System.Threading.Tasks;
using DataFIFA.Application.Features.Users.Command.AddUser;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Exceptions;
using DataFIFA.Core.Helpers;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataFIFA.UnitTests.Features.Users.Commands;

public class AddUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly MessageHandler _messageHandler;
    
    public AddUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _messageHandler = new MessageHandler();
    }
    
    [Theory(DisplayName = "Given a valid user command add a new user")]
    [InlineData("Olga", "olga@teste.com", "testing")]
    public async Task GivenAValidAddUserCommandWhenCommandIsExecutedShouldAddNewUser(string name, string email, string password)
    {
        // Arrange
        var commandHandler = GenerateCommandHandler;
        var command = new AddUserCommand(name, email, password);
        _userRepositoryMock.Setup(x => x.IsEmailRegistered(It.IsAny<string>()))
            .ReturnsAsync(false);
        
        // Act
        await commandHandler.Handle(command, new CancellationToken());
        
        // Assert
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
    }
    
    [Theory(DisplayName = "Given an already registered e-mail throw exception")]
    [InlineData("Olga", "olga@teste.com", "testing")]
    public void GivenARegisteredEmailWhenCommandIsExecutedShouldThrowException(string name, string email, string password)
    {
        // Arrange
        var commandHandler = GenerateCommandHandler;
        var command = new AddUserCommand(name, email, password);
        _userRepositoryMock.Setup(x => x.IsEmailRegistered(It.IsAny<string>()))
            .ReturnsAsync(true);
        
        // Act
        Func<Task> result = () => commandHandler.Handle(command, new CancellationToken());

        // Assert
        result.Should().ThrowAsync<EmailAlreadyRegisteredException>()
            .WithMessage("E-mail already registered.");
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Never);
    }

    private AddUserCommandHandler GenerateCommandHandler => new (_userRepositoryMock.Object, _messageHandler);
}