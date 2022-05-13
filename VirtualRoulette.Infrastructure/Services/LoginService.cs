using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VirtualRoulette.Application.ServiceInterfaces;
using VirtualRoulette.Infrastructure.Settings;

namespace VirtualRoulette.Infrastructure.Services;

public class LoginService : ILoginService
{
    private readonly JwtSettings _jwtSettings;

    public LoginService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public string GetAuthorizationToken(string username)
    {
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.NameIdentifier, username)
            }),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var jwtTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(token);
    }
}