using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace app.Api.Extensions
{
    public static class JwtTokenExtensions
    {
        public static string GenerateToken(AppSettings appSettings, IList<Claim> claims)
        {
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSettings.Secret));

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = appSettings.Issuer,
                Audience = appSettings.UrlAudience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(appSettings.HourExpiration),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            });

            return tokenHandler.WriteToken(token);
        }

        public static IList<Claim> CreateClaims(string userId, string email, IList<string> userRoles)
        {
            List<Claim> claims = new()
            {
                new Claim("userId", userId),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64)
            };

            CreateRoleInClaims(claims, userRoles);

            return claims;
        }
        private static void CreateRoleInClaims(List<Claim> claims, IList<string> userRoles)
        {
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }
        }

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
    }
}
