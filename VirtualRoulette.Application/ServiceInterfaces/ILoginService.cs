namespace VirtualRoulette.Application.ServiceInterfaces;

public interface ILoginService
{
    /// <summary>
    /// Generates authentication token for the user
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    string GetAuthorizationToken(string username);
}