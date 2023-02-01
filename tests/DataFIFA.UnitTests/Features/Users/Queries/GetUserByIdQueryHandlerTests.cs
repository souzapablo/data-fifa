using DataFIFA.Application.Features.Users.Queries.GetById;
using DataFIFA.Application.ViewModels.Users;
using DataFIFA.UnitTests.Fakers;

namespace DataFIFA.UnitTests.Features.Users.Queries;

public class GetUserByIdQueryHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;
    private readonly MessageHandler _messageHandler;

    public GetUserByIdQueryHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
        _messageHandler = new MessageHandler();
    }

    [Fact(DisplayName = "Given a valid id return UserDetailsViewModel")]
    public async Task GivenAValidIdWhenQueryIsExecutedShouldReturnUserDetailsViewModel()
    {
        // Arrange
        var queryHandler = GenerateQueryHandler;
        var user = new FakeUser().Generate();
        var query = new GetUserByIdQuery(user.Id);
        _userRepositoryMock.Setup(x => x.GetUserByIdWithCurrentTeam(user.Id))
            .ReturnsAsync(user);
        
        // Act
        var result = await queryHandler.Handle(query, new CancellationToken());

        // Assert
        result.Should().BeOfType<UserDetailsViewModel>();
    }
    
    [Fact(DisplayName = "Given an invalid id return error message")]
    public async Task GivenAnInvalidIdWhenQueryIsExecutedShouldReturnErrorMessage()
    {
        // Arrange
        var queryHandler = GenerateQueryHandler;
        var userId = Guid.NewGuid();
        var query = new GetUserByIdQuery(userId);

        // Act
        var result = await queryHandler.Handle(query, new CancellationToken());

        // Assert
        _messageHandler.Messages.Should().Contain(x => x.Message == ErrorConstants.UserNotFound(userId));
    }
    
    private GetUserByIdQueryHandler GenerateQueryHandler => new (_userRepositoryMock.Object, _messageHandler);
}