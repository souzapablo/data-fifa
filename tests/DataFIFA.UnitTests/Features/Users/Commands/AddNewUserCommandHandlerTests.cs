using System;
using System.Threading;
using System.Threading.Tasks;
using DataFIFA.Application.Features.Users.Command;
using DataFIFA.Application.Features.Users.Command.AddNewUser;
using DataFIFA.Core.Entities;
using DataFIFA.Core.Exceptions;
using DataFIFA.Core.Helpers;
using DataFIFA.Core.Helpers.Interfaces;
using DataFIFA.Infrastructure.Persistence.Repositories.Interfaces;
using FluentAssertions;
using Moq;
using Xunit;

namespace DataFIFA.UnitTests.Features.Users.Commands;

public class AddNewUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly MessageHandler _messageHandler;
    private readonly AddNewUserCommandHandler _commandHandler;

    public AddNewUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _messageHandler = new MessageHandler();
        _commandHandler = new AddNewUserCommandHandler(_userRepositoryMock.Object, _messageHandler);
    }
    
    [Fact]
    public async Task GivenAValidAddUserCommandWhenCommandIsExecutedShouldAddNewUser()
    {
        // Arrange
        var command = new AddNewUserCommand("Olga", "olga@teste.com", "testing");
        _userRepositoryMock.Setup(x => x.IsEmailRegistered(It.IsAny<string>()))
            .ReturnsAsync(false);
        
        // Act
        await _commandHandler.Handle(command, new CancellationToken());
        
        // Assert
        _userRepositoryMock.Verify(x => x.AddNewUser(It.IsAny<User>()), Times.Once);
    }
    
    [Fact]
    public void GivenARegisteredEmailWhenCommandIsExecutedShouldThrowException()
    {
        // Arrange
        var command = new AddNewUserCommand("Olga", "olga@teste.com", "testing");
        _userRepositoryMock.Setup(x => x.IsEmailRegistered(It.IsAny<string>()))
            .ReturnsAsync(true);
        
        // Act
        Func<Task> result = () => _commandHandler.Handle(command, new CancellationToken());

        // Assert
        result.Should().ThrowAsync<EmailAlreadyRegisteredException>()
            .WithMessage("E-mail already registered.");
        _userRepositoryMock.Verify(x => x.AddNewUser(It.IsAny<User>()), Times.Never);
    }
}