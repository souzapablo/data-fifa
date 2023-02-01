using DataFIFA.Application.Features.Users.Command.AddUser;

namespace DataFIFA.UnitTests.Features.Users.Commands;

public class AddUserCommandHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly Mock<IAuthService> _authService;
    private readonly MessageHandler _messageHandler;
    
    public AddUserCommandHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _messageHandler = new MessageHandler();
        _authService = new Mock<IAuthService>();
    }
    
    [Theory(DisplayName = "Given a valid user command add a new user")]
    [InlineData("Olga", "olga@teste.com", "GIVEN@validp455")]
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
    [InlineData("Olga", "olga@teste.com", "GIVEN@validp455")]
    public async Task GivenARegisteredEmailWhenCommandIsExecutedShouldThrowException(string name, string email, string password)
    {
        // Arrange
        var commandHandler = GenerateCommandHandler;
        var command = new AddUserCommand(name, email, password);
        _userRepositoryMock.Setup(x => x.IsEmailRegistered(It.IsAny<string>()))
            .ReturnsAsync(true);
        
        // Act
        var result = await commandHandler.Handle(command, new CancellationToken());

        // Assert
        _messageHandler.Messages.Should().Contain(x => x.Message == ErrorConstants.EmailAlreadyRegistered);
        _userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Never);
    }

    [Theory(DisplayName = "Given an invalid command return error message")]
    [InlineData("Olga", "olga@teste.com", "weakpassword")]
    [InlineData("Olga", "olgaestm", "GIVEN@validp455")]
    [InlineData(null, "olga@teste.com", "GIVEN@validp455")]
    public async Task GivenAnInvalidPasswordWhenCommandIsExecutedShouldReturnErrorMessage(string name, string email, string password)
    {
        // Arrange
        var commandHandler = GenerateCommandHandler;
        var command = new AddUserCommand(name, email, password);

        // Act
        await commandHandler.Handle(command, new CancellationToken());

        // Assert
        _messageHandler.HasMessage.Should().BeTrue();
        _messageHandler.Messages.Should().Contain(x => x.Status == HttpStatusCode.BadRequest);
    }

    private AddUserCommandHandler GenerateCommandHandler => new (_userRepositoryMock.Object, _messageHandler, _authService.Object);
}