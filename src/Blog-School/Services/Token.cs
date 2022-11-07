using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Blog.Models;
using Blog.Constants;

namespace Blog.Services;

public class Token
{
  public static string Generate(Student user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();

    var access = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII
      .GetBytes(SecretToken.secret)), SecurityAlgorithms.HmacSha256Signature);

    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = AddClaims(user),
      SigningCredentials = access,
      Expires = DateTime.Now.AddDays(7)
    };

    var token = tokenHandler.CreateToken(tokenDescriptor);

    return tokenHandler.WriteToken(token);
  }

  public static string GetUserId(string token)
  {
    var tokenHanlder = new JwtSecurityTokenHandler();
    var jwtSecurityToken = tokenHanlder.ReadJwtToken(token);

    return jwtSecurityToken.Claims.First(x => x.Type == "Id").Value;
  }

  private static ClaimsIdentity AddClaims(Student user)
  {
    var claims = new ClaimsIdentity();

    claims.AddClaim(new Claim(ClaimTypes.Name, user.Name));
    claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
    claims.AddClaim(new Claim("Id", user.StudentId.ToString()));

    return claims;
  }
}