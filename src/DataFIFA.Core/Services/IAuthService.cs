namespace DataFIFA.Core.Services;

public interface IAuthService
{
    string GenerateJwtToken(string name);
    string ComputeSha256Hash(string password);
}