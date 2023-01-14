namespace DataFIFA.Core.Services;

public interface IAuthService
{
    string GenerateJwtToken(string userName);
}