using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PM.API.Resources;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PM.API.Domain.Helpers
{
    public class AccessToken
    {
		public string GenerateToken(UserResource account, string secretKey)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(secretKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					 new Claim(ClaimTypes.Name, account.Id.ToString()),
					 new Claim(ClaimTypes.UserData, JsonConvert.SerializeObject(account)),
				}),
				Expires = DateTime.UtcNow.AddYears(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}
