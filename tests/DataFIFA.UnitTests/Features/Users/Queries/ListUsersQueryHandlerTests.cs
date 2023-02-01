using System.Collections.Generic;
using DataFIFA.Application.Features.Users.Queries.ListUsers;
using DataFIFA.Application.ViewModels.Users;
using DataFIFA.UnitTests.Fakers;

namespace DataFIFA.UnitTests.Features.Users.Queries;

public class ListUsersQueryHandlerTests
{
    private readonly Mock<IUserRepository> _userRepositoryMock;

    public ListUsersQueryHandlerTests()
    {
        _userRepositoryMock = new Mock<IUserRepository>();
    }

    [Fact(DisplayName = "Given a valid query should return users")]
    public async Task GivenAValidQueryWhenQueryIsExecutedShouldReturnAllUsers()
    {
        // Arrange
        var queryHandler = GenerateQueryHandler;
        var users = new FakeUser().Generate(3);
        _userRepositoryMock.Setup(x => x.ListAllAsync())
            .ReturnsAsync(users);

        // Act
        var result = await queryHandler.Handle(new ListUsersQuery(), new CancellationToken());

        // Assert
        result.Should().BeOfType<List<UserViewModel>>();
        result.Should().HaveCount(3);
    }
    
    private ListUsersQueryHandler GenerateQueryHandler => new (_userRepositoryMock.Object);
}